using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliAnimation : MonoBehaviour
{
    public float speed;
    public Transform element;
    void Update()
    {
        element.rotation *= Quaternion.Euler(Vector3.forward * speed * Time.deltaTime);
    }
}
