using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{

    public GameObject interaction_Info_UI;
    TextMeshProUGUI interaction_text;
    readonly float maxDistance = 7f;

    private void Start()
    {
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
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
                float distance = Vector3.Distance(Camera.main.transform.position, selectionTransform.position);

                if (distance <= maxDistance)
                {
                    interaction_text.text = selectionTransform.GetComponent<InteractableObject>().GetItemName();
                    interaction_Info_UI.SetActive(true);
                }

                else
                {
                    interaction_Info_UI.SetActive(false);
                }
            }
            else
            {
                interaction_Info_UI.SetActive(false);
            }

        }
    }
}
