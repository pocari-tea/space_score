using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMangager : MonoBehaviour
{
    public static GameMangager instance;
    [SerializeField] private GameObject stop_UI;

    private void Awake()
    {
        Time.timeScale = 1;
    }

    private void Update()
    {
        Time_Stop();
    }

    private void Time_Stop()
    {
        if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            stop_UI.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.P) && Time.timeScale == 0)
        {
            Time.timeScale = 1;
            stop_UI.SetActive(false);
        }
    }
}
