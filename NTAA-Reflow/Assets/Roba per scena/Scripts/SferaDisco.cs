using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SferaDisco : MonoBehaviour
{
    public float hitsBeforeBreaking = 1;

    private void OnCollisionEnter(Collision collision)
    {
        hitsBeforeBreaking -= 1;
        if (hitsBeforeBreaking <= 0)
        {
            BreakSphere();
        }
    }

    void BreakSphere()
    {
        Debug.Log("Sferona Rottona");
        Destroy(gameObject);
    }
}
