using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StarterLoading : MonoBehaviour
{
    public GameObject g;
    public Slider s;
    public TextMeshProUGUI t;
    private void Start()
    {
        s.value = 0;
        StartCoroutine(starter());
    }

    public IEnumerator ien()
    {
        yield return new WaitForSeconds(0.7f);
        g.SetActive(true);
        this.gameObject.SetActive(false);
    }
    public IEnumerator starter()
    {
        t.text = ((int)s.value).ToString() + "%";
        float r = Random.Range(0, 10f);
        s.value += r;
        yield return new WaitForSeconds(0.1f);
        if (s.value >= 100)
        {
            StartCoroutine(ien());
        }
        StartCoroutine(starter());
    }
}
