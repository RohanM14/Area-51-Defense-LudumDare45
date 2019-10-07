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
    public Sprite ammoSprite;
    public bool isRock;

    public Player playerHand;


    private float shotTimer;

    private Vector3 mousePos;

    private GameObject crosshair;

    private bool shooting;

    // Start is called before the first frame update
    void Start()
    {
        playerHand = GameObject.Find("Player Hand").GetComponent<Player>();
        crosshair = playerHand.crosshair;
        shotTimer = fireTime - 0.25f; // Delay shooting for 0.25 seconds when switching weapons
    }

    // Update is called once per frame
    void Update()
    {

        //grabs mouse position from crosshair
        mousePos = crosshair.transform.position;

        //find the angle player gun should be facing
        if (mousePos.x >= xShootRange)
        {
            transform.right = mousePos - gunTip.transform.position;
        }

        shooting = Input.GetMouseButton(0);

        handleShooting();
    }

    private void handleShooting()
    {
        if (shotTimer >= fireTime && shooting)
        {
            shotTimer = 0;
            //Shoot a bullet
            GameObject bulletFired = Instantiate(bullet, gunTip.transform.position, transform.rotation);
            bulletFired.GetComponent<SpriteRenderer>().sprite = ammoSprite;
            bulletFired.tag = "FriendlyBullet";
            bulletFired.GetComponent<BasicBullet>().damage = damage;
            if (isRock)
            {
                bulletFired.transform.localScale = new Vector3(0.1f,0.1f,1f);
            }
        }
        shotTimer += Time.deltaTime;
    }
}
