using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BgItem : MonoBehaviour
{
    public Sprite sprite;
    public string Name;
    public int cost;
    public bool IsBuy;
    public GameObject Selected;
    public GameObject Buy;
    public TextMeshProUGUI textCost;
    public void Start()
    {
        var i = PlayerPrefs.GetInt(Name, 0);
        if (PlayerPrefs.GetString("SelectBG") == Name)
        {
            CurrentPlane.baseBG = sprite;
        }
        if (i == 0)
        {
            IsBuy = false;
            PlayerPrefs.SetInt(Name, 0);
        }
        else
        {
            IsBuy = true;
            PlayerPrefs.SetInt(Name, 1);
            CurrentPlane.baseBG = sprite;
        }
        if (IsBuy == true)
        {
            Selected.SetActive(true);
            Buy.SetActive(false);
            if (CurrentPlane.baseBG == sprite)
            {
                Selected.GetComponent<TextMeshProUGUI>().text = "SELECTED";
            }
            else
            {
                Selected.GetComponent<TextMeshProUGUI>().text = "UNSELECTED";
            }
        }
        else
        {
            Selected.SetActive(false);
            Buy.SetActive(true);
        }
        textCost.text = cost.ToString();
    }
    public void Update()
    {
        if (IsBuy == true)
        {
            Selected.SetActive(true);
            Buy.SetActive(false);
            if (CurrentPlane.baseBG == sprite)
            {
                Selected.GetComponent<TextMeshProUGUI>().text = "SELECTED";
            }
            else
            {
                Selected.GetComponent<TextMeshProUGUI>().text = "UNSELECTED";
            }
        }
    }
    public void BuyPlane()
    {
        SoundManager.SFXLauncher();
        if (IsBuy == true)
        {
            PlayerPrefs.SetString("SelectBG", Name);
            SelectedBG();
        }
        else
        {
            if (Manager.moneyint >= cost)
            {
                PlayerPrefs.SetString("SelectBG", Name);
                Manager.moneyint -= cost;
                SelectedBG();
            }
        }

    }
    public void SelectedBG()
    {
        CurrentPlane.baseBG = sprite;
        Selected.SetActive(true);
        Buy.SetActive(false);
        if (CurrentPlane.air.Name == Name)
        {
            Selected.GetComponent<TextMeshProUGUI>().text = "SELECTED";
        }
        else
        {
            Selected.GetComponent<TextMeshProUGUI>().text = "UNSELECTED";
        }
        IsBuy = true;
        PlayerPrefs.SetInt(Name, 1);
    }
}
