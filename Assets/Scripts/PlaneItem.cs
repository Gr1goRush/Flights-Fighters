using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public enum usil
{
    Speed,
    Control,
    Health
}
public class PlaneItem : MonoBehaviour
{
    [Header("AirPlaneClassParametrs")]
    public string Name;
    public Sprite planeSprite;
    public GameObject planePref;
    public int Cost;
    public cost Material;
    public int speed;
    public int control;
    public int health;
    [Header("Other Things")]
    public bool IsBuy;
    public GameObject Selected;
    public GameObject Buy;
    public TextMeshProUGUI textCost;
    public AirPlane ThisAirPlane;
    public Action<usil> addpower;
    public PlaneItem me;
    public void Start()
    {
        PlayerPrefs.SetInt(Name + "Speed", PlayerPrefs.GetInt(Name + "Speed", speed));
        PlayerPrefs.SetInt(Name + "Control", PlayerPrefs.GetInt(Name + "Control", control));
        PlayerPrefs.SetInt(Name + "Health", PlayerPrefs.GetInt(Name + "Health", health));
        addpower += Usil;
        ThisAirPlane = new AirPlane(Name, Cost, Material, PlayerPrefs.GetInt(Name + "Speed", speed)
            , PlayerPrefs.GetInt(Name + "Control", control), PlayerPrefs.GetInt(Name + "Health", health), planeSprite, planePref);
        if(PlayerPrefs.GetString("Select") == Name)
        {
            CurrentPlane.air = ThisAirPlane;
            Debug.Log(Name);
        }
        var i = PlayerPrefs.GetInt(Name, 0);
        if (i == 0 && Name != "default")
        {
            IsBuy = false;
            PlayerPrefs.SetInt(Name, 0);
        }
        else if(i == 1)
        {
            IsBuy = true;
            PlayerPrefs.SetInt(Name, 1);
            CurrentPlane.item = this.gameObject;
        }
        else
        {
            IsBuy = true;
            PlayerPrefs.SetInt(Name, 1);
            CurrentPlane.item = this.gameObject;
        }
        if (IsBuy == true)
        {
            Selected.SetActive(true);
            Buy.SetActive(false);
            if(CurrentPlane.air.Name == Name)
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
        textCost.text = Cost.ToString();
    }
    public void Update()
    {
        if (IsBuy == true)
        {
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
        }
    }
    public void BuyPlane()
    {
        SoundManager.SFXLauncher();
        UpgradeCenter.reload(me);
        if (IsBuy == true)
        {
            PlayerPrefs.SetString("Select", Name);
            SelectedPlane();
            UpgradeCenter.reload(me);
        }
        else
        {
            if(Material == cost.Medals)
            {
                if(Manager.medals >= Cost)
                {
                    PlayerPrefs.SetString("Select", Name);
                    Manager.medals -= Cost;
                    SelectedPlane();
                    UpgradeCenter.reload(me);
                }

            }
            else
            {
                if (Manager.moneyint >= Cost)
                {
                    PlayerPrefs.SetString("Select", Name);
                    Manager.moneyint -= Cost;
                    SelectedPlane();
                    UpgradeCenter.reload(me);
                }
            }
        }
    }
    public void SelectedPlane()
    {
        CurrentPlane.air = ThisAirPlane;
        CurrentPlane.item = this.gameObject;
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
    public void Usil(usil u)
    {
        if(u == usil.Speed)
        {
            ThisAirPlane.speed += 1;
            PlayerPrefs.SetInt(Name + "Speed", ThisAirPlane.speed);
            UpgradeCenter.reload(me);
        }
        else if (u == usil.Control)
        {
            ThisAirPlane.control += 1;
            PlayerPrefs.SetInt(Name + "Control", ThisAirPlane.control);
            UpgradeCenter.reload(me);
        }
        else
        {
            ThisAirPlane.health += 1;
            PlayerPrefs.SetInt(Name + "Health", ThisAirPlane.health);
            UpgradeCenter.reload(me);
        }
    }
}
