using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public Transform[] SpawnPoints;
    public GameObject Pref;
    public GameObject coin;
    [Range(2f, 5f)]
    public  static float delay = 5;
    public static Action st;
    private void Start()
    {
        st += Starter;
    }
    public void Starter()
    {
        StopAllCoroutines();
        StartCoroutine(DelaySpawn());
    }
    public IEnumerator DelaySpawn()
    {
        int r = Random.Range(0, SpawnPoints.Length);
        if (Manager.IsDead == false)
        {
            Pref.GetComponent<Enemy>().speed = Mathf.Clamp(Random.Range(18, Score.Limit), 18, 25);
            Instantiate(Pref, SpawnPoints[r].position, Quaternion.identity);
            int k = Random.Range(0, SpawnPoints.Length);
            Instantiate(coin, SpawnPoints[k].position, Quaternion.identity);
            yield return new WaitForSeconds(delay);
            StartCoroutine(DelaySpawn());
        }
        delay -= 0.01f;
    }
}
