using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float health;
    public float attackDamage;
    public float attackRate;
    public float attackRange;
    public float movementRange;
    public float speed;
    public class damage
    {
        public float attackDamage;
    }

    private float shotTimer = 0;
    public GameObject bullet;
    float wallCoord = -6.85F;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Moves the enemy left at speed.
        if (transform.position.x - wallCoord >= movementRange)
        {
            Vector3 temp = new Vector3(speed, 0, 0);
            transform.position -= temp;
        }

        // if within firing range, starts firing.
        if (transform.position.x - wallCoord < attackRange)
        {
            handleShooting();
        }
    }

    private void handleShooting()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer >= attackRate)
        {
            shotTimer = 0;
            //Shoot a bullet
            Instantiate(bullet, transform.position, Quaternion.Euler(0,0,transform.rotation.eulerAngles.z-180), gameObject.transform).tag = "BasicBullet";
            
        }
    }
}
