using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformTuto : MonoBehaviour
{
    private Animator anim;

    public bool pressed = false;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            anim.SetBool("pressed", true);
            pressed = true;
        }
    }
}
