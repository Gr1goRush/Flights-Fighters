using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Sprite[] sprite;
    public SpriteRenderer im;
    private Vector3 dir;
    [Range(4, 13)]
    public float rot_speed = 4;
    [Range(18, 55)]
    public float speed = 18;
    private void Start()
    {
        int r = 0;
        if(Score.scoreCount > 500)
        {
            r = Random.Range(0, sprite.Length - 1);
        }
        im.sprite = sprite[r];
    }
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("PlaneStart") != null)
        {
            player = GameObject.FindGameObjectWithTag("PlaneStart").transform;
        }
        else
        {
            Destroy(this.gameObject);
        }
        if (Manager.IsPaused == false)
        {
            if (GameObject.FindGameObjectWithTag("PlaneStart") != null)
            {
                dir = player.position - transform.position;
                var direction = dir;
                var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, angle), rot_speed * 0.01f);
                this.transform.position += transform.right * speed * 0.01f;
            }
            else
            {
                Destroy(this.gameObject);
            }
        }
    }
}
