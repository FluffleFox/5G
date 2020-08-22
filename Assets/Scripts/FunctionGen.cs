using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionGen : MonoBehaviour
{
    public float C = 50; // Maksymalna szansa
    [Range(0.0001f, 1.0f)]
    public float N = 1; // Spłaszczenie
    [Range(0.0001f,10.0f)]
    public float A = 1; // Nachylenie?
    public int R = 0; // Wymagany poziom;
    public int MaxLevelToAnalize = 10;

    public float chanceAtMax;
    public int unlockLevel;

    public int cheeckLevel;

    LineRenderer Line;
    void Start()
    {
        Line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        unlockLevel = -1;

        Line.positionCount = MaxLevelToAnalize;
        for(int i=1; i<=MaxLevelToAnalize; i++)
        {
            if (i - R == 0) continue;
            float y = C * (1.0f - (1.0f / Mathf.Pow(A * (i - R), N)));
            Line.SetPosition(i - 1, new Vector3(i,y, 0));
            if (i == cheeckLevel)
            {
                Debug.Log(y);
            }
            if(unlockLevel==-1 && Line.GetPosition(i).y > 0.5f) { unlockLevel = i; }

        }
        chanceAtMax = Line.GetPosition(MaxLevelToAnalize - 1).y;
    }
}
