using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.PackageManager;


public class GameData
{
    public const string DATA_PATH = "gameData.dat";
    public static string SAVE_PATH
    {
        get { return $"{Application.persistentDataPath}//{DATA_PATH}"; }
    }

    [Serializable] private class SaveData
    {
        public int score;
    }

    public static void Save()
    {
        string path = $"{Application.persistentDataPath}//{DATA_PATH}";
        BinaryFormatter bf = new();
        FileStream file = File.Create(path);

        SaveData sd = new();
        sd.score = score;

        bf.Serialize(file, sd);
        file.Close();
        Debug.Log($"Data saved at {path}");
    }

    public static void Load()
    {
        if (File.Exists(SAVE_PATH))
        {
            BinaryFormatter bf = new();
            FileStream file = File.OpenRead(SAVE_PATH);

            SaveData sd = (SaveData) bf.Deserialize(file);
            file.Close();
        }
        else
        {
            Debug.Log($"File {SAVE_PATH} does not exist");
        }
    }

    public static int score = 0;

    public static void UpdateScore(int value)
    {
        score = value;
    }

    public static void AddScore(int value)
    {
        UpdateScore(score + value);
    }
}
