using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI attackSpeedLevelText;
    [SerializeField] private TextMeshProUGUI bulletSpeedLevelText;
    [SerializeField] private TextMeshProUGUI hpLevelText;
    
    private int attackSpeedLv = 1;
    private int bulletSpeedLv = 1;
    private int hpLv = 1;
    
    void Start()
    {
        // 레벨 초기화
        PlayerPrefs.DeleteKey("AttackSpeedLevel");
        PlayerPrefs.DeleteKey("BulletSpeedLevel");
        PlayerPrefs.DeleteKey("HpLevel");

        // 플레이어 강화 정보
        attackSpeedLv = PlayerPrefs.GetInt("AttackSpeedLevel", 1);
        bulletSpeedLv = PlayerPrefs.GetInt("BulletSpeedLevel", 1);
        hpLv = PlayerPrefs.GetInt("HpLevel", 1);
        
        attackSpeedLevelText.text = attackSpeedLv + "Lv";
        bulletSpeedLevelText.text = bulletSpeedLv + "Lv";
        hpLevelText.text = hpLv + "Lv";
    }
    
    public void EnhanceHp()
    {
        // 강화 가격인지, 최대 강화 횟수인지 체크
        if (true && hpLv <= 2)
        {
            hpLv += 1;
            
            hpLevelText.text = hpLv + "Lv";
            PlayerPrefs.SetInt("HpLevel", hpLv);
        }
    }

    public void EnhanceAttackSpeed()
    {
        // 강화 가격인지, 최대 강화 횟수인지 체크
        if (true && attackSpeedLv <= 4)
        {
            attackSpeedLv += 1;
            
            attackSpeedLevelText.text = attackSpeedLv + "Lv";
            PlayerPrefs.SetInt("AttackSpeedLevel", attackSpeedLv);
        }
    }
    
    public void EnhanceBulletSpeed()
    {
        // 강화 가격인지, 최대 강화 횟수인지 체크
        if (true && bulletSpeedLv <= 4)
        {
            bulletSpeedLv += 1;
            
            bulletSpeedLevelText.text = bulletSpeedLv + "Lv";
            PlayerPrefs.SetInt("BulletSpeedLevel", bulletSpeedLv);
        }
    }
}
