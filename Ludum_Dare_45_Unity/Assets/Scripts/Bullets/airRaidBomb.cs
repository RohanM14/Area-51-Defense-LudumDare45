using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class airRaidBomb : MonoBehaviour
{
    public GameObject crosshair;
    public float speed;
    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        // finds the crosshair target
        crosshair = GameObject.Find("ScriptLessCrosshair(Clone)").gameObject;

        // points the bomb at the crosshair target
        transform.LookAt(crosshair.transform,Vector3.right);
        transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, crosshair.transform.position, speed);
    }
}
