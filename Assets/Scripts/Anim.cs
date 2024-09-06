using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anim : MonoBehaviour
{
    public Sprite[] sp;
    public float framesPerSeconds = 15f;
    private SpriteRenderer sr;
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float index = Time.time * framesPerSeconds;
        index = index % sp.Length;
        sr.sprite = sp[(int)index];
    }
}
