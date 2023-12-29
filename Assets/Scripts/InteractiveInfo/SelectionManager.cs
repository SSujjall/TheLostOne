using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance { get; set; }
    public GameObject interaction_Info_UI;
    TextMeshProUGUI interaction_text;
    public bool OnTarget;

    private void Start()
    {
        OnTarget = false;
        interaction_text = interaction_Info_UI.GetComponent<TextMeshProUGUI>();
    }

    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        else
        {
            Instance = this;
        }
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            var selectionTransform = hit.transform;
            InteractableObject Interactable = selectionTransform.GetComponent<InteractableObject>();

            if (Interactable && Interactable.PlayerInRange)
            {
                OnTarget = true;
                interaction_text.text = Interactable.GetItemName();
                interaction_Info_UI.SetActive(true);
            }
            else
            {
                OnTarget = false;
                interaction_Info_UI.SetActive(false);
            }

        }
        else
        {
            OnTarget = false;
            interaction_Info_UI.SetActive(false);
        }
    }
}
