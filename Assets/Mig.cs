using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mig : MonoBehaviour
{
    float time = 1;
    void Update()
    {
        time -= 0.1f;
        if(time <= 0)
        {
            time = 3;
            GetComponent<SpriteRenderer>().enabled = !GetComponent<SpriteRenderer>().enabled;
        }
    }
}
