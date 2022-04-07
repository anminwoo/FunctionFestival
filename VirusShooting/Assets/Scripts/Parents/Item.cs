using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string type;
    private Rigidbody2D rigid;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rigid.velocity = Vector2.down * 1.5f;
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
