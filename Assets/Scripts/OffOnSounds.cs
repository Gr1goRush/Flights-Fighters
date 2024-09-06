using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffOnSounds : MonoBehaviour
{
    public Slider s;
    private void Update()
    {
        if(s.value == 1)
        {
            SoundManager.SFX = true;
        }
        else
        {
            SoundManager.SFX = false;
        }
    }
}
