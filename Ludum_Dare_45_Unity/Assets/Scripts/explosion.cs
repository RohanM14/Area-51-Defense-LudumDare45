using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float damage;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1); // suicides after 1 second
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
