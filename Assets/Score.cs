using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI Text;
    static int score = 0;
    static int highScore = 0;
    static Score instance;

    static public void AddPoint()
    {
        if (instance.bird.dead)
            return;
        score++;

        if(score > highScore)
        {
            highScore = score;
        }
    }
    BirdMovement bird;
    void Start()
    {
        instance = this;
        GameObject player_go = GameObject.FindGameObjectWithTag("player");
        if(player_go == null)
        {
            Debug.LogError("no find an object with tag 'player' ");
        }
        bird = player_go.GetComponent<BirdMovement>();

        Text = transform.GetComponent<TextMeshProUGUI>();
        score = 0;
        highScore = PlayerPrefs.GetInt("highScore", 0);
    }
    
    void OnDestroy()
    {
         PlayerPrefs.SetInt("highScore", highScore);
    }
    // Update is called once per frame
    void Update()
    {
        
        Text.text = "Score: " + score + "\nhighScore: " + highScore;
    }
}
