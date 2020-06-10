using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyableObject : MonoBehaviour
{
    public static DontDestroyableObject instance;
    void Start()
    {
        //po prostu kurwa zrobić z tego singleton
        DontDestroyOnLoad(gameObject);
    }
}
