using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UpgradeCenter : MonoBehaviour
{
    public Image[] speed, control, health;
    int curSpeed, curContr, curHealth;
    public GameObject pr;
    public TextMeshProUGUI spee, contro, healt;
    public int sp = 500, cont = 500, heal = 500;
    AirPlane cur;
    public static Action<PlaneItem> reload;
    public Button[] buttons;
    public void Start()
    {
        cur = CurrentPlane.air;
        for (int i = 0; i < speed.Length; i++)
        {
            speed[i].color = Color.white;
            control[i].color = Color.white;
            health[i].color = Color.white;
        }
        for (int i = 0; i < cur.speed; i++)
        {
            speed[i].color = Color.cyan;
        }
        for (int i = 0; i < cur.control; i++)
        {
            control[i].color = Color.cyan;
        }
        for (int i = 0; i < cur.health; i++)
        {
            health[i].color = Color.cyan;
        }
        reload += Choiser;
    }
    public void Choiser(PlaneItem pl)
    {
        SoundManager.SFXLauncher();
        if (pl.Name == CurrentPlane.air.Name)
        {
            Selecting();
        }
        else
        {
            PreSelecting(pl);
        }
    }
    public void Selecting()
    {
        cur = CurrentPlane.air;
        SoundManager.SFXLauncher();
        for (int i = 0; i < speed.Length; i++)
        {
            speed[i].color = Color.white;
            control[i].color = Color.white;
            health[i].color = Color.white;
        }
        for (int i = 0; i < cur.speed; i++)
        {
            speed[i].color = Color.cyan;
        }
        for (int i = 0; i < cur.control; i++)
        {
            control[i].color = Color.cyan;
        }
        for (int i = 0; i < cur.health; i++)
        {
            health[i].color = Color.cyan;
        }
        foreach (Button b in buttons)
        {
            b.interactable = true;
        }
    }
    public void BuyUsil(string us)
    {
        SoundManager.SFXLauncher();
        if (us == "speed")
        {
            if(Manager.medals >= sp && CurrentPlane.air.speed < 5)
            {
                Manager.medals -= sp;
                CurrentPlane.item.GetComponent<PlaneItem>().addpower(usil.Speed);
                Selecting();
            }
        }
        else if(us == "control")
        {
            if (Manager.medals >= cont && CurrentPlane.air.control < 5)
            {
                Manager.medals -= cont;
                CurrentPlane.item.GetComponent<PlaneItem>().addpower(usil.Control);
                Selecting();
            }
        }
        else if (us == "health")
        {
            if (Manager.medals >= heal && CurrentPlane.air.health < 5)
            {
                Manager.medals -= heal;
                CurrentPlane.item.GetComponent<PlaneItem>().addpower(usil.Health);
                Selecting();
            }
        }
    }
    public void Update()
    {
        if (cur.speed == 5)
        {
            spee.text = "MAX";
        }
        else
        {
            spee.text = sp.ToString();
        }
        if (cur.control == 5)
        {
            contro.text = "MAX";
        }
        else
        {
            contro.text = cont.ToString();
        }
        if (cur.health == 5)
        {
            healt.text = "MAX";
        }
        else
        {
            healt.text = heal.ToString();
        }
    }
    public void PreSelecting(PlaneItem pl)
    {
        cur = pl.ThisAirPlane;
        for (int i = 0; i < speed.Length; i++)
        {
            speed[i].color = Color.white;
            control[i].color = Color.white;
            health[i].color = Color.white;
        }
        for (int i = 0; i < cur.speed; i++)
        {
            speed[i].color = Color.cyan;
        }
        for (int i = 0; i < cur.control; i++)
        {
            control[i].color = Color.cyan;
        }
        for (int i = 0; i < cur.health; i++)
        {
            health[i].color = Color.cyan;
        }
        if(pl.IsBuy == true)
        {
            foreach(Button b in buttons)
            {
                b.interactable = true;
            }
        }
        else
        {
            foreach (Button b in buttons)
            {
                b.interactable = false;
            }
        }
    }
}