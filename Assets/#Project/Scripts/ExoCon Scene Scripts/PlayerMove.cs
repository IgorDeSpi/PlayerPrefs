using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Camera cam;
    public InputActionAsset actions;
    private InputAction move;

    void Start()
    {
        move = actions.FindActionMap("Player").FindAction("Move");
    }

    private void OnEnable()
    {
        actions.FindActionMap("Player").Enable();
    }

    private void OnDisable()
    {
        actions.FindActionMap("Player").Disable();
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 movement = move.ReadValue<Vector2>();

        //Bord droit de l'écran
        if (cam.WorldToScreenPoint(transform.position).x < cam.pixelWidth)
        {
            transform.Translate(new Vector3(movement.x, 0, 0) * 10f * Time.deltaTime, Space.World);
        }
        else
        {
            transform.position = cam.ScreenToWorldPoint(new Vector3(cam.pixelWidth, cam.WorldToScreenPoint(transform.position).y, cam.WorldToScreenPoint(transform.position).z));
        }

        //Bord gauche de l'écran
        if ( cam.WorldToScreenPoint(transform.position).x > 0f)
        {
            transform.Translate(new Vector3(movement.x, 0, 0) * 10f * Time.deltaTime, Space.World);
        }
        else
        {
            transform.position = cam.ScreenToWorldPoint(new Vector3(0f, cam.WorldToScreenPoint(transform.position).y, cam.WorldToScreenPoint(transform.position).z));
        }

        //Bord haut de l'écran
        if (cam.WorldToScreenPoint(transform.position).y < cam.pixelHeight)
        {
            transform.Translate(new Vector3(0, movement.y, 0) * 10f * Time.deltaTime, Space.World);
        }
        else
        {
            transform.position = cam.ScreenToWorldPoint(new Vector3(cam.WorldToScreenPoint(transform.position).x, cam.pixelHeight, cam.WorldToScreenPoint(transform.position).z));
        }

        //Bord bas de l'écran
        if (cam.WorldToScreenPoint(transform.position).y > 0)
        {
            transform.Translate(new Vector3(0, movement.y, 0) * 10f * Time.deltaTime, Space.World);
        }
        else
        {
            transform.position = cam.ScreenToWorldPoint(new Vector3(cam.WorldToScreenPoint(transform.position).x, 0f, cam.WorldToScreenPoint(transform.position).z));
        }
    }
}
