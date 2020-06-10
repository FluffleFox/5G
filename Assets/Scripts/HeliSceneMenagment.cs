using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HeliSceneMenagment : MonoBehaviour
{
    public Transform[] moveOnDropObject;
    public float[] moveOnDropSpeed;
    public int dropTime = 30;
    float dropSpeed = 0.01f;
    bool ready = false;
   public void Ready()
   {
        if (!ready)
        {
            ready = true;
            StartCoroutine(Drop()); 
        }
   }

    IEnumerator Drop()
    {
        for(int i=0; i<dropTime; i++)
        {
            for(int j=0; j<moveOnDropObject.Length; j++)
            {
                moveOnDropObject[j].transform.position += Vector3.up * i * 9.81f * dropSpeed * moveOnDropSpeed[j];
                yield return new WaitForSecondsRealtime(dropSpeed);
            }
        }
        SceneManager.LoadScene("SampleScene");
    }

}
