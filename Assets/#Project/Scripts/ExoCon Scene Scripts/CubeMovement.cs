using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class CubeMovement : MonoBehaviour
{
    public CubePool pool;

    [SerializeField] private float speed = 5.0f;
    public bool initialized = false;

    void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        if (initialized) return;
        initialized = true;
        gameObject.SetActive(true);
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
    }


    public void Die()
    {
        gameObject.SetActive(false);
        initialized = false;
        pool.AddToPool(this);
    }

    void OnBecameInvisible()
    {
        Die();
    }

}
