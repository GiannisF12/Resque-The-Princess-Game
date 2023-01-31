using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject Level, EndLevelPre;

    private GameObject preFinalLevel;
    Vector2 LevelSpawn;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GenMap());
    }

    IEnumerator GenMap()
    {
        LevelSpawn = new Vector2(0, 0);
        for (int i = 0; i < 10; i++)
        {
            GameObject level = Instantiate(Level, LevelSpawn, Quaternion.identity);
            level.GetComponent<LevelRandomizer>().id = i + 1;
            if (i == 9)
            {
                level.GetComponent<LevelRandomizer>().DoorRight.SetActive(true);
            }
            else if (i == 0)
            {
                level.GetComponent<LevelRandomizer>().DoorLeft.tag = "Untagged";
            }
            level.GetComponent<LevelRandomizer>().DoorLeft.SetActive(true);
            LevelSpawn.x += 10;
            if (i == 9)
            {
                preFinalLevel = level;
            }
            yield return new WaitForSeconds(0.5f);
        }
        GameObject finalLevel = Instantiate(EndLevelPre, LevelSpawn, Quaternion.identity);
        preFinalLevel.GetComponent<LevelRandomizer>().DoorRight.GetComponent<FinalDoor>().FinalAnim = finalLevel.GetComponent<Animator>();
    }

}
