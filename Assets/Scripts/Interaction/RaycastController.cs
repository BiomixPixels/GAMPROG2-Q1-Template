using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RaycastController : MonoBehaviour
{
    [SerializeField]
    private float raycastDistance = 5.0f;
    [SerializeField]
    private GameObject player;
    [SerializeField]
    //The tag that will determine what the raycast will hit
    string selectionTag = "Interactable";
    //The UI text component that will display the name of the interactable hit
    public TextMeshProUGUI interactionInfo;

    // Update is called once per frame
    private void Update()
    {

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectionTag))
            {
                var selectionID = selection.GetComponent<Item>();
                float distance = Vector3.Distance(selection.position, player.transform.position);
                if (distance < raycastDistance)
                {
                    interactionInfo.text = "E >> " + selectionID.id;
                    if (selectionID.id == "Door" && !InventoryManager.Instance.HasKey())
                    {
                        interactionInfo.text = interactionInfo.text + "\nYou still have no Key.";
                    }
                    selectionID.Interact();
                }
            }
            else
            {
                interactionInfo.text = "";
            }
        }
    }
}