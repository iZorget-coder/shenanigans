using System.Collections;
using System.Collections.Generic;
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
    }

    void Update()
    {
 
        float distanceToPlayer = Vector3.Distance(unit.position, mainCam.position);

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

        transform.LookAt(mainCam);

  
        transform.Rotate(180, 0, 0);

      
        Vector3 desiredPosition = unit.position + offset;

       
        transform.position = desiredPosition;
    }
}
