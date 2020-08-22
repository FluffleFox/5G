﻿using UnityEngine;
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
}