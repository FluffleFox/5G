using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.WSA;

public class BasicNPCGen : MonoBehaviour
{

    public List<GameObject> posibleItems;
    public List<GameObject> rageModeItems;
    // Start is called before the first frame update
    void Awake()
    {
       // posibleItems.AddRange(Resources.LoadAll("/Items", typeof(GameObject[])) as GameObject[]);
        int itemCount = UnityEngine.Random.Range(1, posibleItems.Count);
        Debug.Log(itemCount);
        GameObject[] itemsInGame = new GameObject[itemCount+1];

        GameObject GO = (GameObject)Instantiate(posibleItems[0], Vector3.down * 5000, Quaternion.identity);
        posibleItems.RemoveAt(0);
        itemsInGame[0] = GO;

        for (int i=1; i<=itemCount; i++)
        {
            int index = UnityEngine.Random.Range(0, posibleItems.Count);
            if (posibleItems[index].GetComponent<Item>() == null) { continue; }
            Debug.Log(posibleItems[index].name);
            GO = (GameObject)Instantiate(posibleItems[index], Vector3.down * 5000, Quaternion.identity);
            posibleItems.RemoveAt(index);
            itemsInGame[i] = GO;
        }


        foreach (NPC_ControlScript npc in GameObject.FindObjectsOfType<NPC_ControlScript>())
        {
            npc.gameObject.AddComponent<BasicEquipment>();
            npc.GetComponent<BasicEquipment>().Prepare(itemsInGame, rageModeItems.ToArray());
        }


        GetComponent<NPCDispository>().SetNPCs();
    }

}
