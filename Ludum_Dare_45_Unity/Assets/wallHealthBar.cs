using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallHealthBar : MonoBehaviour
{
    public GameObject wall;
    private float wallHealth;

    private float starterWidth = 0.9803922f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        wallHealth = wall.GetComponent<Wall>().health;
    }
}
