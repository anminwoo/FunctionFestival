using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int hp;
    public int damage;
    private int pain;
    public int playerScore;
    private int bulletLevel;
    public bool isShield;
    public bool isUndamageCheat;

    public Text hpText;
    public Text painText;
    public Text scoreText;
    public Slider hpSlider;
    public Slider painSlider;
    public GameObject Shield;
    public GameObject panel;

    public PlayerController playerController;
    public EnemySpawn[] enemySpawns;
    public GameObject redBlood;
    public GameObject whiteBlood;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this);
        }

        instance = this;
    }

    void Start()
    {
        hp = 100;
        pain = 10;
        playerScore = 0;
        bulletLevel = 1;
        damage = bulletLevel * 10;
        hpSlider.value = hp;
        painSlider.value = pain;

        hpText.text = "Hp: " + hp + "%";
        painText.text = "Pain: " + pain + "%";
        scoreText.text = "Score: " + playerScore;
    
        isShield = false;
        Shield.SetActive(false);
        isUndamageCheat = false;
    }


    void Update()
    {
        Cheat();
    }

    public void Heal(int heal)
    {
        if (hp + heal >= 100)
        {
            hp = 100;
            hpText.text = "Hp" + hp + "%";
            hpSlider.value = hp;
            return;
        }

        hp += heal;
        hpText.text = "Hp" + hp + "%";
        hpSlider.value = hp;
    }

    public void ReducePain(int reducePain)
    {
        if (pain - reducePain <= 0)
        {
            pain = 0;
            painText.text = "Pain" + pain + "%";
            return;
        }

        pain -= reducePain;
        painText.text = "Pain" + pain + "%";
    }

    public void Damage(int damage)
    {
        if (hp - damage <= 0)
        {
            hp = 0;
            hpText.text = "Hp" + hp + "%";
            hpSlider.value = hp;
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            hp -= damage;
            hpText.text = "Hp" + hp + "%";
            hpSlider.value = hp;   
        }
    }

    public void GetPain(int getPain)
    {
        if (pain + getPain >= 100)
        {
            pain = 100;
            painText.text = "Pain" + pain + "%";
            SceneManager.LoadScene("GameOver");
        }

        else
        {
            pain += getPain;
            painText.text = "Pain" + pain + "%";
            painSlider.value = pain;
        }
    }

    public IEnumerator ShieldCoroutine()
    {
        isShield = true;
        Shield.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        Shield.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        isShield = false;
    }
    
    public IEnumerator BoostCoroutine() // ???????????? ??????
    {
        float normalSpeed = playerController.speed;
        playerController.speed = 8f;
        yield return new WaitForSeconds(3f);
        playerController.speed = normalSpeed;
    }

    public void PowerUp()
    {
        if (bulletLevel < 5)
        {
            bulletLevel++;
            damage = bulletLevel * 10;
        }
    }

    public void PowerDown()
    {
        if (bulletLevel > 1)
        {
            bulletLevel--;
            damage = bulletLevel * 10;
        }
    }

    public void DestroyAll()
    {
        if (gameObject.tag == "Enemy" || gameObject.tag == "EnemyBullet")
        {
            Destroy(gameObject);
        }
    }

    public void ScoreUp(int score)
    {
        playerScore += score;
        scoreText.text = "Score: " + playerScore;
    }

    void Cheat()
    {
        if (Input.GetKeyDown(KeyCode.U)) Heal(10); // ??????
        else if (Input.GetKeyDown(KeyCode.I)) ReducePain(10); // ?????? ??????
        else if (Input.GetKeyDown(KeyCode.O)) Damage(10); // ??????
        else if (Input.GetKeyDown(KeyCode.P)) GetPain(10); // ?????? ??????
        else if (Input.GetKeyDown(KeyCode.LeftBracket))
            Instantiate(redBlood, enemySpawns[UnityEngine.Random.Range(0, 3)].transform.position, transform.rotation); // ????????? ??????
        else if (Input.GetKeyDown(KeyCode.RightBracket))
            Instantiate(whiteBlood, enemySpawns[UnityEngine.Random.Range(0, 3)].transform.position, transform.rotation); // ????????? ??????
        else if (Input.GetKeyDown(KeyCode.J)) isUndamageCheat = !isUndamageCheat; // ?????? ??????
        else if (Input.GetKeyDown(KeyCode.K)) SceneManager.LoadScene("Stage1"); // stage1??? ??????
        else if (Input.GetKeyDown(KeyCode.L)) SceneManager.LoadScene("Stage2"); // stage2??? ??????
        else if (Input.GetKeyDown(KeyCode.N)) PowerUp();
        else if (Input.GetKeyDown(KeyCode.M)) PowerDown();
        else if(Input.GetKeyDown(KeyCode.B)) DestroyAll();
    }
}
