using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{
    int wave = 1;
    public GameObject[] enemyPrefabs;
    private float[] timeBeforeNextSpawn;
    private float[] enemySpawnTimers;

    //Hard coded waves
    private float[] wave1 = {3,0};
    
    // Start is called before the first frame update
    void Start()
    {
        timeBeforeNextSpawn = new float[enemyPrefabs.Length];
        enemySpawnTimers = new float[enemyPrefabs.Length];
        for (int i = 0; i < enemyPrefabs.Length; i++)
        {
            timeBeforeNextSpawn[i] = Random.Range(0f, 2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (wave)
        {
            case 1:
                //3 grunts for first level
                for (int i = 0; i < enemyPrefabs.Length; i++)
                {
                    if (enemySpawnTimers[i] >= timeBeforeNextSpawn[i] && wave1[i] > 0)
                    {
                        spawnEnemy(enemyPrefabs[i]);
                        wave1[i]--;
                        timeBeforeNextSpawn[i] = Random.Range(5f, Random.Range(5f,10f));
                        enemySpawnTimers[i] = 0;
                    }
                    enemySpawnTimers[i] += Time.deltaTime;
                }
                break;
            case 2:
                break;
            default:
                break;
        }
    }

    private void getTime()
    {

    }

    private void spawnEnemy(GameObject enemyToSpawn)
    {
        Vector3 positionToSpawn = transform.position;
        positionToSpawn.y += Random.Range(0f, 3.9f) + 1.1f;
        GameObject enemy = Instantiate(enemyToSpawn, positionToSpawn, transform.rotation);

        //Adjust sorting order
        enemy.GetComponent<SpriteRenderer>().sortingOrder = -(int)(positionToSpawn.y * 10);

        //Adjust scale for perspective
        //0.5 from lowest -- 0.25 to highest
        // slope is (0.25-0.5)/(0--3.9) = -0.0641
        // y=mx+b, b = 0.25
        float scale = -0.0641f * positionToSpawn.y + 0.25f;
        enemy.transform.localScale = new Vector3(scale, scale, 1);

    }

}
