using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    
    public int score = 0;
    public int lives = 3;
    public Brick[] bricks;
    public int brickCount = 0;

    [Header("UI")]
    public TMP_Text scoreText;
    public TMP_Text livesText;
    public GameObject resetScreen;
    public GameObject gameScreen;
    
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy (gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        bricks = FindObjectsByType<Brick>(FindObjectsSortMode.None);
        brickCount = bricks.Length;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"Puntos: {score}";
        livesText.text = $"Vidas: {lives}";
    }
    
    public void BrickDestroy()
    {
        brickCount--;
        score += 10;
        if(brickCount <= 0)
        {
            Debug.Log("You Win!");
            EndGame();
        }
    }
    public void LoseLifes()
    {
        lives--;
        if(lives <= 0)
        {
            Debug.Log("You lose!");
            EndGame();
        }
    }

    public void EndGame()
    {
        GameObject.Find("Pad").SetActive(false);
        GameObject[] balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach(GameObject ball in balls)
        {
            ball.SetActive(false);
        }
        resetScreen.SetActive(true);
 
    }
    

    public void ResestGame()
    {
        score = 0;
        lives = 3;
        gameScreen.SetActive(true);
        resetScreen.SetActive(false);
        GameObject.Find("Pad").SetActive(true);
    }
}
