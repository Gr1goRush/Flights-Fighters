using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paralax : MonoBehaviour
{
    public Transform folowingTarget;
    [Range(0, 1f)]
    public float paralaxStrength = 0.1f;
    public bool disVertParalax;
    Vector3 targetPreviouspos;
    public void Start()
    {
        if (!folowingTarget)
        {
            folowingTarget = Camera.main.transform;
        }
        targetPreviouspos = folowingTarget.position;
    }
    public void Update()
    {
        var delta = folowingTarget.position - targetPreviouspos;
        if (disVertParalax)
            delta.y = 0;
        targetPreviouspos = folowingTarget.position;
        transform.position += delta * paralaxStrength;
    }
}
