using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score : MonoBehaviour
{
    public static int scoreCount = 0;
    public static int Limit = 19;
    public int delay;
    void Start()
    {
        StartCoroutine(AddScore());
    }
    public IEnumerator AddScore()
    {
        if (Manager.IsDead == false)
        {
            yield return new WaitForSeconds(delay);
            scoreCount++;
            if (scoreCount % 10 == 0)
            {
                Limit += 1;
            }
            StartCoroutine(AddScore());
        }
        else
        {
            Limit = 19;
            scoreCount = 0;
        }
    }
}
