using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CapsuleFactory : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [Range(1, 100)][SerializeField] private int batch = 10;
    [SerializeField] private float coolDown = 1;
    [SerializeField] private Transform destination;
    [SerializeField] private Pool pool;

    void Start()
    {
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        while (true)
        {
            for (int _ = 0; _ < batch; _++)
            {
                CapsuleMovement movement = pool.Create(transform.position, transform.rotation);
                movement.Initialize();
                movement.SetDestination(destination.position);
            }
            yield return new WaitForSeconds(coolDown);
        }
    }
}
