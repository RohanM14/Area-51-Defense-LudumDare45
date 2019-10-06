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
                    if (enemySpawnTimers[i] >= timeBeforeNextSpawn[i])
                    {
                        if (wave1[i] > 0)
                        { 
                            spawnEnemy(enemyPrefabs[i]);
                            wave1[i]--;
                        }
                        
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

    }

}
