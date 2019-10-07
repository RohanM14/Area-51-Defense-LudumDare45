using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{


    int currentWave;
    public static int money;
    public static string gun1Level = "tempRock";
    int[] upgrades;

    private static int gun1 = 1;

    // Start is called before the first frame update
    void Start()
    {
        currentWave = 1;
    }

    // upgrades levels based off input from upgradebuttons
    public static void upgradeWeapon(string upgradedItem)
    {
        if (upgradedItem == "gun1Level")
        {
            gun1 += 2;
            if (gun1 == 2)
            {
                gun1Level = "testGun";
            }
            else if (gun1 == 3)
            {
                gun1Level = "testAR";
            }
        }
    }

    public int[] GetUpgrades()
    {
        return upgrades;
    }

    public void Upgrade(int slot)
    {
        upgrades[slot] = upgrades[slot] + 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
