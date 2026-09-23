using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float Speed = 40f;
    Vector2 Dir;
    Rigidbody2D _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Update() { CalcDir(); }

    private void FixedUpdate() 
    {
        if (Dir == Vector2.zero) return;
        _rb.MovePosition(_rb.position + Speed * Time.fixedDeltaTime * Dir); 
    }

    private void CalcDir()
    {
        var inputY = Input.GetAxis("Vertical");
        Dir = new Vector2(0, inputY);
        Dir = Dir.normalized;   
    }
}
