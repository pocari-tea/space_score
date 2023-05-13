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
    private static GameManager instance = null;
    
    // 일시정시 시 안보이게 처리할 패널
    [SerializeField] private List<GameObject> hideOnPausePanel;

    // 게임오버 패널
    [SerializeField] private GameObject gameOverPanel;
    // 일시정시 패널
    [SerializeField] private GameObject pausePanel;
    
    // 일시정지 컨트롤러
    [SerializeField] private SelectableController pauseController;
    // 게임오버 컨트롤러
    [SerializeField] private SelectableController gameOverController;
    // 점수 컨트롤러
    [SerializeField] private ScoreController scoreController;

    
    bool isPaused;
    bool isGameOver = false;
    

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }
            return instance;
        }
    }
    
    public static PlayerInput PlayerInput
    {
        get { return Instance?.playerInput; }
    }
    
    public static ScoreController ScoreController
    {
        get { return Instance?.scoreController; }
    }
    
    public bool IsPaused
    {
        get { return isPaused; }
    }
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        Time.timeScale = 1;
        AudioListener.pause = false;
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

        string inputActionMap = (isPaused == true) ? "Pulse" : "Player";
        playerInput.SwitchCurrentActionMap(inputActionMap);
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

        AudioListener.pause = true;
            
        gameOverPanel.SetActive(true);
        playerInput.SwitchCurrentActionMap("GameOver");
        gameOverController.enabled = true;
    }
    
    public void Retry()
    {
        AudioListener.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void Lobby()
    {
        SceneManager.LoadScene("Lobby");
    }
}
