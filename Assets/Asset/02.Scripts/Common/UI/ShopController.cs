using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackSpeedLevelText;
    [SerializeField] private TextMeshProUGUI bulletSpeedLevelText;
    
    private int attackSpeed = 1;
    private int bulletSpeed = 1;
    
    void Start()
    {
        // 레벨 초기화
        PlayerPrefs.DeleteKey("AttackSpeedLevel");
        PlayerPrefs.DeleteKey("BulletSpeedLevel");

        // 플레이어 강화 정보
        attackSpeed = PlayerPrefs.GetInt("AttackSpeedLevel", 1);
        bulletSpeed = PlayerPrefs.GetInt("BulletSpeedLevel", 1);
        
        attackSpeedLevelText.text = attackSpeed + "Lv";
        bulletSpeedLevelText.text = bulletSpeed + "Lv";
    }

    public void EnhanceAttackSpeed()
    {
        // 강화 가격인지, 최대 강화 횟수인지 체크
        if (true && bulletSpeed <= 4)
        {
            attackSpeed += 1;
            
            attackSpeedLevelText.text = attackSpeed + "Lv";
            PlayerPrefs.SetInt("AttackSpeedLevel", attackSpeed);
        }
    }
    
    public void EnhanceBulletSpeed()
    {
        // 강화 가격인지, 최대 강화 횟수인지 체크
        if (true && bulletSpeed <= 4)
        {
            bulletSpeed += 1;
            
            bulletSpeedLevelText.text = bulletSpeed + "Lv";
            PlayerPrefs.SetInt("BulletSpeedLevel", bulletSpeed);
        }
    }
}
