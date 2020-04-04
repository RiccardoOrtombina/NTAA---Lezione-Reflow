using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandAnimController : MonoBehaviour
{
    bool punch;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        InvokeRepeating("ResetPunch", 4, 1.5f);
    }

    public void UsePunch()
    {
        punch = true;
        animator.SetBool("Punch", punch);
    }

    public void ResetPunch()
    {
        punch = false;
        animator.SetBool("Punch", punch);
    }
}
