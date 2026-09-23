using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] Transform target;
    Rigidbody2D _rb2D;
    Vector2 C_position;
    readonly float delay = 1.6f;
    readonly float speed = 10f;
    void Start()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update() => C_position = CalculatePosTarget();
    private void FixedUpdate() => Move();
    private Vector2 CalculatePosTarget()
    {
        if (target == null) return Vector2.zero;
        Vector2 pos = target.position - transform.position;
        return pos.normalized;
    }

    void Move() 
    {
        if (C_position.x >= delay * 3.5f) return;

        _rb2D.MovePosition(_rb2D.position + speed * Time.fixedDeltaTime *C_position);
    }
}
