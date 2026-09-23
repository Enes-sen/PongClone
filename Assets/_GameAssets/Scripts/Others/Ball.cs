using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody2D _rb;
    readonly float mp = 2f;
    public event Action<Side> OnGoal;
    public event Action<String> OnColide;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }
    public void ResetPos()
    {
        _rb.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }
    public void OnStart()
    {
        ResetPos();
        Vector2 pos = new(2*mp, mp);
        _rb.velocity = mp * -pos;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        OnColide?.Invoke(other.gameObject.tag);
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<IGoal>(out var gl))
            OnGoal?.Invoke(gl.Getside());
        
    }
}
public enum Side
{
    Left,
    Right,
}
