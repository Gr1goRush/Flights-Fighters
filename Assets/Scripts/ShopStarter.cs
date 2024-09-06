using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopStarter : MonoBehaviour
{
    public GameObject shop;
    void Start()
    {
        StartCoroutine(st());
    }
    public IEnumerator st()
    {
        shop.SetActive(true);
        yield return new WaitForSeconds(0.05f);
        shop.SetActive(false);
    }
}
