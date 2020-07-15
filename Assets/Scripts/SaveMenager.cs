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
            Debug.Log("Pobieram dane gracza");
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.OpenRead(path);
            PlayerData data = bf.Deserialize(file) as PlayerData;
            file.Close();
            return data;
        }
        else
        {
            Debug.Log("Brak pliku gracza do odczytu");
            PlayerData firstLoad = new PlayerData(1, 1000, 1, 1, 1, 1);
            Save(firstLoad);
            return firstLoad;
        }
    }

    public static void SaveTargetData(float[] _data)
    {
        string json = JsonUtility.ToJson(new TargetData(_data));

        string path = Application.persistentDataPath + "/TargetData.dat";
        FileStream file;
        if (File.Exists(path))
        { file = File.OpenWrite(path); }
        else { file = File.Create(path); }

        using (StreamWriter writer = new StreamWriter(file)) 
        { writer.Write(json); }

        file.Close();
    }

    public static float[] LoadTargetData(ref float[] ret)
    {
        Debug.Log(Application.persistentDataPath);
        string path = Application.persistentDataPath + "/TargetData.dat";
        if (File.Exists(path))
        {
            Debug.Log("Pobieram dane celu");
            using (StreamReader reader = new StreamReader(path))
            {
                string json = reader.ReadToEnd();
                Debug.Log(json);
                TargetData tmp = new TargetData(new float[4]);
                JsonUtility.FromJsonOverwrite(json, tmp);
                for (int i = 0; i < tmp.chances.Length; i++)
                {
                    Debug.Log(tmp.chances[i]);
                }
                ret = tmp.chances;
                return ret;
            }
        }
        else
        {
            Debug.Log("Brak pliku celu do odczytu");
            ret = null;
            return null;
        }
    }

    /* public static void SaveTargetData(float[] _data)
     {
         Debug.Log("Zapisuje dane gracza");
         TargetData data = new TargetData(_data);
         BinaryFormatter bf = new BinaryFormatter();
         string path = Application.persistentDataPath + "/TargetData.dat";
         FileStream file;
         if (File.Exists(path))
         { file = File.OpenWrite(path); }
         else { file = File.Create(path); }
         bf.Serialize(file, data);
         file.Close();
     }

     public static float[] LoadTargetData(ref float[] ret)
     {
         string path = Application.persistentDataPath + "/TargetData.dat";
         if (File.Exists(path))
         {
             Debug.Log("Pobieram dane celu");
             BinaryFormatter bf = new BinaryFormatter();
             FileStream file = File.OpenRead(path);
             TargetData data = bf.Deserialize(file) as TargetData;
             file.Close();
             ret = data.chances;
             return data.chances;
         }
         else
         {
             Debug.Log("Brak pliku celu do odczytu");
             ret = null;
             return null;
         }
     }*/
}
