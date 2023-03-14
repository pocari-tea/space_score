using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour, IGameOverObserver
{
    [SerializeField] private PlayerModel playerModel;
    
    public int score;
    private bool _isPaused;
    public static GameManager Instance;
    
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject gameOverPanel;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    
    private void Start()
    {
        playerModel.AddObserver(this);
    }

    /// <summary>
    /// 시간이여 멈춰라
    /// </summary>
    public void OnPause(InputAction.CallbackContext context)
    {
        if(context.performed)
        {
            Time.timeScale = (_isPaused == true) ? 1 : 0;
            _isPaused = (Time.timeScale == 0);

            // foreach(GameObject obj in hideOnPause)
            // {
            //     obj.SetActive(!_isPaused);
            // }
            pausePanel.SetActive(_isPaused);
        }
    }
    
    public void OnGameOver()
    {
        gameOverPanel.SetActive(true);
    }
}
