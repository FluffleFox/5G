using UnityEngine;

public class NPCDispository : MonoBehaviour
{
    public static NPCDispository Dispository;
    int current = 6;

    private void Awake()
    {
        Dispository = this;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<NPC_ControlScript>().SetIndex(i);
            if (i >= current) { transform.GetChild(i).gameObject.SetActive(false); }
        }
    }


    public void SetAnother()
    {
        if (current < transform.childCount)
        {
            current++;
            transform.GetChild(current-1).gameObject.SetActive(true);
            if (ScoreCounter.counter.Rage()) { transform.GetChild(current - 1).gameObject.GetComponent<NPC_ControlScript>().PrepareRageMode(); }
        }
    }

    public bool CanIRespawn(int index)
    {
        if (index < current) { return true; } else return false;
    }

    public void ResetAll()
    {
        for(int i=0; i<current; i++)
        {
            transform.GetChild(i).GetComponent<NPC_ControlScript>().StopRageMode();
        }
        current = 6;
    }
}
