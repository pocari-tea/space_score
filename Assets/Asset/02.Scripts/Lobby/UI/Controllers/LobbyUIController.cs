using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyUIController : MonoBehaviour
{
    public void GameStart()
    {
        SceneManager.LoadScene("Game_scenes");
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
