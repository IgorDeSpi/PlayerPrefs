using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CubeFactory : MonoBehaviour
{
    [SerializeField] float cooldown = 0.5f;
    [SerializeField] GameObject prefab;
    [SerializeField]private PoolCube pool;
    // Start is called before the first frame update
    void Start()
    {

        if (pool == null)
        {
            pool = GetComponent<PoolCube>();
        }
        if (pool == null)
        {
            pool = FindObjectOfType<PoolCube>();
        }
        StartCoroutine(Create());
    }

    private IEnumerator Create()
    {
        while (true)
        {
            if (pool != null)
            {
                pool.Spawn(transform.position + Vector3.up * Random.Range(-5f, 5f), Quaternion.identity);
            }
            else
            {
                Instantiate(prefab, transform.position + Vector3.up * Random.Range(-5f, 5f), Quaternion.identity);
            }
            yield return new WaitForSeconds(cooldown);
        }
    }

}
