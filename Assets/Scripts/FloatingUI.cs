using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloatingText : MonoBehaviour
{
    Transform mainCam;
    Transform unit;
    Transform worldSpaceCanvas;

    public Vector3 offset;
    public float visibilityDistance = 2.0f;

    CanvasGroup textCanvasGroup;
    public Animator doorAnimator, drawerAnimator;
    public TextMeshProUGUI textDisplay;
    private bool isDoorOpen, isDrawerOpen = false;

    // Add the audio components for door sounds
    public AudioSource audioSource;
    public AudioClip doorOpenSound;
    public AudioClip doorCloseSound;
    string message;

    void Start()
    {
        mainCam = Camera.main.transform;
        unit = transform.parent;
        worldSpaceCanvas = GameObject.FindGameObjectWithTag("InteractUI").transform;
        transform.SetParent(worldSpaceCanvas);

        textCanvasGroup = GetComponent<CanvasGroup>();
        if (textCanvasGroup == null)
        {
            textCanvasGroup = gameObject.AddComponent<CanvasGroup>();
        }

        if (doorAnimator == null)
        {
            Debug.LogError("No Animator assigned to FloatingText script.");
        }

        if (audioSource == null)
        {
            Debug.LogError("No AudioSource assigned to FloatingText script.");
        }

        UpdateDoorStatusText();
    }

    void Update()
    {
        textDisplay.text = message;
        if (gameObject.tag == "torchUI")
        {
            message = "torch";
        }

        if (gameObject.tag == "drawerUI")
        {
            message = "drawer";
        }

        float distanceToPlayer = Vector3.Distance(unit.position, mainCam.position);



        if (gameObject.tag == "doorUI")
        {
            if (distanceToPlayer <= visibilityDistance)
            {
                textCanvasGroup.alpha = 1f;
                textCanvasGroup.interactable = true;
                textCanvasGroup.blocksRaycasts = true;

                UpdateDoorStatusText();
                if (Input.GetKeyDown(KeyCode.E) && doorAnimator != null)
                {
                    if (!isDoorOpen)
                    {
                        doorAnimator.SetBool("isOpening", true);
                        doorAnimator.SetBool("isClosing", false);
                        isDoorOpen = true;

                        // Play the door open sound
                        if (doorOpenSound != null && audioSource != null)
                        {
                            audioSource.PlayOneShot(doorOpenSound);
                        }
                    }
                    else
                    {
                        doorAnimator.SetBool("isOpening", false);
                        doorAnimator.SetBool("isClosing", true);
                        isDoorOpen = false;

                        // Play the door close sound
                        if (doorCloseSound != null && audioSource != null)
                        {
                            audioSource.PlayOneShot(doorCloseSound);
                        }
                    }

                    UpdateDoorStatusText();
                }
            }
            else
            {
                textCanvasGroup.alpha = 0f;
                textCanvasGroup.interactable = false;
                textCanvasGroup.blocksRaycasts = false;
            }
        }

        if (gameObject.tag == "drawerUI")
        {
            if (distanceToPlayer <= visibilityDistance)
            {
                textCanvasGroup.alpha = 1f;
                textCanvasGroup.interactable = true;
                textCanvasGroup.blocksRaycasts = true;

                if (Input.GetKeyDown(KeyCode.E) && drawerAnimator != null)
                {
                    if (!isDrawerOpen)
                    {
                        drawerAnimator.SetBool("openDrawer", true);
                        drawerAnimator.SetBool("closeDrawer", false);
                        isDrawerOpen = true;

                       
                    }
                    else
                    {
                        drawerAnimator.SetBool("isOpening", false);
                        drawerAnimator.SetBool("isClosing", true);
                        isDrawerOpen = false;

                      
                    }

                  
                }
            }
            else
            {
                textCanvasGroup.alpha = 0f;
                textCanvasGroup.interactable = false;
                textCanvasGroup.blocksRaycasts = false;
            }
        }


        if (gameObject.tag == "torchUI")
        {
            if (distanceToPlayer <= visibilityDistance)
            {
                textCanvasGroup.alpha = 1f;
                textCanvasGroup.interactable = true;
                textCanvasGroup.blocksRaycasts = true;

            }
            else
            {
                textCanvasGroup.alpha = 0f;
                textCanvasGroup.interactable = false;
                textCanvasGroup.blocksRaycasts = false;
            }

        }
        if (gameObject.tag == "drawerUI")
        {
            if (distanceToPlayer <= visibilityDistance)
            {
                textCanvasGroup.alpha = 1f;
                textCanvasGroup.interactable = true;
                textCanvasGroup.blocksRaycasts = true;

            }
            else
            {
                textCanvasGroup.alpha = 0f;
                textCanvasGroup.interactable = false;
                textCanvasGroup.blocksRaycasts = false;
            }

        }





        transform.LookAt(mainCam);
        transform.Rotate(180, 0, 0);

        Vector3 desiredPosition = unit.position + offset;
        transform.position = desiredPosition;
    }

    void UpdateDoorStatusText()
    {
        if (textDisplay != null)
        {
            if (gameObject.tag == "doorUI")
            {
                textDisplay.text = isDoorOpen ? message = "close" : message = "open";
            }
        }

    }
}