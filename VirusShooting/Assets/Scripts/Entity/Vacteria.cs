using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vacteria : Enemy
{

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        
        hp = 20;
        damage = 10;
        speed = 1f;
        score = 200;
    }

    void Update()
    {
        Move();
    }
}
