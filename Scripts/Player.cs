using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float speedMove = 17f; 
    [SerializeField] float paddingLeft;
    [SerializeField] float paddingRight;
    [SerializeField] float paddingTop;
    [SerializeField] float paddingBottom;
    Vector2 rawInput;
    Vector2 minBounds;
    Vector2 maxBounds;
    Shooter shooter;
    void Awake() 
    {
        shooter = GetComponent<Shooter>();
    }
    void Start ()
    {
        InitBounds();
    }
    void Update()
    {
        Move();
    }

    void InitBounds()  // tao ranh gioi
    {
        Camera mainCamera = Camera.main;
        minBounds = mainCamera.ViewportToWorldPoint(new Vector2(0,0)); // goc trai duoi
        maxBounds = mainCamera.ViewportToWorldPoint(new Vector2(1,1));  // goc phai tren

    }
    private void Move()
    {
        Vector2 delta = rawInput * speedMove * Time.deltaTime;
        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(transform.position.x + delta.x, minBounds.x + paddingLeft, maxBounds.x - paddingRight);
        newPosition.y = Mathf.Clamp(transform.position.y + delta.y, minBounds.y + paddingBottom, maxBounds.y - paddingTop);
        transform.position = newPosition;
    }

    void OnMove(InputValue inputValue)
    {
        rawInput = inputValue.Get<Vector2>();
    }
    
    void OnFire(InputValue inputValue)
    {
        if(shooter != null)
        {
            shooter.isFiring = inputValue.isPressed;
        }
    }
}
