using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public AudioClip hit;
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("PlaneStart") == null)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Plane")
        {
            Manager.moneyint += 1;
            if(SoundManager.SFX == true)
            {
                SoundManager.SfxA.PlayOneShot(hit);
            }
            Destroy(this.gameObject);
        }
    }
}
