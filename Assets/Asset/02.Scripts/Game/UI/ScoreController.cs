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

    private int score = 0;

    private void Start()
    {
        // 하이스코어 가져오기
    }

    public void OnScore(int addScore)
    {
        score += addScore;
        scoreText.text = score.ToString();
    }
}
