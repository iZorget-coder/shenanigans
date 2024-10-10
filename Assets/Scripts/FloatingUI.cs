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
    public Animator externalAnimator;
    public TextMeshProUGUI doorOpen;
    private bool isDoorOpen = false;

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

        if (externalAnimator == null)
        {
            Debug.LogError("No Animator assigned to FloatingText script.");
        }

        UpdateDoorStatusText();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(unit.position, mainCam.position);

        if (distanceToPlayer <= visibilityDistance)
        {
            textCanvasGroup.alpha = 1f;
            textCanvasGroup.interactable = true;
            textCanvasGroup.blocksRaycasts = true;

            UpdateDoorStatusText();

            if (Input.GetKeyDown(KeyCode.E) && externalAnimator != null)
            {
                if (!isDoorOpen)
                {
                    externalAnimator.SetBool("isOpening", true);
                    externalAnimator.SetBool("isClosing", false);
                    isDoorOpen = true;
                }
                else
                {
                    externalAnimator.SetBool("isOpening", false);
                    externalAnimator.SetBool("isClosing", true);
                    isDoorOpen = false;
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

        transform.LookAt(mainCam);
        transform.Rotate(180, 0, 0);

        Vector3 desiredPosition = unit.position + offset;
        transform.position = desiredPosition;
    }

    void UpdateDoorStatusText()
    {
        if (doorOpen != null)
        {
            doorOpen.text = isDoorOpen ? "close" : "open";
        }
    }
}
