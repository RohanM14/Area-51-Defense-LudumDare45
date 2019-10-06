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

    // Start is called before the first frame update
    void Start()
    {
        cooldownAOE = 0;
        crosshair = Instantiate(crosshair);
        cam = Camera.main;
        Cursor.visible = false;
        crosshair.GetComponent<SpriteRenderer>().sprite = normalSprite;
    }

    // Update is called once per frame
    void Update()
    {
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

        changeGun("1", "tempGun");
        changeGun("2", "tempAR");
        changeGun("3", "WalkieTalkie");
        if ((currentWeapon == "3") && (Input.GetMouseButtonDown(0))) {
            spawnGun("1", "tempGun");
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

    void spawnGun(string key, string gunType)
    {
        // destroys gun
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        // creates weapon
        Instantiate(Resources.Load(gunType), transform);

        currentWeapon = key;

        if (currentWeapon == "3")
        {
            crosshair.GetComponent<SpriteRenderer>().sprite = airraidSprite;
            crosshair.transform.localScale = new Vector3(airraidSize, airraidSize, airraidSize);
        }
        if (currentWeapon == "1" || currentWeapon == "2")
        {
            crosshair.GetComponent<SpriteRenderer>().sprite = normalSprite;
            crosshair.transform.localScale = new Vector3(normalSpriteSize, normalSpriteSize, normalSpriteSize);
        }

    }
}
