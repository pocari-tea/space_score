using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI scoreHighText;
    
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip destroyAudioClip;

    private int score = 0;
    private int highScore = 0;
    
    public int Score
    {
        get { return score; }
        set
        {
            score += value;
        }
        
    }
    
    public int HighScore
    {
        get { return highScore; }
    }

    private void Start()
    {
        // 하이스코어 가져오기
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        
        scoreText.text = score.ToString();
        scoreHighText.text = highScore.ToString();
    }

    public void OnScore()
    {
        audioSource.PlayOneShot(destroyAudioClip);

        scoreText.text = score.ToString();
    }
}
