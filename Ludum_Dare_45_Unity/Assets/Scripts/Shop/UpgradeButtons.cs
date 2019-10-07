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
        switch (thisPosition.y)
        {
            case 79.4F:
                upgrade = 1;
                break;
            case 56.5F:
                upgrade = 2;
                break;
            case 31.6F:
                upgrade = 3;
                break;
            case 4.2F:
                upgrade = 4;
                break;
            case -18.9F:
                upgrade = 5;
                break;
            case -42.1F:
                upgrade = 6;
                break;
            case -70.3F:
                upgrade = 7;
                break;
            case -95.3F:
                upgrade = 8;
                break;
            case -120.4F:
                upgrade = 9;
                break;
            default:
                break;
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
