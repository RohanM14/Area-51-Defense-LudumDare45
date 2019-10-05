using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public float damage;
    public float fireTime;
    public float xShootRange; //The x position to stop rotating the gun
    public GameObject bullet;

    private float shotTimer = 0;

    private Camera cam;
    private GameObject crosshair;
    private GameObject barrel;
    
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        crosshair = GameObject.Find("Crosshair");
        barrel = transform.Find("Barrel").gameObject;
        Cursor.visible = false;
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

        //find the angle player gun should be facing
        if (mousePos.x >= xShootRange)
        {
            barrel.transform.right = mousePos - barrel.transform.position;
        }

        handleShooting();
    }

    private void handleShooting()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer >= fireTime && Input.GetMouseButton(0))
        {
            shotTimer = 0;
            //Shoot a bullet
            Debug.Log(barrel.transform.rotation.eulerAngles);
            Instantiate(bullet, transform.position, barrel.transform.rotation);
        }
    }
}
