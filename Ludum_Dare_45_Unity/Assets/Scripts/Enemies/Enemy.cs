using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int cashValue;
    public float health;
    public float attackDamage;
    public float attackRate;
    public float attackRange;
    public float movementRange;
    public float speed;

    private float shotTimer = 0;
    private bool alive = true;
    public GameObject bullet;
    float wallCoord = -6.85F;

    private Animator animator;
    private SpriteRenderer sprite;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (alive)
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
        else
        {
            //Handle death animation
            float otherValues = Mathf.Lerp(sprite.color.b, 0, 0.1f);
            sprite.color = new Color(256, otherValues, otherValues);

            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -90), 0.2f);

            if (transform.rotation.eulerAngles.z <= -88 && otherValues <= 10) Destroy(this); //get rid of the script
        }
        
    }

    public void hurt(int damage)
    {
        health -= damage;
        if (health <= 0) kill();
    }

    private void kill()
    {
        //Add money
        UpgradeManager.money += cashValue;

        //Disable movement
        //Disable attacks
        //Death animation
        animator.enabled = false;
        alive = false;

        //Disable trigger boxes
        GetComponent<Collider2D>().enabled = false;

    }

    private void handleShooting()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer >= attackRate)
        {
            shotTimer = 0;
            //Shoot a bullet
            GameObject bulletFired = Instantiate(bullet, transform.position, Quaternion.Euler(0,0,transform.rotation.eulerAngles.z-180));
            bulletFired.tag = "BasicBullet";
            bulletFired.GetComponent<BasicBullet>().damage = attackDamage;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "FriendlyBullet")
        {
            BasicBullet bullet = collision.GetComponent<BasicBullet>();
            hurt((int) bullet.damage);
            Destroy(collision.gameObject);
        } else if (collision.gameObject.tag == "FriendlyExplosion")
        {
            explosion explosionObj = collision.GetComponent<explosion>();
            hurt((int)explosionObj.damage);
            Destroy(collision.gameObject);
        }
    }
}
