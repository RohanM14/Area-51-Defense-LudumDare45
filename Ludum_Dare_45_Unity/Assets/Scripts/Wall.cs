using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float health;
    public Sprite fence;
    public Sprite concrete;
    public Sprite alien;

    // Start is called before the first frame update
    void Start()
    {
        int level = UpgradeManager.upgrades[6];
        switch(level) {
            case 0:
                this.GetComponent<SpriteRenderer>().sprite = null;
                health = 5f;
                break;
            case 1:
                this.GetComponent<SpriteRenderer>().sprite = fence;
                health = 9f;
                break;
            case 2:
                this.GetComponent<SpriteRenderer>().sprite = concrete;
                health = 15f;
                break;
            case 3:
                this.GetComponent<SpriteRenderer>().sprite = alien;
                health = 30f;
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
                StartCoroutine(GameObject.Find("Canvas").GetComponent<EndGameCanvasController>().endGame(false));
                Destroy(gameObject, 0.1f);
            }

        }
    }
}
