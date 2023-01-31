using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour
{
    private SpriteRenderer grass;
    // Start is called before the first frame update
    void Start()
    {
        grass = GetComponent<SpriteRenderer>();
        grass.color = new Color(Random.Range(0.0f, 1), Random.Range(0.0f, 1), Random.Range(0.0f, 1));
    }
}
