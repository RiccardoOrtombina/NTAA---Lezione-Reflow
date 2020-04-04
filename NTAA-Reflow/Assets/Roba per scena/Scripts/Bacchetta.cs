using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bacchetta : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<AudioSource>() != null)
        {
            collision.gameObject.GetComponent<AudioSource>().PlayOneShot(collision.gameObject.GetComponent<AudioSource>().clip);
        }
    }
}
