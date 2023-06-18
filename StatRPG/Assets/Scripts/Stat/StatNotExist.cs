using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class StatNotExist : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private Dropdown Stat;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    private void Update()
    {
        SetDropDown();
    }

    private void SetDropDown()
    {
        Stat.options.Clear();

        Stat.options.Add(new Dropdown.OptionData("Ω∫≈» º±≈√"));

        foreach (string Statname in gameManager.DataBaseControll.GetOtherStat(gameManager.playerStat)) {
            Stat.options.Add(new Dropdown.OptionData(Statname));
        }
    }

    public void AddStat()
    {
        if (Stat.value != 0)
        {
            int count = 0;
            foreach (string name in gameManager.playerStat)
            {
                if (name == null)
                {
                    break;
                }
                count++;
            }
            gameManager.playerStat[count] = gameManager.Statname[Stat.options[Stat.value].text];
            gameManager.playerStatValue[count] = gameManager.DataBaseControll.GetStatMinValue(Stat.options[Stat.value].text);
            Stat.value = 0;
        }
    }
}
