using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    public GameObject CharacterModel;
    public AudioClip keyPickup;

    [HideInInspector]
    public int keys = 0;

    public float Speed = 0f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float HorSpeed = Input.GetAxis("Horizontal");
        float VerSpeed = Input.GetAxis("Vertical");

        if (Mathf.Abs(HorSpeed) + Mathf.Abs(VerSpeed) !=0)
        {
            anim.SetBool("walk", true);
        }
        else
        {
            anim.SetBool("walk", false);
        }

        if (HorSpeed > 0)
        {
            CharacterModel.transform.localScale = new Vector3(-1.069417f, 1.069417f, 1.069417f);
        }
        else if (HorSpeed < 0)
        {
            CharacterModel.transform.localScale = new Vector3(1.069417f, 1.069417f, 1.069417f);
        }

        rb.MovePosition(rb.position + new Vector2(HorSpeed,VerSpeed) * Speed * Time.fixedDeltaTime);

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Key"))
        {
            keys++;
            Destroy(col.gameObject);
            GetComponent<PlayerDamage>().aud.PlayOneShot(keyPickup);
        }
        else if (col.CompareTag("Door"))
        {
            if (keys > 0)
            {
                keys=0;
                Destroy(col.gameObject);
            }
        }
    }
}
