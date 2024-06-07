using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CapsuleMovement movement = other.GetComponent<CapsuleMovement>();
        
        if (movement != null)
        {
            movement.Die();
        }
    }
}
