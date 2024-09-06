using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum cost
{
    Medals,
    Coins
}
public class AirPlane
{
    public string Name;
    public Sprite planeSprite;
    public GameObject planePref;
    public int Cost;
    public cost Material;
    public int speed;
    public int control;
    public int health;
    public AirPlane(string name, int Cost, cost cos, int spee, int cont, int hel, Sprite sprite, GameObject pref)
    {
        this.Name = name;
        this.Cost = Cost;
        this.speed = spee;
        this.control = cont;
        this.health = hel;
        this.planeSprite = sprite;
        this.planePref = pref;
        this.Material = cos;
    }
    public int GetCost()
    {
        return Cost;
    }
    public List<int> GetUpgrades()
    {
        var list = new List<int>();
        list.Add(speed);
        list.Add(control);
        list.Add(health);
        return list;
    }
}
public class Shop : MonoBehaviour
{
    public GameObject planePref;
    public void Start()
    {
        CurrentPlane.curentPlane = planePref;
    }
}
