using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlaneController : MonoBehaviour
{
    public Transform point;
    public Sprite[] povr;
    private Vector3 dir;
    [Range(1, 5)]
    public int speed;
    [Range(1, 5)]
    public int rot_speed;
    [Range(1, 5)]
    public int health;
    public static bool UnDeath;
    public static float time;
    [Range(0, 3)]
    public static int h = 0;
    public bool UnD;
    AudioSource aud;
    private void Start()
    {
        point = GameObject.FindGameObjectWithTag("DirPoint").transform;
        aud = GetComponent<AudioSource>();
        h = health * 3;
    }
    void Update()
    {
        UnD = UnDeath;
        if(h == 2)
        {
            this.transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().sprite = povr[0];
        }
        else if(h == 1)
        {
            this.transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().sprite = povr[1];
        }
        else
        {
            this.transform.GetChild(0).GetChild(1).GetComponent<SpriteRenderer>().sprite = null;
        }
        if (SoundManager.SFX == true)
        {
            aud.mute = false;
        }
        else
        {
            aud.mute = true;
        }
        if (Manager.IsPaused == false)
        {
            if(UnDeath == true)
            {
                if(time <= 0)
                {
                    UnDeath = false;
                    time = 0;
                }
                else
                {
                    time -= 0.1f;
                }
            }
            if (h <= 0)
            {
                GameObject[] g = GameObject.FindGameObjectsWithTag("Enemy");
                GameObject[] h = GameObject.FindGameObjectsWithTag("Coiner");
                foreach (GameObject gameObject in h)
                {
                    Destroy(gameObject);
                }
                foreach (GameObject go in g)
                {
                    Destroy(go);
                }
                Destroy(this.gameObject);
                Manager.IsDead = true;
            }
            if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began || Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Moved)
            {
                point.position = Camera.main.ScreenToWorldPoint(Input.touches[0].position);
                dir = point.position - transform.position;
            }
            var direction = dir;
            var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), rot_speed * 5.5f * 0.01f);
            this.transform.position += transform.right * speed * 7.5f * 0.01f;
        }
    }
}
