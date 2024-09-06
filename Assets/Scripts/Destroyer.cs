using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(destroy());
    }
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("PlaneStart") == null)
        {
            Destroy(gameObject);
        }
    }
    public IEnumerator destroy()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }
}
