using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccurateLevel : MonoBehaviour
{
    BoxCollider myHitBox;
    Vector3 hitBoxSize;
    void Start()
    {
        myHitBox = GetComponent<BoxCollider>();
        hitBoxSize = myHitBox.bounds.size;
        SetDefault();
    }

    public void SetDefault()
    {
        myHitBox.size=hitBoxSize*(0.5f+(0.5f/GeneralGameMenager.instance.data.accurateLevel));
    }

    public void SetBigger()
    {
        myHitBox.size = hitBoxSize * (1.0f + 0.5f * (1.0f - (1.0f / GeneralGameMenager.instance.data.accurateLevel)));
    }
}
