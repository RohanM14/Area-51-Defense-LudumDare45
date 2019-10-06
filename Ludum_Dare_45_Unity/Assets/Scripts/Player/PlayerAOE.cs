using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAOE : MonoBehaviour
{
    public GameObject scriptLessCrosshair;
    private GameObject spawnLocation;
    public GameObject attackAOE;

    private Player player;

    // Start is called before the first frame update
    void Start()
    {
        spawnLocation = transform.Find("AirplaneSpawnLocation").gameObject;
        player = GetComponentInParent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("HELP ME");
        //Handle Activating the AOE
        Debug.Log(player.canAOE());
        Debug.Log(Input.GetMouseButtonDown(0));
        if (player.canAOE() && Input.GetMouseButtonDown(0))
        {
            player.activateAOE(); //Sets up the cooldown (nothing else)
            //Instantiate(attackAOE, spawnLocation.transform.position, Quaternion.Euler(0,0,0));
            //Copy crosshair object and leave it there
            Debug.Log("bruh");
            GameObject copyCrosshair = Instantiate(scriptLessCrosshair,
                player.crosshair.transform.position, player.crosshair.transform.rotation);
            //attackAOE.getComponent<Airplane>().crosshair = copyCrosshair;

            //Change back to another weapon
        }
    }
}