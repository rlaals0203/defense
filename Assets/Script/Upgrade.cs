using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{
    public int nBtnType = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void onBnClick()
    {
        switch(nBtnType)
        {
            case 1:
                if (GameManager.instance.Money >= GameManager.instance.UpgradeCost1)
                {
                    GameManager.instance.Money -= GameManager.instance.UpgradeCost1;
                    GameManager.instance.AttackDamage += 1;
                    GameManager.instance.UpgradeCost1 += 10;
                }
                break;

            case 2:
                if (GameManager.instance.Money >= GameManager.instance.UpgradeCost2)
                {
                    Debug.Log("GameManager.instance.Money");
                    GameManager.instance.Money -= GameManager.instance.UpgradeCost2;
                    GameManager.instance.CoolTime -= 0.1f;
                    GameManager.instance.UpgradeCost2 *= 2;
                }
                break;

            case 3:
                if (GameManager.instance.Money >= GameManager.instance.UpgradeCost3)
                {
                    GameManager.instance.Money -= GameManager.instance.UpgradeCost3;
                    GameManager.instance.CriticalChance += 1;
                    GameManager.instance.UpgradeCost3 += 25;
                }
                break;
        }
    }
}
