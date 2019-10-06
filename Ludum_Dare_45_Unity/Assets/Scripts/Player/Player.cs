using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gun1;
    public GameObject crosshair;

    private Camera cam;
    private float cooldownAOE; //Stored in seconds

    // Start is called before the first frame update
    void Start()
    {
        cooldownAOE = 0;
        Instantiate(crosshair);
        cam = Camera.main;
        Cursor.visible = false;
        crosshair = GameObject.Find("Crosshair 1(Clone)");
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

        spawnGun("1", "tempGun");
        spawnGun("2", "tempAR");
        spawnGun("3", "WalkieTalkie");
    }

    public void activateAOE()
    {
        cooldownAOE = 10; //Measured in seconds
    }

    public bool canAOE()
    {
        return cooldownAOE <= 0.001;
    }

    void spawnGun(string key, string gunType) // removes all of the guns from the player and spawns a new one
    {
        if (Input.GetKey(key))
        {
            // destroys gun
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }

            // creates gun
            Instantiate(Resources.Load(gunType), transform);
        }
        
    }
}
