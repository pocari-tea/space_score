using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour, IGameOverObserver
{
    [SerializeField] private PlayerModel playerModel;
    [SerializeField] PlayerInput playerInput;
    
    public int score;
    private bool _isPaused;
    public static GameManager Instance;
    
    [SerializeField] private GameObject gameOverPanel;

    // 일시정시 시 안보이게 처리할 패널
    [Header("Pause Control")] [SerializeField]
    private List<GameObject> hideOnPausePanel;

    // 일시정시 패널
    [SerializeField] private GameObject pausePanel;

    bool isPaused;
    bool isGameOver = false;

    public bool IsPaused
    {
        get { return isPaused; }
    }

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
        if(context.action.phase == InputActionPhase.Performed && !isGameOver)
        {
            Time.timeScale = (isPaused == true) ? 1 : 0;
            isPaused = (Time.timeScale == 0);

            foreach(GameObject obj in hideOnPausePanel)
            {
                obj.SetActive(!isPaused);
            }
            pausePanel.SetActive(isPaused);
        }
    }
    
    public void OnGameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        
        foreach(GameObject obj in hideOnPausePanel)
        {
            obj.SetActive(false);
        }
        gameOverPanel.SetActive(true);
    }
    
    public void OnRetry()
    {
        SceneManager.LoadScene("Game");
    }
    
    public void OnLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
