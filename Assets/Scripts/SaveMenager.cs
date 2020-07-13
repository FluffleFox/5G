using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveMenager
{
    public static void Save(PlayerData data)
    {
        Debug.Log("Save");
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Data.dat";
        FileStream file;
        if (File.Exists(path))
        { file = File.OpenWrite(path); }
        else { file = File.Create(path); }
        bf.Serialize(file, data);
        file.Close();
    }

    public static PlayerData Load()
    {
        string path = Application.persistentDataPath + "/Data.dat";
        if (File.Exists(path))
        {
            Debug.Log("Pobieram");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(path);
            PlayerData data = bf.Deserialize(file) as PlayerData;
            file.Close();
            return data;
        }
        else
        {
            Debug.Log("Brak Pliku do odczytu");
            PlayerData firstLoad = new PlayerData(1, 1000, 1, 1, 1, 1);
            Save(firstLoad);
            return firstLoad;
        }
    }

    public static void SaveTargetData(TargetData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "/TargetData.dat";
        FileStream file;
        if (File.Exists(path))
        { file = File.OpenWrite(path); }
        else { file = File.Create(path); }
        TargetDataInString tmp = new TargetDataInString(data);
        bf.Serialize(file, tmp);
        file.Close();
    }

    public static TargetData LoadTargetData()
    {
        string path = Application.persistentDataPath + "/TargetData.dat";
        if (File.Exists(path))
        {
            Debug.Log("Pobieram");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(path);
            TargetDataInString data = bf.Deserialize(file) as TargetDataInString;
            file.Close();
            TargetData tmp =new TargetData(data);
            return tmp;
        }
        else
        {
            Debug.Log("Brak Pliku do odczytu");

            /*PlayerData firstLoad = new PlayerData(1, 1000, 1, 1, 1, 1);
            Save(firstLoad);
            return firstLoad;*/
            return null;
        }
    }



}

public class TargetDataInString
{
    public string[] items;
    public string[] rageItems;
    public TargetDataInString(TargetData data)
    {
        items = new string[data.items.Length];
        for(int i=0; i<data.items.Length; i++)
        {
            items[i] = "/Items/" + data.items[i].name;
        }
        rageItems = new string[data.rageModeItems.Length];
        for (int i = 0; i < data.rageModeItems.Length; i++)
        {
            rageItems[i] = "/Items/" + data.rageModeItems[i].name;
        }
    }
}
