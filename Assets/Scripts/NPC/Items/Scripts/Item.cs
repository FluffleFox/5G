using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private float C = 50; // Maksymalna szansa
    [SerializeField]
    private float N = 1; // Spłaszczenie
    [SerializeField]
    private float A = 1; // Nachylenie
    [SerializeField]
    private int R = 0; // Przesunięcie na x

    [HideInInspector]
    public float chance; // wylosowana szansa na obecnym poziomie
    public virtual void LastFrameAction()
    {

    }

    public float GetMaxChance(int level)
    {
        if (level - R == 0) return 0;
        return C * (1.0f - (1.0f / Mathf.Pow(A * (level - R), N)));
    }
}
