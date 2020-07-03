using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveMenager
{
    public static void Save(PlayerData data)
    {
        Debug.Log("Save");
        BinaryFormatter bf = new BinaryFormatter();
        string path = Application.persistentDataPath + "Data.fun";
        FileStream file;
        file = File.Open(path, FileMode.OpenOrCreate);
        bf.Serialize(file, data);
        file.Close();
    }

    public static PlayerData Load()
    {
        string path = Application.persistentDataPath + "Data.fun";
        if (File.Exists(path))
        {
            Debug.Log("Pobieram");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(path);
            PlayerData data = bf.Deserialize(file) as PlayerData;
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
}
