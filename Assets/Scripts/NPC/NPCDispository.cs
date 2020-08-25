using UnityEngine;

public class NPCDispository : MonoBehaviour
{
    public static NPCDispository Dispository;
    int current = 6;

    private void Awake()
    {
        Dispository = this;
        GeneralGameMenager.instance.QuitingRage.AddListener(ResetAll);
    }

    private void Start()
    {
        SetNPCs();
    }

    public void SetNPCs()
    {   
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<NPC_ControlScript>().SetIndex(i);
            if (i >= current) 
            { transform.GetChild(i).gameObject.SetActive(false); }
            else { transform.GetChild(i).GetComponent<NPC_ControlScript>().Prepare(); }
        }
    }


    public void SetAnother()
    {
        if (current < transform.childCount)
        {
            current++;
            transform.GetChild(current-1).gameObject.SetActive(true);
            transform.GetChild(current - 1).GetComponent<NPC_ControlScript>().Prepare();
        }
    }

    public bool CanIRespawn(int index)
    {
        if (index < current) { return true; } 
        else return false;
    }

    void ResetAll()
    {
        current = 6;
    }
}
