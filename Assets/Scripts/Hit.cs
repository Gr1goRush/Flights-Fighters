using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour
{
    public GameObject me;
    public AudioClip clip;
    public GameObject PrefabBoom;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(SoundManager.SFX == true)
        {
            SoundManager.SfxA.PlayOneShot(clip);
        }
        if (collision.gameObject.tag == "Plane")
        {
            if (PlaneController.UnDeath == false)
            {
                Instantiate(PrefabBoom, this.gameObject.transform.position, Quaternion.identity);
                Destroy(me);
                PlaneController.h -= 1;
                PlaneController.UnDeath = true;
                PlaneController.time = 3;
            }
        }
        else if(collision.gameObject.tag == "Enemy" && me.gameObject.tag == "PlaneStart")
        {
            Manager.medals += 1;
            Destroy(collision.transform.GetChild(0).GetComponent<Hit>().me);
            Instantiate(PrefabBoom, this.gameObject.transform.position, Quaternion.identity);
        }
        else if(collision.gameObject.tag == "Enemy" && me.gameObject.tag == "Enemy")
        {
            Manager.medals += 1;
            Destroy(collision.transform.GetChild(0).GetComponent<Hit>().me);
            Instantiate(PrefabBoom, this.gameObject.transform.position, Quaternion.identity);
            Destroy(me);
        }
    }
}
