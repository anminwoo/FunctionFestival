using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = UnityEngine.Debug;
using Random = System.Random;

public class Covid : Enemy
{
    public Enemy[] enemies;

    public int sceneNumber;
    
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        collider = GetComponent<CircleCollider2D>();
        
        hp = 1200;
        damage = 30;
        score = 10000;
        StartCoroutine(Patterns());
    }

    private void OnDestroy()
    {
        if(isDie == true)
            SceneManager.LoadScene(sceneNumber);
    }

    void OneShoot()
    {
        Instantiate(enemyBullet, transform.position, transform.rotation);
    }

    void TripleShoot()
    {
        for (int i = 0; i < 3; i++)
        {
            Shoot(90f, 3);
        }
    }

    void RoundShoot()
    {
        Shoot(360f, 18);
    }

    IEnumerator Patterns()
    {
        while (true)
        {
            int number = UnityEngine.Random.Range(1, 5);
            switch(number)
            {
                case 1:
                    OneShoot();
                    yield return new WaitForSeconds(1.5f);
                    Debug.Log("Work");
                    break;
                case 2:
                    TripleShoot();
                    yield return new WaitForSeconds(2f);
                    Debug.Log("Work");
                    break;
                case 3:
                    RoundShoot();
                    yield return new WaitForSeconds(2.5f);
                    Debug.Log("Work");
                    break;
                case 4:
                    Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length)], transform.position,
                        transform.rotation);
                    yield return new WaitForSeconds(3f);
                    Debug.Log("Work");
                    break;
            }
        }
    }
}
