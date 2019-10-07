using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float health;

    // Start is called before the first frame update
    void Start()
    {
        int level = UpgradeManager.upgrades[6];
        switch(level) {
            case 0:
                break;
            case 1:
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.tag == "BasicBullet")
        {
            BasicBullet bullet = collider.GetComponent<BasicBullet>();
            health -= bullet.damage;
            //May need to add some sort of Coroutine in the bullet for destroy animations
            Destroy(collider);
            if (health <= 0)
            {
                Destroy(gameObject, 0.1f);
            }

        }
    }
}
