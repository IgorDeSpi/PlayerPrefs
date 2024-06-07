using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CapsuleMovement : MonoBehaviour
{
    private NavMeshAgent agent;
    public Pool pool;
    public bool initialized = false;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (initialized)
            return;
        agent = GetComponent<NavMeshAgent>();
        initialized = true;
        gameObject.SetActive(true);
    }

    public void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }

    public void Die()
    {
        gameObject.SetActive(false);
        initialized = false;
        pool.AddToPool(this);
    }
}
