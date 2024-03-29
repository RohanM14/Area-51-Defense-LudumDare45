﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{

    public static int currentWave;
    public static int money;
    public static int[] upgrades = new int[9];
    private static int gun1 = 10;
    public AudioClip BGM;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = 1;
        DontDestroyOnLoad(this.gameObject);
    }
    
    public static int[] GetUpgrades()
    {
        return upgrades;
    }

    public static void Upgrade(int slot)
    {
        upgrades[slot] = upgrades[slot] + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
