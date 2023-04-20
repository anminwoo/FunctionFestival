using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class WhiteBlood : MonoBehaviour
{
    private float speed;
    
    public Item[] items;
    
    private Rigidbody2D rigid;
    private CircleCollider2D collider;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        speed = 3f;
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Instantiate(items[UnityEngine.Random.Range(0, 6)], transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "PlayerBullet")
        {
            Instantiate(items[UnityEngine.Random.Range(0, 6)], transform.position, transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
