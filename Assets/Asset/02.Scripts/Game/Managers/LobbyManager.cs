using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class LobbyManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    
    private static LobbyManager instance = null;
    
    [SerializeField] private GameObject shopPanel;
    
    
    public LobbyManager Instance
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
    
    public PlayerInput PlayerInput
    {
        get { return Instance?.playerInput; }
    }
    
    public void GameStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void ShopOpen()
    {
        playerInput.SwitchCurrentActionMap("Shop");
        
        shopPanel.SetActive(true);
    }
    
    public void GameQuit()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false; //play모드를 false로.
        #else
            Application.Quit(); //어플리케이션 종료
        #endif
    }
}
