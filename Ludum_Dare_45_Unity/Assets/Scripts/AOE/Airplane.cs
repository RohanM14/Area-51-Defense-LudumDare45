using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    public float speed;
    public GameObject crosshair;
    public GameObject bomb;
    private Quaternion bombAngle;
    private bool droppedYet = false;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 10); // Kill self after 10 seconds
        crosshair = GameObject.Find("ScriptLessCrosshair(Clone)").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //Move to the right
        transform.Translate(Vector2.right * Time.deltaTime * speed);

        //Drop bomb
        if (!droppedYet && transform.position.x >= crosshair.transform.position.x - 1)
        {
            droppedYet = true;
            Instantiate(bomb, transform.position, transform.rotation); 
        }
    }

    
}
