using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradeButtons : MonoBehaviour
{

    public Button button;
    public GameObject level;
    private int upgrade;
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
        Vector2 thisPosition = EventSystem.current.currentSelectedGameObject.GetComponent<Transform>().localPosition;
        Debug.Log(thisPosition);
        if (thisPosition.y > 70F)
        {
            upgrade = 1;
        }
        else if (thisPosition.y > 50)
        {
            upgrade = 2;
        }
        else if (thisPosition.y > 30)
        {
            upgrade = 3;
        }
        else if (thisPosition.y > 0)
        {
            upgrade = 4;
        }
        else if (thisPosition.y > -20)
        {
            upgrade = 5;
        }
        else if (thisPosition.y > -45)
        {
            upgrade = 6;
        }
        else if (thisPosition.y > -80)
        {
            upgrade = 7;
        }
        else if (thisPosition.y > -100)
        {
            upgrade = 8;
        }
        else if (thisPosition.y > -130)
        {
            upgrade = 9;
        }
        Text text = GetComponentInChildren<Text>();
        if (text.text.Equals("$100"))
        {
            text.text = "$300";
            level.GetComponent<Image>().sprite = sprite1;
            Debug.Log(upgrade);
        }
        else if (text.text.Equals("$300"))
        {
            text.text = "$500";
            level.GetComponent<Image>().sprite = sprite2;
            Debug.Log(upgrade);
        }
        else if (text.text.Equals("$500"))
        {
            text.text = "Max";
            level.GetComponent<Image>().sprite = sprite3;
            button.interactable = false;
            Debug.Log(upgrade);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
