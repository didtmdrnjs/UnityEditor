using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatExist : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private Text StatName;
    [SerializeField]
    private Text StatValue;
    [SerializeField]
    private Text SkillPoint;

    private int index;

    private void Start()
    {
        gameManager = GameManager.Instance;
        SkillPoint = GameObject.Find("StatPoint").GetComponent<Text>();
    }

    private void Update()
    {
        index = gameManager.playerStat.IndexOf(gameManager.Statname[StatName.text]);
        SkillPoint.text = "ÀÜ¿© Æ÷ÀÎÆ® : " + gameManager.player.SkillPoint.ToString();
    }

    public void Plus()
    {
        if (gameManager.player.SkillPoint > 0 && int.Parse(StatValue.text) < gameManager.DataBaseControll.GetStatMaxValue(StatName.text))
        {
            gameManager.player.SkillPoint--;
            gameManager.player.UsedSkillPoint++;
            gameManager.playerStatValue[index]++;
        }
    }

    public void Minus()
    {
        if (int.Parse(StatValue.text) > gameManager.DataBaseControll.GetStatMinValue(StatName.text))
        {
            gameManager.player.UsedSkillPoint--;
            gameManager.player.SkillPoint++;
            gameManager.playerStatValue[index]--;
        }
    }

    public void DeleteStat()
    {
        gameManager.player.UsedSkillPoint -= int.Parse(StatValue.text) - 1;
        gameManager.player.SkillPoint += int.Parse(StatValue.text) - 1;
        gameManager.playerStat.Remove(gameManager.Statname[StatName.text]);
        gameManager.playerStatValue.RemoveAt(index);
        gameManager.playerStat.Add(null);
        gameManager.playerStatValue.Add(0);
    }
}
