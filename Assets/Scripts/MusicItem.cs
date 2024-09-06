using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MusicItem : MonoBehaviour
{
    public bool IsBuy;
    public AudioClip music;
    public string Name;
    public int Cost;
    public GameObject Selected;
    public GameObject Buy;
    public TextMeshProUGUI textCost;
    public AirPlane ThisAirPlane;
    public AudioSource aud;
    public MusicItem[] other;
    public void Start()
    {
        var i = PlayerPrefs.GetInt(Name, 0);
        if(PlayerPrefs.GetString("SelectMusic") == Name)
        {
            SoundManager.MusicSound = music;
        }
        if (i == 0)
        {
            IsBuy = false;
        }
        else
        {
            IsBuy = true;
        }
        if (IsBuy == true)
        {
            Selected.SetActive(true);
            Buy.SetActive(false);
            if (SoundManager.MusicSound == music)
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
            if (SoundManager.MusicSound == music)
            {
                Selected.GetComponent<TextMeshProUGUI>().text = "SELECTED";
            }
            else
            {
                Selected.GetComponent<TextMeshProUGUI>().text = "UNSELECTED";
            }
        }
    }
    public void BuyMusic()
    {
        SoundManager.SFXLauncher();
        if (IsBuy == true)
        {
            PlayerPrefs.SetString("SelectMusic", Name);
            SelectedMusic();
        }
        else
        {
            if (Manager.moneyint >= Cost)
            {
                PlayerPrefs.SetString("SelectMusic", Name);
                Manager.moneyint -= Cost;
                SelectedMusic();
            }
        }
    }
    public void SelectedMusic()
    {
        SoundManager.MusicSound = music;
        SoundManager.SFXLauncher();
        Selected.SetActive(true);
        Buy.SetActive(false);
        if (SoundManager.MusicSound == music)
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
    public void StartCor()
    {
        SoundManager.SFXLauncher();
        foreach (MusicItem item in other)
        {
            item.StopAllCoroutines();
        }
        StopAllCoroutines();
        StartCoroutine(playSeven());
    }
    public IEnumerator playSeven()
    {
        aud.clip = music;
        aud.Play();
        SoundManager.MusicA.volume = 0;
        yield return new WaitForSeconds(7);
        SoundManager.MusicA.volume = 1;
        aud.Stop();
    }
}
