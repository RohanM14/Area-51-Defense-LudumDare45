using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class crosshair : MonoBehaviour
{

    public Sprite normalSprite;
    public Sprite airraidSprite;
    public float airraidSize;
    public float normalSpriteSize;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<SpriteRenderer>().sprite = normalSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("1") || Input.GetKey("2"))
        {
            this.GetComponent<SpriteRenderer>().sprite = normalSprite;
            transform.localScale = new Vector3(normalSpriteSize, normalSpriteSize, normalSpriteSize);
        }

        if (Input.GetKey("3"))
        {
            this.GetComponent<SpriteRenderer>().sprite = airraidSprite;
            transform.localScale = new Vector3(airraidSize, airraidSize, airraidSize);
        }
    }
}
