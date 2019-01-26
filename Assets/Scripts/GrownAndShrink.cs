using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrownAndShrink : MonoBehaviour {

    public Vector3 minScale;
    public Vector3 maxScale;
    public float speed;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = Vector3.Lerp(minScale, maxScale, Mathf.Abs(Mathf.Sin(Time.time)));
    }
}
