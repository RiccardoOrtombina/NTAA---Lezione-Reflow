using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Throwable : Interactable
{
    public float throwingStrength = 5;

    public override void Interact(GameObject player)
    {
        base.Interact(player);
        transform.parent = player.transform;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public override void EndInteraction()
    {
        base.EndInteraction();
        transform.parent = null;
        GetComponent<Rigidbody>().isKinematic = false;
    }

    public override void Use()
    {
        base.Use();
        player.GetComponent<PlayerInteraction>().RemoveSelectedItem();
        EndInteraction();
        GetComponent<Rigidbody>().AddForce(player.transform.forward * throwingStrength, ForceMode.Impulse);
    }
}
