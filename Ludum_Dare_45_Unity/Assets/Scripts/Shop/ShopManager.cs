using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public Sprite[] sprites;
    public GameObject upgradeButtonsFolder;
    public GameObject upgradeCirclesFolder;
    public Text moneyText;

    private Image[] images;
    private Text[] buttonText;

    private int[] buttonCosts;
    private int money;
    // Start is called before the first frame update
    void Start()
    {
        moneyText.text = "Money: " + UpgradeManager.money;
        images = upgradeCirclesFolder.GetComponentsInChildren<Image>();
        buttonText = upgradeButtonsFolder.GetComponentsInChildren<Text>();
        buttonCosts = new int[9];
        int[] upgradeLevels = UpgradeManager.GetUpgrades();
        for (int i = 0; i < buttonCosts.Length; i++)
        {
            updateGraphics(i);
        }

        
    }

    private void updateGraphics(int num)
    {
        moneyText.text = "Money: " + UpgradeManager.money;
        switch (UpgradeManager.upgrades[num])
        {
            case 0:
                buttonCosts[num] = 100;
                buttonText[num].text = "100";
                images[num].sprite = sprites[0];
                break;
            case 1:
                buttonCosts[num] = 300;
                buttonText[num].text = "300";
                images[num].sprite = sprites[1];
                break;
            case 2:
                buttonCosts[num] = 500;
                buttonText[num].text = "500";
                images[num].sprite = sprites[2];
                break;
            case 3:
                buttonCosts[num] = -1;
                buttonText[num].text = "N/A";
                images[num].sprite = sprites[3];
                break;
        }
    }

    public void buy(int button)
    {
        if (UpgradeManager.money >= buttonCosts[button] && UpgradeManager.GetUpgrades()[button] < 3)
        {
            if (button == 0 && UpgradeManager.GetUpgrades()[button] == 2)
                upgradeButtonsFolder.transform.Find("0").GetComponent<Button>().interactable = false;
            if (button == 3 && UpgradeManager.GetUpgrades()[button] == 0)
                upgradeButtonsFolder.transform.Find("3").GetComponent<Button>().interactable = false;
            if (button == 6 && UpgradeManager.GetUpgrades()[button] == 2)
                upgradeButtonsFolder.transform.Find("6").GetComponent<Button>().interactable = false;
            UpgradeManager.money -= buttonCosts[button];
            UpgradeManager.GetUpgrades()[button] += 1;
            updateGraphics(button);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
