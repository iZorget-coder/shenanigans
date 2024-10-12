using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour
{
    public GameObject torchSlotOFF, torchSlotON;
    GameObject torchObject;
    FloatingText torchScrpt;
    GameObject player;
    GameObject playerCamera;
    public GameObject torchLight;
    bool hasPickedUpTorch = false;
    private bool isTorchOn = false;

    void Start()
    {
        torchScrpt = GameObject.FindGameObjectWithTag("drawerUI").GetComponent<FloatingText>();
        torchObject = GameObject.Find("torch");
        player = GameObject.FindGameObjectWithTag("Player");
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
        torchSlotON.SetActive(false);
    }

    void Update()
    {
        if (torchScrpt.isDrawerOpen && Input.GetKeyDown(KeyCode.C))
        {
            if (torchSlotOFF != null && !hasPickedUpTorch)
            {
                torchSlotOFF.SetActive(true);
                torchObject.transform.SetParent(playerCamera.transform);
                torchObject.transform.localPosition = new Vector3(-1.042f, -0.673f, -0.385f);
                torchObject.transform.localRotation = Quaternion.Euler(-64.679f, 119.838f, 605.537f);
                hasPickedUpTorch = true;
                torchLight.SetActive(false);
                torchSlotOFF.SetActive(false);
                torchSlotON.SetActive(true);
            }

            if (hasPickedUpTorch && !isTorchOn && Input.GetKeyDown(KeyCode.C))
            {
                torchLight.SetActive(true);
                isTorchOn = true;
                torchSlotON.SetActive(true);
                torchSlotOFF.SetActive(false);
            }
            else if (hasPickedUpTorch && isTorchOn && Input.GetKeyDown(KeyCode.C))
            {
                torchLight.SetActive(false);
                isTorchOn = false;
                torchSlotON.SetActive(false);
                torchSlotOFF.SetActive(true);
            }
        }
    }
}
