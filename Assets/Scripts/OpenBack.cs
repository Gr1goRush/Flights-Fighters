using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBack : MonoBehaviour
{
    public void BackToSettings()
    {
        SoundManager.SFXLauncher();
        this.gameObject.SetActive(false);
    }
    public void OpenPrivacy()
    {
        SoundManager.SFXLauncher();
        this.gameObject.SetActive(true);
    }
}
