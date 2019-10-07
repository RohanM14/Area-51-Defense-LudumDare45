using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
<<<<<<< HEAD
    int currentWave;
    int money;
    int[] upgrades;
=======
    public static int currentWave;
    public static int money;
    public static int[] upgrades;
>>>>>>> 1ce3ed6e873104e64c0f73b39c38eedcb6a34a1f

    // Start is called before the first frame update
    void Start()
    {
        currentWave = 1;
        money = 0;
        upgrades = new int[9];
    }

    public int[] GetUpgrades()
    {
        return upgrades;
    }

    public void IncreaseMoney(int sum)
    {
        money += sum;
    }

    public int GetMoney()
    {
        return money;
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
