using System.Collections.Generic;
using UnityEngine;

public class PoolCube : MonoBehaviour
{
    private Stack<PoolCubeMember> pool = new();
    [Range(1, 100)][SerializeField] private int initialBatch = 50;
    [Range(1, 100)][SerializeField] private int batch = 10;

    [SerializeField] GameObject prefab;

    private bool initialized = false;

    public void Awake()
    {
        if (initialized) return;
        Create(initialBatch);
        initialized = true;
    }

    private void Create(int number)
    {
        for (int _ = 0; _ < initialBatch; _++)
        {
            GameObject newOne = Instantiate(prefab);
            newOne.GetComponent<PoolCubeMember>().pool = this;
            Kill(newOne.GetComponent<PoolCubeMember>());
        }
    }

    public PoolCubeMember Spawn(Vector3 position, Quaternion rotation)
    {
        if (pool.Count == 0)
        {
            Create(batch);
        }
        PoolCubeMember member = pool.Pop();
        Revive(member,position, rotation);
        return member;
    }

    public void Kill(PoolCubeMember member)
    {
        member.gameObject.SetActive(false);
        pool.Push(member);
    }

    public void Revive(PoolCubeMember member, Vector3 position, Quaternion rotation){
        member.gameObject.SetActive(true);
        member.transform.position = position;
        member.transform.rotation = rotation;
    }

}
