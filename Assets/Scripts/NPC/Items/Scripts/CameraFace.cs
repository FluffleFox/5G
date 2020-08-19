using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFace : MonoBehaviour
{
    const float tangent30 = 1.7320508075688772935274463415059f; //1/tg(30)


    void Update()
    {
        transform.rotation = Quaternion.LookRotation(Camera.main.transform.position - transform.position);
        float h = Camera.main.transform.position.z - transform.position.z;
        float d = 2 * h * tangent30*0.005f;
        transform.localScale = Vector3.one * d;
    }
}
