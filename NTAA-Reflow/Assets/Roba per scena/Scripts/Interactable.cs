using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject player;

    public virtual void Interact(GameObject _player)
    {
        Debug.Log("Interact");
        player = _player;
    }

    public virtual void EndInteraction()
    {
        Debug.Log("End Interaction");
    }

    public virtual void Use()
    {
        Debug.Log("Use");
    }
}
