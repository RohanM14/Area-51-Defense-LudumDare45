using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeButtons : MonoBehaviour
{

    public Button button;
    public GameObject level;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Text text = GetComponentInChildren<Text>();
        if (text.text.Equals("$100"))
        {
            text.text = "$300";
            level.GetComponent<SpriteRenderer>().sprite = sprite1;
        }
        else if (text.text.Equals("$300"))
        {
            text.text = "$500";
            level.GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        else if (text.text.Equals("$500"))
        {
            text.text = "Max";
            level.GetComponent<SpriteRenderer>().sprite = sprite3;
            button.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
