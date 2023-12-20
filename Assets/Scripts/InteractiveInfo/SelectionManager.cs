using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
 
    public GameObject interactionInfoUI;
    TextMeshPro interactionText;
 
    private void Start()
    {
        interactionText = interactionInfoUI.GetComponent<TextMeshPro>();
    }
 
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
 
            if (selectionTransform.GetComponent<InteractableObject>())
            {
                interactionText.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                interactionInfoUI.SetActive(true);
            }
            else 
            { 
                interactionInfoUI.SetActive(false);
            }
 
        }
    }
}
