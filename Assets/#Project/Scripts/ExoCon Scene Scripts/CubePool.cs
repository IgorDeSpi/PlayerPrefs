using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubePool : MonoBehaviour
{
    private Stack<CubeMovement> pool = new();
    [SerializeField] private GameObject prefab;
    [SerializeField] private int InitialBatch = 20;

    void Awake()
    {
        for (int _ = 0; _ < InitialBatch; _++)
        {
            GameObject newOne = Instantiate(prefab);
            newOne.GetComponent<CubeMovement>().pool = this;
            newOne.GetComponent<CubeMovement>().Die();
        }

    }

    public CubeMovement Create(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            GameObject newOne = Instantiate(prefab, position, rotation);
            newOne.GetComponent<CubeMovement>().pool = this;
            return newOne.GetComponent<CubeMovement>();
        }
        CubeMovement movement = pool.Pop();
        movement.transform.position = position;
        movement.transform.rotation = rotation;
        return movement;
    }

    public CubeMovement Create() => Create(Vector3.zero, Quaternion.identity);

    public void AddToPool(CubeMovement movement)
    {
        pool.Push(movement);
    }
}
