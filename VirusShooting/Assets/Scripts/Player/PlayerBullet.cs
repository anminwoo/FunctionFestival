using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float speed;
    private CapsuleCollider2D collider;
    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
        speed = 10f;
    }


    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Enemy")) return;
        Destroy(this);
    }
}
