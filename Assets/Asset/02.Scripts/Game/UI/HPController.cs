using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPController : MonoBehaviour, IHPObserver
{
    [SerializeField] private PlayerController playerController;
    
    /// <summary>
    /// hp 옵저버
    /// </summary>
    
    [Header("HP 이미지")]
    [SerializeField] private Image hp;

    private void Start()
    {
        playerController.AddHPObserver(this);
        
        Color tempColor = hp.color;
        tempColor.a = 1f;
        hp.color = tempColor;
    }
    
    public void HP()
    {
        Debug.Log("abc");
        Color tempColor = hp.color;
        tempColor.a = 0f;
        hp.color = tempColor;
    }
}
