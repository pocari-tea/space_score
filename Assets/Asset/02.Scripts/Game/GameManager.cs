using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerModel playerModel;
    
    public int score;
    
    public static GameManager Instance;
    [SerializeField] private GameObject stopPanel;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TimeStop();
        }

        if (playerModel.life == 0)
        {
            GameOver();
        }
    }
    
    private void GameOver()
    {
        Debug.Log("게임 오버");
    }

    /// <summary>
    /// 시간이여 멈춰라
    /// </summary>
    private void TimeStop()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
        else
        {
            Time.timeScale = 0;
        }
        
        stopPanel.SetActive(!stopPanel.activeSelf);
    }
}
