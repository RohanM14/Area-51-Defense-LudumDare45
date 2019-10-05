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
    float wallCoord = -6.85F;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x - wallCoord >= movementRange)
        {
            Vector3 temp = new Vector3(speed, 0, 0);
            transform.position -= temp;
        }
        if (transform.position.x - wallCoord >= attackRange)
        {

        }
    }
}
