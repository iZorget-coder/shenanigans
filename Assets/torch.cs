using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class torch : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject torchSlot;
    GameObject torchObject;
    FloatingText torchScrpt;
    GameObject player;

    public GameObject torchLight;
    void Start()
    {
        torchScrpt = GameObject.FindGameObjectWithTag("drawerUI").GetComponent<FloatingText>();
        torchObject = GameObject.Find("torch");
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        

            if (torchScrpt.isDrawerOpen && Input.GetKeyDown(KeyCode.C))
            {
              
                if (torchSlot != null)
            {
                torchSlot.SetActive(!false);
                torchObject.transform.SetParent(player.transform);
                torchObject.transform.localPosition = new Vector3(-1.33f, 2.56f, torchObject.transform.localPosition.z);

                
                torchObject.transform.localRotation = Quaternion.Euler(0, -90, 90);

                torchLight.SetActive(true);
            }
        }
        
        
    }
}
