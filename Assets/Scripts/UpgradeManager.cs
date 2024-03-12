using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpgradeManager : MonoBehaviour
{
    public TMP_Text budget;
    public TMP_Text itemName;
    public TMP_Text itemDesc;
    public GameObject errorBox;
    public TMP_Text errorMessage;

    public GameObject buyButton;
    public GameObject equipButton;
    public GameObject equipped;
    public GameObject nextButton;
    public GameObject previousButton;
    public GameObject playButton;

    public GameObject[] guns = new GameObject[3];
    private string[] gunNames = {
        "Machine Gun",
        "Anti-Tank Gun",
        "Sniper",
        "Energy Shield"
    };
    private string[] gunDescs = {
        "A versatile automatic gun with a high rate of fire\n\nDamage: 20\nFire Rate: 6\nCost: $400",
        "Increased damage with a slow rate of fire\n\nDamage: 50\nFire Rate: 1\nCost: $650",
        "Very high damage with a very slow rate of fire\n\nDamage: 115\nFire Rate: 0.50\nCost: $1000",
        "An energy shield which blocks all damage from guns. Heavy ordinance such as rockets will have their damage reduced\n\nDamage Reduction: 80\n\nCost: $1000000"
    };
    private int[] gunPrices = {
        400, 650, 1000, 1000000
    };

    private int selected = 0;

    // Start is called before the first frame update
    void Start()
    {
        SetDesc();
        DisplayGun();
        errorBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // disable previous/next button if there is no previous/next
        if (selected == 0) previousButton.SetActive(false);
        else previousButton.SetActive(true);

        if (selected >= gunNames.Length - 1) nextButton.SetActive(false);
        else nextButton.SetActive(true);
    }

    public void DisplayGun()
    {
        for (int i = 0; i < guns.Length; i++)
        {
            if (i == selected) guns[i].SetActive(true);
            else guns[i].SetActive(false);
        }
    }

    public void SetDesc()
    {
        if (PlayerData.Instance != null)
        {
            budget.text = $"${PlayerData.Instance.Money}";

            // check if first gun is bought or equipped
            if (!PlayerData.Instance.gunsOwned[selected])
            {
                buyButton.SetActive(true);
                equipButton.SetActive(false);
                equipped.SetActive(false);
            }
            else
            {
                buyButton.SetActive(false);
                equipButton.SetActive(true);
                equipped.SetActive(false);
            }

            if (PlayerData.Instance.equipped == selected)
            {
                buyButton.SetActive(false);
                equipButton.SetActive(false);
                equipped.SetActive(true);
            }
        }

        itemName.text = gunNames[selected];
        itemDesc.text = gunDescs[selected];
    }

    public void BuyGun()
    {
        if (selected == 3)
        {
            errorMessage.text = "We don't have this item in stock...";
            errorBox.SetActive(true);
        }
        else if (PlayerData.Instance.Money >= gunPrices[selected])
        {
            // Pay money
            PlayerData.Instance.Money -= gunPrices[selected];
            // Add to owned guns
            PlayerData.Instance.gunsOwned[selected] = true;

            SetDesc();
        }
        else
        {
            errorMessage.text = "You don't have enough money to buy this!";
            errorBox.SetActive(true);
        }
    }

    public void equipGun()
    {
        PlayerData.Instance.equipped = selected;
        SetDesc();
    }

    public void NextButton()
    {
        if (selected < gunNames.Length - 1) selected++;
        SetDesc();
        DisplayGun();
    }

    public void PreviousButton()
    {
        if (selected > 0) selected--;
        SetDesc();
        DisplayGun();
    }

    public void MainMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("mainMenu");
    }

    public void OkButton()
    {
        errorBox.SetActive(false);
    }

    public void PlayNextLevelButton()
    {
        if (PlayerData.Instance.lvl1completed)
        {
            if (!PlayerData.Instance.lvl2completed) UnityEngine.SceneManagement.SceneManager.LoadScene("cityTwo");
            else
            {
                errorMessage.text = "Level 3 is on the way :)";
                errorBox.SetActive(true);
            }
        }
        else UnityEngine.SceneManagement.SceneManager.LoadScene("cityOne");
    }
}
