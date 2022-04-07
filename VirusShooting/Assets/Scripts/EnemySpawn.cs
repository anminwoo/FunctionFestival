using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemies;
    void Start()
    {
        StartCoroutine(SpawnEnemyCoroutine());
    }
    
    void Update()
    {
        
    }

    IEnumerator SpawnEnemyCoroutine()
    {
        while (true)
        {
            float waitSecond = UnityEngine.Random.Range(6f, 8f);
            Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Length)], transform.position, transform.rotation);
            yield return new WaitForSeconds(waitSecond);
        }
    }
    
}
