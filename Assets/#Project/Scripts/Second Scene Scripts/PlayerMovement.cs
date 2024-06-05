using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        UpdatePosition();
        MoveOnClick();
    }

    public void LoadData()
    {
        transform.position = PlayerData.Position;
        SetDestination(PlayerData.Destination, false);
    }

    private void SetDestination(Vector3 destination, bool updateData = true)
    {
        if (updateData) PlayerData.Destination = destination;
        agent.SetDestination(destination);
    }

    private void UpdatePosition()
    {
        PlayerData.Position = transform.position;
    }

    private void MoveOnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
