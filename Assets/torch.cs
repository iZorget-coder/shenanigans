using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour
{
    public GameObject torchSlot;
    GameObject torchObject;
    FloatingText torchScrpt;
    GameObject player;
    GameObject playerCamera;
    public GameObject torchLight;

    void Start()
    {
        torchScrpt = GameObject.FindGameObjectWithTag("drawerUI").GetComponent<FloatingText>();
        torchObject = GameObject.Find("torch");
        player = GameObject.FindGameObjectWithTag("Player");
        playerCamera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (torchScrpt.isDrawerOpen && Input.GetKeyDown(KeyCode.C))
        {
            if (torchSlot != null)
            {
                torchSlot.SetActive(true);
                torchObject.transform.SetParent(playerCamera.transform);
                torchObject.transform.localPosition = new Vector3(-1.042f, -0.673f, -0.385f);
                torchObject.transform.localRotation = Quaternion.Euler(-64.679f, 119.838f, 605.537f);

           


                torchLight.SetActive(true);
            }
        }
    }
}
