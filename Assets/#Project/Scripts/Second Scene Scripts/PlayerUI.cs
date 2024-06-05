using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    [SerializeField] PlayerMovement playerMovement;

    public void Load()
    {
        PlayerData.Load();
        playerMovement.LoadData();
    }

    public void Save()
    {
        PlayerData.Save();
    }
}
