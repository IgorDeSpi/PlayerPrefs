using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameDataUI : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    private void Start()
    {
        Refresh();
    }

    private void Refresh()
    {
        scoreText.text = $"Score : {GameData.score:00000}";
    }

    public void Save()
    {
        GameData.Save();
    }

    public void Load()
    {
        GameData.Load();
        Refresh();
    }

    public void AddScore()
    {
        GameData.AddScore(1);
        Refresh();
    }
}
