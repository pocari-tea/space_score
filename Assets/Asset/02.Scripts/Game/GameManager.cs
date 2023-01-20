using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
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
        if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 1)
        {
            Time.timeScale = 0;
            stop_UI.SetActive(true);
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && Time.timeScale == 0)
        {
            Time.timeScale = 1;
            stop_UI.SetActive(false);
        }
    }
}
