using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerController : MonoBehaviour
{
    public Vector2 look;
    public Vector2 move;
    [SerializeField]private float moveSpeed;


    void Start()
    {
        
    }

    void Update()
    {
        Move();
        Look();
    }

    private void Move()
    {
        transform.Translate(move.x*moveSpeed,0f,move.y*moveSpeed);        
    }

    private void Look()
    {
        transform.Rotate(0f,look.x,0f);
    }

    //controlls actions if user push button
    public void OnLook(InputValue value)
    {
        look=value.Get<Vector2>();
    }

    public void OnMove(InputValue value)
    {        
        move = value.Get<Vector2>();        
    }
}
