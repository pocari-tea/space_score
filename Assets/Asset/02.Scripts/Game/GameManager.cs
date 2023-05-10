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

    // 게임오버 패널
    [Header("GameOver Panel")] [SerializeField]
    private GameObject gameOverPanel;

    // 일시정시 시 안보이게 처리할 패널
    [Header("Pause Panel")] [SerializeField]
    private List<GameObject> hideOnPausePanel;

    // 일시정시 패널
    [SerializeField] private GameObject pausePanel;
    
    // 일시정지 컨트롤러
    [SerializeField] private PauseController pauseController;

    
    

    bool isPaused;
    bool isGameOver = false;

    private void Awake()
    {
        Time.timeScale = 1;
    }
    
    private void Start()
    {
        playerModel.AddObserver(this);
    }
    
    public static PlayerInput PlayerInput
    {
        get { return Instance?.playerInput; }
    }
    
    public bool IsPaused
    {
        get { return isPaused; }
    }

    /// <summary>
    /// 시간이여 멈춰라
    /// </summary>
    public void OnPause(InputAction.CallbackContext context)
    {
        if(context.action.phase == InputActionPhase.Started)
        {
            if(isGameOver) return;
            Pause();
        }
        
    }
    public void Pause()
    {
        Time.timeScale = (isPaused == true) ? 1 : 0;
        isPaused = (Time.timeScale == 0);

        foreach(GameObject obj in hideOnPausePanel)
        {
            obj.SetActive(!isPaused);
        }
        pausePanel.SetActive(isPaused);
        
        AudioListener.pause = isPaused;

        string actionMapName = (isPaused == true) ? "UI" : "Player";
        playerInput.SwitchCurrentActionMap(actionMapName);
        pauseController.enabled = isPaused;
    }
    
    public void GameOver()
    {
        isGameOver = true;
        Time.timeScale = 0;
        
        foreach(GameObject obj in hideOnPausePanel)
        {
            obj.SetActive(false);
        }
        gameOverPanel.SetActive(true);
    }
    
    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
