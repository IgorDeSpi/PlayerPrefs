using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    private PoolCubeMember poolMember;


    void Start()
    {
        poolMember = GetComponent<PoolCubeMember>();
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        if (poolMember != null && poolMember.pool != null)
        {
            poolMember.pool.Kill(poolMember);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
