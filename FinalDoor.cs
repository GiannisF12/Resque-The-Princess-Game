using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalDoor : MonoBehaviour
{
    public Animator FinalAnim;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            if (col.GetComponent<PlayerMovement>().keys > 0)
            {
                col.GetComponent<PlayerMovement>().keys = 0;
                col.GetComponent<PlayerMovement>().enabled = false;
                col.GetComponent<PlayerDamage>().enabled = false;
                FinalAnim.enabled = true;
                this.enabled = false;
            }
        }
    }
}
