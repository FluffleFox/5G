using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Evacuation : MonoBehaviour
{
    public GameObject heli;
    public GameObject tower;
    public static Evacuation instance;

    private void Awake()
    {
        instance = this;
        heli.SetActive(false);
    }

    public void Evac()
    {
        heli.SetActive(true);
        StartCoroutine(EvacProcedure());
    }

    IEnumerator EvacProcedure()
    {
        for(int i=0; i<50; i++)
        {
            if (i < 25)
            { Camera.main.transform.rotation *= Quaternion.Euler(Vector3.left * 0.6f); }
            transform.rotation *= Quaternion.Euler(Vector3.forward);
            heli.transform.localRotation *= Quaternion.Euler(-Vector3.forward);
            yield return new WaitForSecondsRealtime(0.03f);
        }
        tower.transform.parent = heli.transform;
        yield return new WaitForSecondsRealtime(0.5f);
        for (int i = 0; i < 50; i++)
        {
            transform.rotation *= Quaternion.Euler(Vector3.forward);
            heli.transform.localRotation *= Quaternion.Euler(-Vector3.forward);
            yield return new WaitForSecondsRealtime(0.03f);
        }
        tower.GetComponent<LineRenderer>().enabled = false;
        Destroy(tower.GetComponent<DeadRay>());
        //Debug.Log("LoadAirScene");
        SceneManager.LoadScene("HeliScene");
    }
}

