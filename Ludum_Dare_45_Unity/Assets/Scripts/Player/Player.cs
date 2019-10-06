using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject gun1;
    public GameObject crosshair;

    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(crosshair);
        cam = Camera.main;
        Cursor.visible = false;
        crosshair = GameObject.Find("Crosshair(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        //Find mouse location
        Vector3 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;

        //Update crosshair
        crosshair.transform.position = mousePos;

        spawnGun("1", "tempGun");
        spawnGun("2", "tempAR");
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
