using UnityEngine;

public class NPCDispository : MonoBehaviour
{
    int widly = 4;
    int pochodnie = 4;
    Transform widlyContainer;
    Transform pochodnieContainer;
    public static NPCDispository Dispository;

    private void Awake()
    {
        Dispository = this;
        widlyContainer = transform.GetChild(0);
        pochodnieContainer=transform.GetChild(1);
        for (int i = 0; i < widlyContainer.childCount; i++)
        {
            widlyContainer.GetChild(i).GetComponent<KarenAI>().SetIndex(i);
            if (i >= widly) { widlyContainer.GetChild(i).gameObject.SetActive(false); }
        }
        for (int i = 0; i < pochodnieContainer.childCount; i++)
        {
            pochodnieContainer.GetChild(i).GetComponent<KarenAI>().SetIndex(i);
            if (i >= pochodnie) { pochodnieContainer.GetChild(i).gameObject.SetActive(false); }
        }
    }


    public void SetAnother()
    {
        if (widly == pochodnie && widly<widlyContainer.childCount)
        {
            widlyContainer.GetChild(widly).gameObject.SetActive(true);
            widly++;
        }
        else if(pochodnie<pochodnieContainer.childCount)
        {
            pochodnieContainer.GetChild(pochodnie).gameObject.SetActive(true);
            pochodnie++;
        }
    }

    public bool CanIRespawn(int index, Transform parent)
    {
        if (parent == pochodnieContainer)
        { if (index < pochodnie) { return true; } else return false; }
        else if (parent == widlyContainer) { if (index < widly) return true; else return false; }
        else { Debug.Log("Something went wrong in: " + parent.name); return false; }
    }

    public void ResetAll()
    {
        widly = 3;
        pochodnie = 3;
    }
}
