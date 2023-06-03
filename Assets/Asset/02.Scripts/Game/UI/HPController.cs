using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour, IHPObserver
{
    [SerializeField] private PlayerController playerController;
    
    private int hpLv;
    
    /// <summary>
    /// hp 옵저버
    /// </summary>
    
    [Header("HP 이미지")]
    [SerializeField] private Image[] hp;

    private void Start()
    {
        hpLv = PlayerPrefs.GetInt("HpLevel", 1) - 1;
        
        playerController.AddHPObserver(this);
        Color tempColor;
        
        for (int i = 0; i < hpLv; i++)
        {
            tempColor = hp[i].color;
            tempColor.a = 1f;
            hp[i].color = tempColor;
        }
    }
    
    public void HP()
    {
        Color tempColor = hp[hpLv - 1].color;
        tempColor.a = 0f;
        hp[hpLv - 1].color = tempColor;

        hpLv -= 1;
    }
}
