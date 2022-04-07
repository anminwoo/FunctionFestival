using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cancer : Enemy
{
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        
        hp = 60;
        damage = 20;
        score = 1000;
        speed = 2f;
        fireRate = 1.2f;
        nextFire = 0;
        StartCoroutine(ShootCoroutine(360f, 4, 2.4f));
    }

    void Update()
    {
        Move();
    }
}
