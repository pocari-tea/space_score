using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class GameUIView : MonoBehaviour
{
    [Header("죽었을 때 패널 UI")]
    [SerializeField] private GameObject diePanel;
    [Header("점수 텍스트")]
    [SerializeField] private Text scoreText;
    public int score;

    public void ScoreAdd()
    {
        score += 1;
        scoreText.text = $"{score}점";
    }
}
