using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TargetData : MonoBehaviour
{
    public float[] chances;

    public TargetData(float[] _chances)
    {
        chances = _chances;
    }
}
