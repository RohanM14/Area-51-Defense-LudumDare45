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
    private bool alive;
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

            //When animation is done, Destroy object
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

        //Disable movement
        //Disable attacks
        //Death animation
        GetComponent<Animator>().StopPlayback();
        alive = false;

        //Disable trigger boxes
        //GetComponent<Collider2D>().disable

    }

    private void handleShooting()
    {
        shotTimer += Time.deltaTime;
        if (shotTimer >= attackRate)
        {
            shotTimer = 0;
            //Shoot a bullet
            Instantiate(bullet, transform.position, Quaternion.Euler(0,0,transform.rotation.eulerAngles.z-180)).tag = "BasicBullet";
            
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FriendlyBullet")
        {
            BasicBullet bullet = collision.GetComponent<BasicBullet>();
            //hurt(bullet.damage);
            Destroy(collision);
        }
    }
}
