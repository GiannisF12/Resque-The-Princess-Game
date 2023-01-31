using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveTuto : MonoBehaviour
{
    public GameObject mapGen, tutoLevel;
    
    public void StartGame()
    {
        mapGen.SetActive(true);
        Destroy(tutoLevel.GetComponent<TutoLevel>().TutoEnemy);
        Destroy(tutoLevel);
    }
}
