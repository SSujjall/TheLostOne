using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


[System.Serializable]
public static class SaveManager
{
    public static string directory = "SaveData";
    public static string filename = "saveFile.bin";

    public static void Save(PlayerData PD)
    {
        if(!DirectoryExists())
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/" + directory);
        }
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fs = File.Create(GetFullPath());

        bf.Serialize(fs, PD);
        fs.Close();
    }

    public static PlayerData Load()
    {
        if (SaveExists())
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream fs = File.Open(GetFullPath(), FileMode.Open);
                PlayerData PD = (PlayerData)bf.Deserialize(fs);
                fs.Close();

                return PD;

            }
            catch(SerializationException)
            {
                Debug.Log("Failed to load file");
            }
        }

        return null;
    }

    private static bool SaveExists()
    {
        return File.Exists(GetFullPath());
    }

    private static bool DirectoryExists()
    {
        return Directory.Exists(Application.persistentDataPath + "/" + directory);
    }

    private static string GetFullPath()
    {
        return Application.persistentDataPath + "/" + directory + "/" + filename;
    }
}
