using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAnimation : MonoBehaviour
{
    public Transform mid;
    public Transform top;
    public Transform bot;

    public float dragForce;
    public float shootForce;

    public float bouncingScale;
    public float boincingSpeed;

    public float dancingScale;
    public float dancingSpeed;

   Vector3 midDestiny;
   Vector3 topDestiny;

    [HideInInspector]
    public Vector3 topDropAngle;
    [HideInInspector]
    public Vector3 midDropAngle;


    private void Start()
    {
       midDestiny = Vector3.zero;
       topDestiny = Vector3.zero;
    }

    public void BurnThisTower()
    {
        midDestiny = new Vector3/*Quaternion.Euler*/(Random.Range(-20.0f, 20.0f), Random.Range(0.0f, 360.0f), Random.Range(70.0f, 90.0f));
        topDestiny = new Vector3/*Quaternion.Euler*/(Random.Range(-90.0f, 90.0f), 0.0f, Random.Range(30.0f, 70.0f));
    }

    public void Rebulid()
    {
        midDestiny = Vector3.zero; //Quaternion.Euler(Vector3.zero);
        topDestiny = Vector3.zero; //Quaternion.Euler(Vector3.zero);
    }

    private void Update()
    {
        mid.rotation = Quaternion.Slerp(mid.rotation, Quaternion.Euler(midDestiny), 5.0f * Time.deltaTime);
        top.rotation = Quaternion.Slerp(top.rotation, Quaternion.Euler(topDestiny), 5.0f * Time.deltaTime);

        if (DeadRay.tower != null)
        {
            midDestiny -= midDestiny * Time.deltaTime * dragForce;
            topDestiny -= topDestiny * Time.deltaTime * dragForce;

            mid.transform.localPosition = Vector3.up * 0.5f + Vector3.up * Mathf.Sin(Time.realtimeSinceStartup * boincingSpeed) * bouncingScale;
            top.transform.localPosition = Vector3.up * 2.159919f + Vector3.up * Mathf.Sin(Time.realtimeSinceStartup * boincingSpeed) * bouncingScale;

            bot.rotation = Quaternion.Euler(0.0f, 0.0f, Mathf.Sin(Time.realtimeSinceStartup * dancingSpeed) * dancingScale);
        }
        else
        {
            midDestiny = midDropAngle;
            topDestiny = topDropAngle;
        }
    }

    public void AddShootForce(Vector3 dir)
    {
        Vector3 tmp = dir;
        tmp.y = 0.0f;
        tmp.z *= 0.4f;
        tmp = Vector3.Cross(tmp, Vector3.down);
        tmp = tmp.normalized * shootForce;
        Vector3 toproot = topDestiny;
        Vector3 midroot = midDestiny;
        toproot += tmp;
        if (Mathf.Abs(toproot.x) > 30.0f)
        {
            float err = (Mathf.Abs(toproot.x) - 30.0f)*Mathf.Sign(toproot.x);
            //toproot.x = 30.0f*Mathf.Sign(toproot.x);
            midroot.x += err;
        }
        if (Mathf.Abs(toproot.z) > 30.0f)
        {
            float err = (Mathf.Abs(toproot.z) - 30.0f) * Mathf.Sign(toproot.z);
            //toproot.z = 30.0f * Mathf.Sign(toproot.z);
            midroot.z += err;
        }

        topDestiny = toproot;
        midDestiny = midroot;
    }

}
