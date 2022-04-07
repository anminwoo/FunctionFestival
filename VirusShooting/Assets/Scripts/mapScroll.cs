using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapScroll : MonoBehaviour
{
    public Sprite[] backGrounds;
    public float backGroundHalf;
    public float speed;
    void Start()
    {
        
    }
    
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
}
