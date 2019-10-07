using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UpgradeButtons : MonoBehaviour
{

    public Button button;
    public GameObject level;
    public Sprite sprite1;
    public Sprite sprite2;
    public Sprite sprite3;

    private int currentMoney;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = button.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        currentMoney = UpgradeManager.money;
        Vector2 thisPosition = EventSystem.current.currentSelectedGameObject.GetComponent<Transform>().localPosition;
        Text text = GetComponentInChildren<Text>();
        if (text.text.Equals("$100") && currentMoney >= 100)
        {
            text.text = "$300";
            UpgradeManager.money = currentMoney - 100;
            level.GetComponent<SpriteRenderer>().sprite = sprite1;
        }
        else if (text.text.Equals("$300") && currentMoney >= 300)
        {
            text.text = "$500";
            UpgradeManager.money = currentMoney - 300;
            level.GetComponent<SpriteRenderer>().sprite = sprite2;
        }
        else if (text.text.Equals("$500") && currentMoney >= 500)
        {
            text.text = "Max";
            UpgradeManager.money = currentMoney - 500;
            level.GetComponent<SpriteRenderer>().sprite = sprite3;
            button.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
