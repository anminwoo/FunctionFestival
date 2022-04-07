using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    public static SceneManagement sceneManager;

    private void Awake()
    {
        if (sceneManager != null)
        {
            Destroy(this);
        }

        sceneManager = this;
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void LoadScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
