using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    int money;
    int[] upgrades = new int[9];

    public int[] getUpgrades()
    {
        return upgrades;
    }

    public void upgrade(int slot)
    {
        upgrades[slot] = upgrades[slot] + 1;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
