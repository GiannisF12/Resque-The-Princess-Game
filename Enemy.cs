using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{

    public Transform Target;

    private bool Attack;
    private float IdleTime=1;
    public float WaitingTime = 1.5f;
    public float Speed = 10f;
    private Animator anim;
    private Rigidbody2D rb;
    public float Damage = 10;

    public float Health = 100;
    public Slider healthBar;
    public GameObject healthBarObj,HealthPotion;
    public bool Alive = true;

    public float KnockbackPower = 30;
    public float HealthBarTime = 2f;
    private float HideHealthTime = 0;

    private AudioSource aud;
    public AudioClip damaged;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        healthBar.maxValue = Health;
        healthBar.value = Health;
        healthBar.enabled = false;
    }

    // Update is called once per frame

    private void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, Target.position) > 0.5f && IdleTime <= 0)
        {
            Attack = false;
            if (Vector2.Distance(transform.position, Target.position) < 3.5f)
            {
                rb.MovePosition(Vector2.MoveTowards(transform.position, Target.position, Speed * Time.fixedDeltaTime));
                anim.SetBool("walk", true);
            }
            else
            {
                anim.SetBool("walk", false);
            }
        }
        else
        {
            if (IdleTime <= 0)
            {
                Attack = true;
            }
        }
    }
    void Update()
    {
        //HealthBarSlider
        if (HideHealthTime > 0)
        {
            if (!healthBarObj.activeInHierarchy)
            {
                healthBarObj.SetActive(true);
            }
            HideHealthTime -= Time.deltaTime;
        }
        else
        {
            if (healthBarObj.activeInHierarchy)
            {
                healthBarObj.SetActive(false);
            }
        }
        if (healthBar.value != Health)
        {
            healthBar.value = Health;
        }

        //KnockBack
        if (rb.velocity.x > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x - 10 * Time.deltaTime, rb.velocity.y);
        }
        else if (rb.velocity.x < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x + 10 * Time.deltaTime, rb.velocity.y);
        }
        if (rb.velocity.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - 10 * Time.deltaTime);
        }
        else if (rb.velocity.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y + 10 * Time.deltaTime);
        }


        if (IdleTime <= 0)
        {
            rb.velocity = new Vector2(0, 0);
        }
        if (Target)
        {
            //Audio
            if (!aud)
            {
                aud = Target.GetComponent<PlayerDamage>().aud;
            }

            //Health
            if (Health <= 0)
            {
                anim.Play("Death", 0);
                GetComponent<Enemy>().enabled = false;
                rb.bodyType = RigidbodyType2D.Static;
                GetComponent<CircleCollider2D>().enabled = false;
                healthBarObj.SetActive(false);
                Alive = false;
                if (Random.Range(0, 2) == 1)
                {
                    Instantiate(HealthPotion, transform.position, Quaternion.identity);
                }
            }

            //Flip
            if (Target.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (Target.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }


            //Chase and Attack


            if (IdleTime > 0)
            {
                IdleTime -= Time.deltaTime;
                anim.SetBool("walk", false);
                anim.SetBool("attack", false);
            }
     
            if (Attack==true && IdleTime<=0 && Vector2.Distance(transform.position, Target.position) <= 0.5f)
            {
                anim.SetBool("walk", false);
                anim.SetBool("attack", true);
                IdleTime = WaitingTime;
            }


        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("PWeapon"))
        {
            Health -= 10f;
            HideHealthTime = HealthBarTime;
            aud.pitch = Random.Range(0.90f, 1.11f);
            aud.PlayOneShot(damaged);
            anim.Play("Damaged", 0);
            IdleTime = 0.5f;
            Attack = false;
            rb.AddForce((transform.position - Target.transform.position)* KnockbackPower*100 * Time.fixedDeltaTime,ForceMode2D.Impulse);
        }
    }
}
