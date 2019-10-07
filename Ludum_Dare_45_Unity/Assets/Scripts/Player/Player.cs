using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gun1;
    public GameObject crosshair;
    public float airraidSize;
    public float normalSpriteSize;
    public Sprite normalSprite;
    public Sprite airraidSprite;

    private Camera cam;
    private float cooldownAOE; //Stored in seconds
    private string currentWeapon;
    public string[] gunOptions = new string[4] { "tempRock", "tempGun", "tempAR", "tempMinigun" };
    public int[] upgrades;

    // Start is called before the first frame update
    void Start()
    {
        upgrades = UpgradeManager.GetUpgrades();
        cooldownAOE = 0;
        cam = Camera.main;
        Cursor.visible = false;
        crosshair.GetComponent<SpriteRenderer>().sprite = normalSprite;
        spawnGun("1", gunOptions[upgrades[0]]);
    }

    // Update is called once per frame
    void Update()
    {
        upgrades = UpgradeManager.GetUpgrades();

        //Update AOE cooldown
        if (cooldownAOE > 0)
        {
            cooldownAOE -= Time.deltaTime;
            if (cooldownAOE <= 0) cooldownAOE = 0;
        }

        //Find mouse location
        Vector3 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        //Update crosshair
        crosshair.transform.position = mousePos;

        changeGun("1", gunOptions[upgrades[0]]);

        if (upgrades[3] > 0)
        {
            changeGun("2", "WalkieTalkie");
        }



    }

    public void activateAOE()
    {
        cooldownAOE = 10; //Measured in seconds
    }

    public bool canAOE()
    {
        return cooldownAOE <= 0.001;
    }

    void changeGun(string key, string gunType) // removes all of the guns from the player and spawns a new one
    {
        if (Input.GetKey(key))
        {
            spawnGun(key, gunType);
        }
        
        
    }

    public void spawnGun(string key, string gunType)
    {

        // destroys gun
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // creates weapon
        Instantiate(Resources.Load(gunType), transform);

        currentWeapon = key;

        if (currentWeapon == "2")
        {
            crosshair.GetComponent<SpriteRenderer>().sprite = airraidSprite;
            crosshair.transform.localScale = new Vector3(airraidSize, airraidSize, airraidSize);
        }
        if (currentWeapon == "1")
        {
            crosshair.GetComponent<SpriteRenderer>().sprite = normalSprite;
            crosshair.transform.localScale = new Vector3(normalSpriteSize, normalSpriteSize, normalSpriteSize);
        }

    }
}
