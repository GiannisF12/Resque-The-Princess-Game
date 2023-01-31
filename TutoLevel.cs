using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutoLevel : MonoBehaviour
{
    public PlatformTuto[] PT;
    public Animator anim;
    private bool Phase1 = false;
    public GameObject Enemy;

    [HideInInspector]
    public GameObject TutoEnemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        int k = 0;
        foreach(PlatformTuto pressedStatus in PT)
        {
            if (pressedStatus.pressed)
            {
                k++;
            }
        }
        if (k == 4 && !Phase1)
        {
            Phase1 = true;
            anim.Play("TutoContinue", 0);
            TutoEnemy = Instantiate(Enemy, new Vector2(transform.position.x - 1 + Random.Range(-3.0f, 4.0f), transform.position.y + Random.Range(-3.0f, 4.0f)), Quaternion.identity);
            TutoEnemy.GetComponent<Enemy>().Damage = 0;
        }
        if (TutoEnemy)
        {
            if (!TutoEnemy.GetComponent<Enemy>().Alive)
            {
                anim.Play("EndTuto", 0);
                this.enabled = false;
            }
        }
    }
}
