using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextHealth : MonoBehaviour
{
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("PlaneStart") != null)
        {
            this.GetComponent<TextMeshProUGUI>().text = PlaneController.h.ToString();
        }
        else
        {
            this.GetComponent<TextMeshProUGUI>().text = "-";
        }
    }
}
