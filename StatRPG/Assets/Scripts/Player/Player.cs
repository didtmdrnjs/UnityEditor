using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : Alive
{
    private GameManager gameManager;
    private PlayerControll playerControll;

    [SerializeField]
    private GameObject HpSlider;
    private float HpPercent;

    public int SkillPoint = 0;
    public int UsedSkillPoint = 0;

    private string job;
    private int WeaponDamage;

    private int HealStandard;

    private bool isCritical;

    private Dictionary<string, float> StatValue = new Dictionary<string, float>();

    private void Start()
    {
        gameManager = GameManager.Instance;
        playerControll = gameObject.GetComponent<PlayerControll>();
        job = gameManager.selectJob.job;
        SkillPoint = 50;

        HealStandard = 0;

        switch (job)
        {
            case "Soldier":
                WeaponDamage = 50;
                break;
            case "Priest":
                WeaponDamage = 5;
                break;
            case "Peasant":
                WeaponDamage = 25;
                break;
            case "Thief":
                WeaponDamage = 30;
                break;
        }
    }

    private void Update()
    {
        SetStat();

        for (int i = 0; i < 12; i++) 
        {
            if (StatValue["Intelligence"] <= 0)
            {
                break;
            }
            else
            {
                if (gameManager.playerStat[i] != "Intelligence")
                {
                    StatValue[gameManager.playerStat[i]] *= 1.05f;
                }
            }
        }

        MaxHP = StatValue["Health"] * 1000;
        if (StatValue["Health"] > HealStandard)
        {
            HP = MaxHP;
            while (StatValue["Health"] > HealStandard)
            {
                HealStandard += 20;
            }
        }
        PhysicsDamage = WeaponDamage * StatValue["Strength"] * 10 * StatValue["AttackSpeed"] * 5;
        CriticalPercent(StatValue["CriticalPercentage"]);
        if (StatValue["CriticalDamage"] > 0 && isCritical)
        {
            PhysicsDamage *= StatValue["CriticalDamage"] * 10;
        }
        ManaDamage = StatValue["Mana"] * 30;
        if (StatValue["ManaEfficiency"] > 0)
        {
            ManaDamage *= StatValue["ManaEfficiency"] * 60;
        }
        playerControll.move_speed = 5 + StatValue["Agility"] * 0.1f;

        HpSlider.GetComponent<Renderer>().material.color = new Color(255, 255, 255, StatValue["SenseOfPain"] * 5/1000);

        HpPercent = HP / MaxHP;
        HpSlider.transform.localScale = new Vector3(HpPercent, 1, 1);
        HpSlider.transform.position -= new Vector3(0.5f - (HpPercent / 2), 0, 0);

        if (HP < 0)
        {
            playerControll.animator.SetBool("isDie", true);
            PlayerPrefs.DeleteKey("isSave");
            SceneManager.LoadScene("Start");
        }

        if (SkillPoint + UsedSkillPoint > 500)
        {
            SkillPoint = 500 - UsedSkillPoint ;
        }
    }

    private void SetStat()
    {
        StatValue = gameManager.DataBaseControll.GetPlayerStatAll();
    }

    private void CriticalPercent(float percent)
    {
        if (Random.Range(0, 100) < percent * 5)
        {
            isCritical = true;
        }
        else
        {
            isCritical = false;
        }
    }

    public override void Hit(float damage)
    {
        if (Random.Range(0, 10000) >= StatValue["Luck"] * 5)
        {
            HP -= damage;
        }
    }
}
