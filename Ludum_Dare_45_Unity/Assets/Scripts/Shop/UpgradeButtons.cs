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
    public string upgradedItem;

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
        if (text.text.Equals("$100") && currentMoney >= 100)
        {
            text.text = "$300";
            UpgradeManager.money = currentMoney - 100;
            level.GetComponent<Image>().sprite = sprite1;
            UpgradeManager.upgradeWeapon(upgradedItem);
        }
        else if (text.text.Equals("$300") && currentMoney >= 300)
        {
            text.text = "$500";
            UpgradeManager.money = currentMoney - 300;
            level.GetComponent<Image>().sprite = sprite2;
            UpgradeManager.upgradeWeapon(upgradedItem);
        }
        else if (text.text.Equals("$500") && currentMoney >= 500)
        {
            text.text = "Max";
            UpgradeManager.money = currentMoney - 500;
            level.GetComponent<Image>().sprite = sprite3;
            UpgradeManager.upgradeWeapon(upgradedItem);
            button.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
