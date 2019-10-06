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

    private float shotTimer;

    private Vector3 mousePos;

    private GameObject crosshair;

    private bool shooting;

    // Start is called before the first frame update
    void Start()
    {
        crosshair = GameObject.Find("Crosshair(Clone)");
        shotTimer = fireTime;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Switch complete");

        //grabs mouse position from crosshair
        mousePos = crosshair.transform.position;

        //find the angle player gun should be facing
        if (mousePos.x >= xShootRange)
        {
            transform.right = mousePos - gunTip.transform.position;
        }

        shooting = Input.GetMouseButton(0);

        Debug.Log("GetMouseButton");
        Debug.Log(shooting);

        handleShooting();
    }

    private void handleShooting()
    {
        if (shotTimer >= fireTime && shooting)
        {
            shotTimer = 0;
            //Shoot a bullet
            Debug.Log(transform.rotation.eulerAngles);
            Instantiate(bullet, gunTip.transform.position, transform.rotation);
        }
        shotTimer += Time.deltaTime;
    }
}
