using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    GameObject player;
    public GameObject hand;

    GameObject framedInteractable;
    GameObject selectedInteractable;
    public float interactionRange = 5;
    LayerMask mask;

    public GameObject interactPanel;

    // Start is called before the first frame update
    void Start()
    {
        interactPanel.SetActive(false);
        player = gameObject;
        mask = LayerMask.GetMask("Default");
    }

    // Update is called once per frame
    void Update()
    {
        RayCastCheck();

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(selectedInteractable == null)
            {
                if(framedInteractable != null)
                {
                    selectedInteractable = framedInteractable;
                    interactPanel.SetActive(false);
                    selectedInteractable.GetComponent<Interactable>().Interact(player);
                }
            }

            else if (selectedInteractable != null)
            {
                selectedInteractable.GetComponent<Interactable>().EndInteraction();
                RemoveSelectedItem();
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (selectedInteractable != null)
            {
                selectedInteractable.GetComponent<Interactable>().Use();
            }

            else Punch();
        }

    }

    void RayCastCheck()
    {
        if (selectedInteractable == null)
        {
            Physics.Raycast(transform.position, transform.forward, out RaycastHit hit, interactionRange, mask);

            if (hit.collider != null && hit.collider.tag == "Interactable")
            {
                framedInteractable = hit.transform.gameObject;
                interactPanel.SetActive(true);
            }

            else if(hit.collider == null || hit.collider.tag != "Interactable")
            {
                framedInteractable = null;
                interactPanel.SetActive(false);
            }
        }
    }

    public void RemoveSelectedItem()
    {
        selectedInteractable = null;
    }

    public void Punch()
    {
        hand.GetComponent<HandAnimController>().UsePunch();
    }
}
