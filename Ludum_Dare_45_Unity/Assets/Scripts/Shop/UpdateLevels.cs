using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLevels : MonoBehaviour
{
    public static Sprite[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        int upgradeNum = int.Parse(gameObject.name.Substring(12, 1));
        Image image = GetComponent<Image>();
        //image.sprite = sprites[UpgradeManager.GetUpgrades()];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
