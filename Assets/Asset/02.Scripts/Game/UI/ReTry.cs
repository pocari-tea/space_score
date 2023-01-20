using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReTry : MonoBehaviour
{
    public void Retry()
    {
        SceneManager.LoadScene("Game_scenes");
    }
}
