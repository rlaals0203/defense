using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.UIElements;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Monster : MonoBehaviour
{
    public float MobDamage = 1;
    public float MobHealth = 5;
    public float MobSpeed = 0.1f;
    public float OriginHealth = 0;
    bool IsAble = true;
    float CritNum = 0;
    float scoreDiff = 0;
    float Level = 0;
    float StartTime = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.Translate(MobSpeed*Time.deltaTime, 0, 0);

        if (gameObject.transform.position.x >= 6)
        {
            GameManager.instance.TowerDamage(MobDamage);
            Destroy(gameObject);
            GameManager.instance.TowerHealthBar();
        }

        if(scoreDiff >= 50)
        {
            MobHealth += 1;
            Level += 1;
            scoreDiff = 0;
        }

        if (Level == 5)
        {
            MobHealth *= 2;
        }

        StartTime += Time.deltaTime;
        if(StartTime > GameManager.instance.CoolTime)
        {
            IsAble = true;
            StartTime = 0;
        }

        // 마우스 클릭시
        if (Input.GetMouseButtonDown(0) && IsAble)
        {
            IsAble = false;
            CritNum = Random.Range(1, 100);
            // 마우스의 포인터 좌표를 카메라 월드 스크린 좌표로 변경한다.
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Raycast함수를 통해 부딪치는 collider를 hit에 리턴.
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero);

            if (hit.collider != null)
            {
                OriginHealth = MobHealth;
                Debug.Log(hit.collider.name);
                // 클릭 오브젝트가 나의 오브젝트와 같다면
                if (hit.collider.gameObject == gameObject)
                {
                    if (CritNum <= GameManager.instance.CriticalChance)
                    {
                        MobHealth -= GameManager.instance.AttackDamage * 2;
                        Debug.Log(MobHealth.ToString());
                    }
                    else
                    {
                        MobHealth -= GameManager.instance.AttackDamage;
                        Debug.Log(MobHealth.ToString());
                    }
                        if (MobHealth <= 0)
                        {
                        GameManager.instance.Score += OriginHealth;
                        GameManager.instance.Money += OriginHealth;
                        scoreDiff = GameManager.instance.Score;
                        Destroy(gameObject);
                        }
                }
            }
        }
    }
}
