using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloundMovment : MonoBehaviour
{
    public float wind;
    Material mat;
    void Start()
    {
        mat = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        mat.SetTextureOffset("_MainTex", Vector2.right * wind * Time.realtimeSinceStartup);
    }
}
