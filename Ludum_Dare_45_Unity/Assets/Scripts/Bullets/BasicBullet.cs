﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicBullet : MonoBehaviour
{
    public float speed;
    public float timeToDie;
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, timeToDie);
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector2.right * speed);
    }

}
