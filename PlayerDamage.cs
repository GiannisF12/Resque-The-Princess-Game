using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour
{

    public bool defense;
    private Animator anim;
    public Slider HealthSlider,HealthSliderEffect;
    public float Health = 100;
    public AudioSource aud;
    public AudioClip swing,damaged,PickHealthSound;
    public GameObject DeathCanvas;

    private void Start()
    {
        anim = GetComponent<Animator>();
        HealthSlider.maxValue = Health;
        HealthSliderEffect.maxValue = Health;
    }

    public void Update()
    {
        //HealthBar
        if (HealthSlider.value != Health)
        {
            HealthSlider.value = Health;
        }
        if (HealthSliderEffect.value > HealthSlider.value)
        {
            HealthSliderEffect.value -= Time.deltaTime * 50;
        }
        else
        {
            HealthSliderEffect.value = Health;
        }
        //Attack
        if (Input.GetMouseButtonDown(0))
        {
            anim.SetBool("attack", true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            anim.SetBool("attack", false);
        }

        //Death
        if (Health <= 0)
        {
            DeathCanvas.SetActive(true);
            GetComponent<PlayerMovement>().enabled = false;
            this.enabled = false;
        }


            //Defense
        if (Input.GetMouseButton(1))
        {
            defense = true;
            anim.SetBool("defense", true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            defense = false;
            anim.SetBool("defense", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("weapon"))
        {
            if (!defense)
            {
                Health -= col.GetComponentInParent<Enemy>().Damage;
                anim.Play("DamagePlayer", 1);
                aud.pitch = Random.Range(0.90f, 1.11f);
                aud.PlayOneShot(damaged);
            }
        }
    }

    public void AttackSound()
    {
        aud.pitch = Random.Range(0.90f, 1.11f);
        aud.PlayOneShot(swing);
    }
}
