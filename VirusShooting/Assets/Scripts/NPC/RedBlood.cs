using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBlood : MonoBehaviour
{
    private int pain;
    private float speed;
    private Rigidbody2D rigid;
    private CircleCollider2D collider;
    void Start()
    {
        pain = 5;
        speed = 5f;
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }
    
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "WhiteBlood")
        {
            return;
        }
        GameManager.instance.GetPain(pain);
        Destroy(gameObject);
    }
}
