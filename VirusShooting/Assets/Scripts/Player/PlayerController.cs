using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Vector3 = UnityEngine.Vector3;

public class PlayerController : MonoBehaviour
{
    public float speed;
    
    private Rigidbody2D rigid;
    private BoxCollider2D collider;
    public AudioSource audioSorce;
    public AudioClip audioClip;

    public PlayerBullet playerBullet;

    void Start()
    {
        speed = 5f;
        
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        audioSorce = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Update()
    {
        Shoot();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        transform.Translate(Vector3.right * h * speed * Time.deltaTime);
        transform.Translate(Vector3.up * v * speed * Time.deltaTime);

        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0) pos.x = 0;
        if (pos.y < 0) pos.y = 0;
        if (pos.x > 1) pos.x = 1;
        if (pos.y > 1) pos.y = 1;
        pos = Camera.main.ViewportToWorldPoint(transform.position);

    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(playerBullet, transform.position, transform.rotation);
            audioSorce.PlayOneShot(audioClip);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Enemy enemyInstance = other.GetComponent<Enemy>();
            if (!GameManager.instance.isShield && !GameManager.instance.isUndamageCheat)
            {
                GameManager.instance.Damage(enemyInstance.damage / 2);
            }
            GameManager.instance.ScoreUp(enemyInstance.score);
            Destroy(other.gameObject);
        }

        else if (other.gameObject.tag == "Item")
        {
            Item item = other.gameObject.GetComponent<Item>();
            switch (item.type)
            {
                case "Heal":
                    GameManager.instance.Heal(30);
                    break;
                case "Painkiller":
                    GameManager.instance.ReducePain(30);
                    break;
                case "PowerUp":
                    GameManager.instance.PowerUp();
                    break;
                case "ScoreUp":
                    GameManager.instance.ScoreUp(2000);
                    break;
                case "Shield":
                    if (GameManager.instance.isShield)
                    {
                        StopCoroutine(GameManager.instance.ShieldCoroutine());
                    }
                    StartCoroutine(GameManager.instance.ShieldCoroutine());
                    break;
                case "SpeedUp":
                    StartCoroutine(GameManager.instance.BoostCoroutine());
                    break;
            }

            Destroy(other.gameObject);
        }
    }
}
