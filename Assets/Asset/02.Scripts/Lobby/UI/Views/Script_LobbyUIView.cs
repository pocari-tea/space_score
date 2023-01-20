using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Script_LobbyUIView : MonoBehaviour
{
    [FormerlySerializedAs("m_Script_LobbyUIController")]
    [Header("스크립트")]
    [SerializeField] private LobbyUIController mLobbyUIController;
    
    public void Button_GameStart()
    {
        mLobbyUIController.GameStart();
    }
    
    public void Button_GameQuit()
    {
        mLobbyUIController.GameQuit();
    }
}
