using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSingleton : MonoBehaviour
{
    private static CubeSingleton instance;
    void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {

    }
}
