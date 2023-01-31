using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRandomizer : MonoBehaviour
{
    public SpriteRenderer Walls, Floorl;
    public GameObject Grass,DoorLeft,DoorRight,Enemys,Enemys2,Key;
    public List<GameObject> enemys;

    [HideInInspector]
    public int id;

    public float reSizeSpeed = 10f;
    private bool done = false;
    // Instantiate : Kanoume spawn items
    // Quanterion : Na spwnnaroun oi antipaloi me mhdeniko rotation
    void Start()
    {
        Walls.color = new Color(Random.Range(0.0f, 1), Random.Range(0.0f, 1), Random.Range(0.0f, 1));
        Floorl.color = new Color(Random.Range(0.0f, 1), Random.Range(0.0f, 1), Random.Range(0.0f, 1));
        int k = Random.Range(7, 36);
        for (int j = 0; j < k; j++)
        {
            GameObject grass = Instantiate(Grass, new Vector2(transform.position.x-1 + Random.Range(-3.0f, 4.0f), transform.position.y + Random.Range(-3.0f, 4.0f)), Quaternion.identity);
            grass.transform.localScale = new Vector3(1, 1, 1);
        }
        Invoke("SpawnMobs", 2f);
    }

    public void SpawnMobs()
    {
        int enemysCount = Random.Range(2, 9);
        for (int j = 0; j < enemysCount; j++)
        {
            GameObject en = Instantiate(Enemys, new Vector2(transform.position.x - 1 + Random.Range(-3.0f, 4.0f), transform.position.y + Random.Range(-3.0f, 3.5f)), Quaternion.identity);
            enemys.Add(en);
        }
        if (id >= 5)
        {
            if (Random.Range(0, 3) != 2)
            {
                int GearedenemysCount = Random.Range(1, 4);
                for (int i = 0; i < GearedenemysCount; i++)
                {
                    GameObject en2 = Instantiate(Enemys2, new Vector2(transform.position.x - 1 + Random.Range(-3.0f, 4.0f), transform.position.y + Random.Range(-3.0f, 3.5f)), Quaternion.identity);
                    enemys.Add(en2);
                }
            }
        }
        done = true;
    }

    private void Update()
    {
        if(transform.localScale.x< 1.15f)
        {
            transform.localScale = new Vector3(transform.localScale.x + reSizeSpeed * Time.deltaTime, transform.localScale.y + reSizeSpeed * Time.deltaTime, transform.localScale.z + reSizeSpeed * Time.deltaTime);
        }
        else
        {
            transform.localScale = new Vector3(1.15068f, 1.15068f, 1.15068f);
        }
        int NumAlives = 0;
        foreach(GameObject enemyPawns in enemys)
        {
            if (enemyPawns.GetComponent<Enemy>().Alive)
            {
                NumAlives++;
            }
        }
        if (NumAlives <= 0 && done)
        {
            Instantiate(Key, new Vector2(transform.position.x - 1 + Random.Range(-3.0f, 4.0f), transform.position.y + Random.Range(-3.0f, 4.0f)), Quaternion.identity);
            this.enabled = false;
        }
    }
}
