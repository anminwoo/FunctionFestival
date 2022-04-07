using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Germ : Enemy
{
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        hp = 30;
        damage = 10;
        speed = 1.5f;
        score = 500;
        fireRate = 2f;
        nextFire = 0;

        StartCoroutine(ShootCoroutine(fireRate));

    }

    void Update()
    {
        Move();

    }
}
