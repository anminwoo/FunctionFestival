using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damage;
    private CapsuleCollider2D collider;
    void Start()
    {
        collider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        Move(10f);
    }

    public void Move(float speed)
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!GameManager.instance.isShield && !GameManager.instance.isUndamageCheat)
            {
                GameManager.instance.Damage(damage);
            }
            Destroy(gameObject);
        }
    }
        
    
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
