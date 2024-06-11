using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolCubeMember : MonoBehaviour
{
    public PoolCube pool;

    private void OnBecameInvisible(){
        pool.Kill(this);
    }
}
