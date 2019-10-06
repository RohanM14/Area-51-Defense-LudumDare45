using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBasic : MonoBehaviour
{
    public float damage;
    public float fireTime;
    public float xShootRange; //The x position to stop rotating the gun
    public GameObject bullet;
    public GameObject gunTip;

    private float shotTimer = 0;

    private Vector3 mousePos;

    private GameObject crosshair;

    // Start is called before the first frame update
    void Start()
    {
        crosshair = GameObject.Find("Crosshair(Clone)");
    }

    // Update is called once per frame
    void Update()
    {
        //grabs mouse position from crosshair
        mousePos = crosshair.transform.position;

        //find the angle player gun should be facing
        if (mousePos.x >= xShootRange)
        {
            transform.right = mousePos - transform.position;
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
            Debug.Log(transform.rotation.eulerAngles);
            Instantiate(bullet, gunTip.transform.position, transform.rotation);
        }
    }
}
