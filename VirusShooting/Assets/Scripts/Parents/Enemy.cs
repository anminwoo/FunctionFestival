using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

public class Enemy : MonoBehaviour
{
    public int hp;
    public int damage;
    public float speed;
    public int score;
    public float fireRate;
    public float nextFire;

    public GameObject enemyBullet;

    public Rigidbody2D rigid;
    public CircleCollider2D collider;
    
    public void Awake()
    {

    }
    
    public void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        
    }

    public void Shoot()
    {
        Instantiate(enemyBullet, transform.position, transform.rotation);
    }

    public void Shoot(float angle, int bulletCount)
    {
        for (float i = -1 * angle / 2; i < angle / 2; i += angle / bulletCount)
        {
            Instantiate(enemyBullet, transform.position, Quaternion.Euler(0, 0, i));
        }
    }

    public IEnumerator ShootCoroutine(float delay)
    {
        while (true)
        {
            Instantiate(enemyBullet, transform.position, transform.rotation);
            yield return new WaitForSeconds(delay);
        }
    }

    public IEnumerator ShootCoroutine(float angle, int bulletCount, float delay)
    {
        while (true)
        {
            for (float i = -1 * angle / 2; i < angle / 2; i += angle / bulletCount)
            {
                Instantiate(enemyBullet, transform.position, Quaternion.Euler(0, 0, i));
            }

            yield return new WaitForSeconds(delay);
        }
    }

    public void Move()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(!GameManager.instance.isShield && !GameManager.instance.isUndamageCheat)
            GameManager.instance.Damage(damage);
            Destroy(gameObject);
        }
        else if (other.gameObject.tag == "PlayerBullet")
        {
            hp -= GameManager.instance.damage;
            if (hp <= 0)
            {
                GameManager.instance.ScoreUp(score);
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
            Destroy(other.gameObject);
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
