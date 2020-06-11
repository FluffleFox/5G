using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyableObject : MonoBehaviour
{
    public static DontDestroyableObject instance;
    void Start()
    {
        if (instance != null) { Destroy(gameObject); }
        else { instance = this; }
        DontDestroyOnLoad(gameObject);
    }
}
