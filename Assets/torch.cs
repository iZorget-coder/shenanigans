using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject torchSlot;
    GameObject torchObject;
    FloatingText torchScrpt;
    public Vector3 torchPositionOffset;
    void Start()
    {
        torchScrpt = GameObject.FindGameObjectWithTag("drawerUI").GetComponent<FloatingText>();
        torchObject = GameObject.Find("torch");
    }

    // Update is called once per frame
    void Update()
    {
        

            if (torchScrpt.isDrawerOpen && Input.GetKeyDown(KeyCode.C))
            {
              
                if (torchSlot != null)
            {
                torchSlot.SetActive(!false);
                torchObject.transform.SetParent(transform);
                torchObject.transform.localPosition = torchPositionOffset;
                torchObject.transform.localRotation = Quaternion.identity;

            }
        }
        
        
    }
}
