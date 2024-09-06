using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentPlane : MonoBehaviour
{
    public static Action start;
    public static GameObject curentPlane;
    public Sprite s, defbg;
    public GameObject pref;
    public static AirPlane air;
    public static GameObject item;
    public static Sprite baseBG;
    public void Awake()
    {
        baseBG = defbg;
        PlayerPrefs.SetString("Select", PlayerPrefs.GetString("Select", "default"));
        PlayerPrefs.SetInt("default", PlayerPrefs.GetInt("default", 1));
        if (PlayerPrefs.GetInt("default") == 1)
        {
            air = new AirPlane("default", 0, cost.Coins, 1, 1, 1, s, pref);
        }
        start += StartGame;
    }
    public void StartGame()
    {
        CinemachineVirtualCamera c = GetComponent<CinemachineVirtualCamera>();
        if(curentPlane != null && air != null)
        {
            curentPlane.GetComponent<PlaneController>().speed = air.speed;
            curentPlane.GetComponent<PlaneController>().rot_speed = air.control;
            curentPlane.GetComponent<PlaneController>().health = air.health;
        }
        GameObject plane = Instantiate(curentPlane, Vector3.zero, Quaternion.identity);
        plane.transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = air.planeSprite;
        c.Follow = plane.transform;
        Manager.IsDead = false;
    }
    public void Update()
    {
        GameObject[] bg = GameObject.FindGameObjectsWithTag("BG");
        foreach (GameObject go in bg)
        {
            go.GetComponent<SpriteRenderer>().sprite = baseBG;
        }
    }
}
