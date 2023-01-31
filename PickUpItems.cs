using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItems : MonoBehaviour
{
    public PlayerDamage player;
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("HealthPotion"))
        {
            Destroy(col.gameObject);
            player.aud.PlayOneShot(player.PickHealthSound);
            if (player.Health <= 90)
            {
                player.Health += 10;
            }
            else
            {
                player.Health = 100;
            }
        }
    }
}
