﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject collider = collision.gameObject;
        if (collider.tag == "Bullet")
        {
            Bullet bullet = collider.GetComponent<Bullet>();
            health -= bullet.damage;
            //May need to add some sort of Coroutine in the bullet for destroy animations
            Destroy(bullet.gameObject);
            if (health <= 0)
            {
                //die
            }

        }
    }
}