using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text Object;
    public int Score_UI = 0;

    void Update()
    {
        Object.text = Score_UI + "점";
    }

    public void Score_Add()
    {
        Score_UI++;
    }
}
