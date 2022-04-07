using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Virus : Enemy
{
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        
        hp = 50;
        damage = 20;
        score = 700;
        speed = 1.5f;
        StartCoroutine(ShootCoroutine(90f, 3, 1.8f));
    }

    void Update()
    {
        Move();
    }
}
