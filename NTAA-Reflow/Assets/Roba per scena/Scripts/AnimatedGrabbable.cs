using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedGrabbable : Interactable
{
    bool playAnim = false;

    public override void Interact(GameObject _player)
    {
        base.Interact(_player);
        player.GetComponent<PlayerInteraction>().hand.GetComponent<Collider>().enabled = false;
        transform.position = player.GetComponent<PlayerInteraction>().hand.transform.position;
        transform.rotation = player.GetComponent<PlayerInteraction>().hand.transform.rotation;        
        transform.parent = player.GetComponent<PlayerInteraction>().hand.transform;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    public override void EndInteraction()
    {
        base.EndInteraction();
        transform.parent = null;
        GetComponent<Rigidbody>().isKinematic = false;
        player.GetComponent<PlayerInteraction>().hand.GetComponent<Collider>().enabled = false;
    }

    public override void Use()
    {
        base.Use();
        player.GetComponent<PlayerInteraction>().Punch();
    }
}
