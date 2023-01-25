using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    public int score;
    
    public static GameManager instance;
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
