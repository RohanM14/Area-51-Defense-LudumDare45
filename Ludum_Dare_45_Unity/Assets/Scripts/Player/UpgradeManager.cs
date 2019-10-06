using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    int currentWave;
    int money;
    int[] upgrades = new int[6];
    int wallLevel;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        currentWave = 1;
        money = 0;
        upgrades = new int[6];
        wallLevel = 0;
    }

    public int[] getUpgrades()
    {
        return upgrades;
    }

    public int getWall()
    {
        return wallLevel;
    }

    public void upgradeWall()
    {
        wallLevel++;
    }
    public void upgrade(int slot)
    {
        upgrades[slot] = upgrades[slot] + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
