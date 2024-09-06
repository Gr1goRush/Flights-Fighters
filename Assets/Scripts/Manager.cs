using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.iOS;

public class Manager : MonoBehaviour
{
    public static bool IsDead = false;
    public static bool IsPaused = false;
    public bool deadTest;
    public static int moneyint = 0;
    public static int medals = 0;
    public GameObject menu;
    public TextMeshProUGUI[] money;
    public TextMeshProUGUI[] medal;
    public GameObject gameOver;
    public GameObject pause;
    public AudioSource aud;
    public MusicItem[] m;
    void Update()
    {
        deadTest = IsDead;
        PlayerPrefs.SetInt("Money", moneyint);
        PlayerPrefs.SetInt("Medal", medals);
        for (int i = 0; i < money.Length; i++)
        {
            money[i].text = moneyint.ToString();
        }
        for(int i = 0; i < medal.Length; i++)
        {
            medal[i].text = medals.ToString();
        }
        if(IsDead == true)
        {
            GameOver();
            IsDead = false;
        }
    }
    public void Start()
    {
        moneyint = PlayerPrefs.GetInt("Money", 0);
        medals = PlayerPrefs.GetInt("Medal", 0);
    }
    public void Back(GameObject me)
    {
        SoundManager.SFXLauncher();
        menu.SetActive(true);
        aud.Stop();
        foreach(MusicItem item in m)
        {
            item.StopAllCoroutines();
        }
        SoundManager.MusicA.volume = 0.7f;
        me.gameObject.SetActive(false);
        GameObject[] g = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] h = GameObject.FindGameObjectsWithTag("Coiner");
        foreach (GameObject gameObject in h)
        {
            Destroy(gameObject);
        }
        foreach (GameObject go in g)
        {
            Destroy(go);
        }
        Destroy(GameObject.Find("Plane(Clone)"));
        PlaneController.UnDeath = false;
        PlaneController.time = 0;
    }
    public void OpenWindowOnMenu(GameObject window)
    {
        SoundManager.SFXLauncher();
        window.SetActive(true);
        menu.SetActive(false);
    }
    public void OnPause(GameObject pauseMenu)
    {
        Time.timeScale = 0;
        IsPaused = true;
        pauseMenu.SetActive(true);
    }
    public void OffPause(GameObject pauseMenu)
    {
        SoundManager.SFXLauncher();
        Time.timeScale = 1;
        IsPaused = false;
        pauseMenu.SetActive(false);
    }
    public void GameOver()
    {
        gameOver.SetActive(true);
        Time.timeScale = 0;
        PlaneController.UnDeath = false;
        PlaneController.time = 0;
        Spawner.delay = 5;
        IsDead = false;
    }
    public void StartAgain()
    {
        SoundManager.SFXLauncher();
        SoundManager.StartGame();
        Time.timeScale = 1;
        CurrentPlane.start();
        Spawner.st();
        PlaneController.UnDeath = false;
        PlaneController.time = 0;
        Spawner.delay = 5;
        IsPaused = false;
        gameOver.SetActive(false);
        menu.SetActive(false);
    }
    public void BactToMenu(GameObject gamOv)
    {
        SoundManager.SFXLauncher();
        SoundManager.EndGame();
        Time.timeScale = 1;
        menu.SetActive(true);
        GameObject[] g = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject[] h = GameObject.FindGameObjectsWithTag("Coiner");
        foreach (GameObject gameObject in h)
        {
            Destroy(gameObject);
        }
        foreach (GameObject go in g)
        {
            Destroy(go);
        }
        Destroy(GameObject.Find("Plane(Clone)"));
        PlaneController.UnDeath = false;
        PlaneController.time = 0;
        Spawner.delay = 5;
        IsPaused = false;
        pause.SetActive(false);
        gamOv.SetActive(false);
    }
    public void Rait()
    {
        SoundManager.SFXLauncher();
        Device.RequestStoreReview();
    }
}
