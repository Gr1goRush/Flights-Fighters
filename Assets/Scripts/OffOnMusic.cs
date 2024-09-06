using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OffOnMusic : MonoBehaviour
{
    public Slider s;
    private void Update()
    {
        if (s.value == 1)
        {
            SoundManager.Music = true;
        }
        else
        {
            SoundManager.Music = false;
        }
    }
}
