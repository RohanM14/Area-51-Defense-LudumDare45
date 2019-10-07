using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallHealthBar : MonoBehaviour
{
    public GameObject wall;
    private float wallHealth;
    private float wallHealthStarter;
    private float starterWidth = 0.9803922f;
    private float starterHeight = 0.7692308f;

    // Start is called before the first frame update
    void Start()
    {
        wallHealthStarter = wall.GetComponent<Wall>().health;
    }

    // Update is called once per frame
    void Update()
    {
        wallHealth = wall.GetComponent<Wall>().health;
        transform.localScale = new Vector3(starterWidth / wallHealthStarter * wallHealth, starterHeight, 1);

        if (wallHealth == 0)
        {
            Destroy(gameObject);
        }
    }
}
