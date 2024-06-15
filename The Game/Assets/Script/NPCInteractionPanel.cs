using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NPCInteractionTMP : MonoBehaviour
{
    public GameObject actionPanel; // Assign the action panel in the Inspector

    private void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right-click
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    ToggleActionPanel(true);
                }
                else
                {
                    ToggleActionPanel(false);
                }
            }
        }
    }

    public void ToggleActionPanel(bool show)
    {
        actionPanel.SetActive(show);
    }

    public void SetAction(string action)
    {
        Debug.Log("Setting NPC action to: " + action);
        ToggleActionPanel(false);

        // Add logic to change NPC's behavior here
        // e.g., currentAction = action;
    }
}