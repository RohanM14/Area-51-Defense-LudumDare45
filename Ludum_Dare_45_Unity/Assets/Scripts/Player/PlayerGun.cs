using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    float damage;
    float fireRate;

    Camera cam;
    GameObject crosshair;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        crosshair = GameObject.Find("Crosshair");
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Find mouse location
        Vector3 mousePos = Input.mousePosition;
        mousePos = cam.ScreenToWorldPoint(mousePos);
        mousePos.z = -1;
        //Update crosshair
        crosshair.transform.position = mousePos;
        Debug.Log(mousePos);
        mousePos.z = 0;

        //find the angle player gun should be facing
        Vector2 lookDir = transform.position - mousePos;

        //Clamp it to a certain range so that you can't shoot backwards
        //change the angle
    }
}
