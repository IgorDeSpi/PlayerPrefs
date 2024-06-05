using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.PackageManager;

public class PlayerData
{
    public const string SAVE_FILENAME = "player.dat";
    [Serializable]
    private struct PlayerSave
    {
        [Serializable]
        public struct Vector3Serializable
        {
            public float x;
            public float y;
            public float z;
            public Vector3Serializable(float x, float y, float z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
            public Vector3 GetVector3()
            {
                return new Vector3(x, y, z);
            }
        }
        public Vector3Serializable position;
        public Vector3Serializable destination;
    }


    public static string SAVE_PATH
    {
        get { return Path.Combine(Application.persistentDataPath, SAVE_FILENAME); }
    }

    private static PlayerSave save = new();
    public static Vector3 Position
    {
        get { return save.position.GetVector3(); }
        set { save.position = new PlayerSave.Vector3Serializable(value.x, value.y, value.z); }
    }

    public static Vector3 Destination
    {
        get { return save.destination.GetVector3(); }
        set { save.destination = new PlayerSave.Vector3Serializable(value.x, value.y, value.z); }
    }

    public static void Save()
    {
        BinaryFormatter bf = new();
        FileStream file = File.Create(SAVE_PATH);

        bf.Serialize(file, save);
        file.Close();
    }

    public static void Load()
    {
        BinaryFormatter bf = new();
        FileStream file = File.OpenRead(SAVE_PATH);

        save = (PlayerSave) bf.Deserialize(file);
        file.Close();
    }
}
