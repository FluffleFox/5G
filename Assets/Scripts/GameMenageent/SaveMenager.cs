using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveMenager
{
    public static void Save(PlayerData data)
    {
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
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(path);
            PlayerData data = bf.Deserialize(file) as PlayerData;
            file.Close();
            return data;
        }
        else
        {
            PlayerData firstLoad = new PlayerData(1, 0, 1000, 1, 1, 1);
            Save(firstLoad);
            return firstLoad;
        }
    }
}