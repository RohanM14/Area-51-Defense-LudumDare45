using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnManager : MonoBehaviour
{

    int wave = 1;
    public GameObject[] enemyPrefabs;
    private float[] timeBeforeNextSpawn;
    private float[] enemySpawnTimers;

    private List<GameObject> enemies;

    //Hard coded waves
    private int[] wave1 = {3,0};
    private int[] wave2 = { 6, 3 };
    private int[] wave3 = { 10, 7};

    private float[] waveNBase = {4,3 };
    private float[] waveNTimeScale;
    private int[] waveN;
    
    // Start is called before the first frame update
    void Start()
    {
        wave = UpgradeManager.currentWave;
        if (wave == 0) wave = 1; //For testing from battle scene
        enemies = new List<GameObject>();
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
                        wave1[i] -= 1;
                        timeBeforeNextSpawn[i] = Random.Range(5f, Random.Range(5f,10f));
                        enemySpawnTimers[i] = 0;
                    }
                    enemySpawnTimers[i] += Time.deltaTime;
                }
                break;
            case 2:
                for (int i = 0; i < enemyPrefabs.Length; i++)
                {
                    if (enemySpawnTimers[i] >= timeBeforeNextSpawn[i] && wave2[i] > 0)
                    {
                        spawnEnemy(enemyPrefabs[i]);
                        wave2[i] -= 1;
                        timeBeforeNextSpawn[i] = Random.Range(2f, Random.Range(2f, 10f));
                        enemySpawnTimers[i] = 0;
                    }
                    enemySpawnTimers[i] += Time.deltaTime;
                }
                break;
            case 3:
                for (int i = 0; i < enemyPrefabs.Length; i++)
                {
                    if (enemySpawnTimers[i] >= timeBeforeNextSpawn[i] && wave3[i] > 0)
                    {
                        spawnEnemy(enemyPrefabs[i]);
                        wave3[i] -= 1;
                        timeBeforeNextSpawn[i] = Random.Range(1f, Random.Range(1f, 10f));
                        enemySpawnTimers[i] = 0;
                    }
                    enemySpawnTimers[i] += Time.deltaTime;
                }
                break;
            default:
                for (int i = 0; i < enemyPrefabs.Length; i++)
                {
                    if (enemySpawnTimers[i] >= timeBeforeNextSpawn[i] && waveN[i] > 0)
                    {
                        spawnEnemy(enemyPrefabs[i]);
                        waveN[i] -= 1;
                        timeBeforeNextSpawn[i] = Random.Range(0f, Random.Range(0f, waveNTimeScale[i]));
                        enemySpawnTimers[i] = 0;
                    }
                    enemySpawnTimers[i] += Time.deltaTime;
                }
                break;
        }
    }

    public void setupWave(int wave)
    {
        waveN = new int[waveNBase.Length];
        waveNTimeScale = new float[waveN.Length];
        for (int i = 0; i < waveN.Length; i++)
        {
            waveN[i] = (int)(waveNBase[i] * wave);
            waveNTimeScale[i] = 30f / waveN[i];
        }
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
        enemy.GetComponent<Enemy>().spawnManager = this;

        enemies.Add(enemy);
    }

    public void enemyDie(GameObject enemy)
    {
        enemies.Remove(enemy);
        bool finishedGame = true;
        if (enemies.Count > 0)
        {
            finishedGame = false;
        }
        else
        {
            if (wave == 1)
            {
                for (int i = 0; i < wave1.Length; i++)
                {
                    if (wave1[i] > 0) finishedGame = false;
                }
            }
            else if (wave == 2)
            {
                for (int i = 0; i < wave2.Length; i++)
                {
                    if (wave2[i] > 0) finishedGame = false;
                }
            }
            else if (wave == 3)
            {
                for (int i = 0; i < wave3.Length; i++)
                {
                    if (wave3[i] > 0) finishedGame = false;
                }
            }
            else
            {
                for (int i = 0; i < waveN.Length; i++)
                {
                    if (waveN[i] > 0) finishedGame = false;
                }
            }

        }
        if (finishedGame)
        {
            //Finish
            Debug.Log("GAME FINISHED");
            StartCoroutine(GameObject.Find("Canvas").GetComponent<EndGameCanvasController>().endGame(true));
        }
        
    }

}
