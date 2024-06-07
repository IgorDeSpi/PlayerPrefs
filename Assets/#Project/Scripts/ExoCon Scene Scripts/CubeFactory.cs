using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [Range(1, 100)][SerializeField] private int batch = 10;
    [SerializeField] private float coolDown = 1f;
    [SerializeField] private CubePool pool;

    void Start()
    {
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        while(true)
        {
            for(int i = 0; i < batch; i++)
            {
                CubeMovement movement = pool.Create(new Vector3(15f + i, Random.Range(-5.5f,7.5f), transform.position.z), transform.rotation);
                movement.Initialize();
            }
            yield return new WaitForSeconds(coolDown);
        }
    }
}
