using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float AttackDamage = 1;
    public float CoolTime = 1;
    public float CriticalChance = 10;
    public float TowerHealth = 100;
    public float maxHP = 100;

    public Slider HealthBar;
    public Text ScoreT;
    public Text MoneyT;
    public Text DmgT;
    public Text CoolT;
    public Text CirtT;
    public Text UpgradeT1;
    public Text UpgradeT2;
    public Text UpgradeT3;

    public GameObject Mob1;
    float Mob1SpawnCool = 0;
    public GameObject Mob2;
    float Mob2SpawnCool = 0;
    public GameObject Mob3;
    float Mob3SpawnCool = 0;
    public GameObject Mob4;
    float Mob4SpawnCool = 0;

    public GameObject Tower;
    public float Score = 0;
    public float Money = 0;
    public int UpgradeCost1 = 10;
    public int UpgradeCost2 = 10;
    public int UpgradeCost3 = 10;

    public static GameManager instance
    {
        get
        {
            return self;
        }
    }
    private static GameManager self;


    void Awake()
    {
        if (self)
        {
            DestroyImmediate(gameObject);
            return;
        }
        self = this;

        DontDestroyOnLoad(gameObject); //  게임 매니저가 지속되도록 한다
    }

    // Start is called before the first frame update
    void Start()
    {
        TowerHealthBar();
        Mob1SpawnCool = Random.Range(5.0f, 10.0f);
        Mob2SpawnCool = Random.Range(7.5f, 15.0f);
        Mob3SpawnCool = Random.Range(20.0f, 25.0f);
        Mob4SpawnCool = Random.Range(25.0f, 35.0f);

        InvokeRepeating("SpawnTime1", 0.1f, Mob1SpawnCool);
        InvokeRepeating("SpawnTime2", 0.1f, Mob2SpawnCool);
        InvokeRepeating("SpawnTime3", 0.1f, Mob3SpawnCool);
        InvokeRepeating("SpawnTime4", 0.1f, Mob4SpawnCool);
        //InvokeRepeating("InvokeRepeat", 0.1f, 5f);
    }
    void SpawnTime1()
    {
        GameObject mob1 = Instantiate(Mob1, transform.position, transform.rotation);

    }

    void SpawnTime2()
    {
        Instantiate(Mob2, transform.position, transform.rotation);
    }

    void SpawnTime3()
    {
        Instantiate(Mob3, transform.position, transform.rotation);
    }

    void SpawnTime4()
    {
        Instantiate(Mob4, transform.position, transform.rotation);
    }
    // Update is called once per frame
    void Update()
    {
        ScoreText();
        StatText();
        MoneyText();
    }

    public void TowerHealthBar()
    {
        HealthBar.value = TowerHealth / maxHP;
    }

    public void TowerDamage(float Damage)
    {
        TowerHealth -= Damage;
    }
    public void ScoreText()
    {
        ScoreT.text = "점수 : " + Score.ToString();
    }

    public void MoneyText()
    {
        MoneyT.text = "돈 : " + Money.ToString();
    }

    public void StatText()
    {
        DmgT.text = "공격력 : " + AttackDamage.ToString();
        CoolT.text = "쿨타임 : " + CoolTime.ToString();
        CirtT.text = "크리티컬 확률 : " + CriticalChance.ToString() + "%";
        UpgradeT1.text = "가격 : " + UpgradeCost1.ToString();
        UpgradeT2.text = "가격 : " + UpgradeCost2.ToString();
        UpgradeT3.text = "가격 : " + UpgradeCost3.ToString();

    }

    public void InvokeRepeat()
    {
        Mob1SpawnCool = Random.Range(5.0f, 10.0f);
        Mob2SpawnCool = Random.Range(7.5f, 15.0f);
        Mob3SpawnCool = Random.Range(20.0f, 25.0f);
        Mob4SpawnCool = Random.Range(25.0f, 35.0f);

        InvokeRepeating("SpawnTime1", 0.1f, Mob1SpawnCool);
        InvokeRepeating("SpawnTime2", 0.1f, Mob2SpawnCool);
        InvokeRepeating("SpawnTime3", 0.1f, Mob3SpawnCool);
        InvokeRepeating("SpawnTime4", 0.1f, Mob4SpawnCool);
    }
}
