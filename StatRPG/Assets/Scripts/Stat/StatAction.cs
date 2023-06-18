using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatAction : MonoBehaviour
{
    private GameManager gameManager;
    private RectTransform rectTransform;

    [SerializeField]
    private GameObject Exist;
    [SerializeField]
    private GameObject NotExist;
    [SerializeField]
    private Text StatName;
    [SerializeField]
    private Text StatValue;
    [SerializeField]
    private Button DeleteButton;

    private int index;

    private void Start()
    {
        gameManager = GameManager.Instance;

        rectTransform = GetComponent<RectTransform>();

        for (int i = 0; i < 10; i++)
        {
            if (ReferenceEquals(gameManager.Stats[i], gameObject))
            {
                index = i;
                if (i % 2 == 0)
                {
                    rectTransform.anchorMin = new Vector2(0.3f, 0.75f - (float)(i / 2 * 0.15f));
                    rectTransform.anchorMax = new Vector2(0.3f, 0.75f - (float)(i / 2 * 0.15f));
                }
                else
                {
                    rectTransform.anchorMin = new Vector2(0.7f, 0.75f - (float)(i / 2 * 0.15f));
                    rectTransform.anchorMax = new Vector2(0.7f, 0.75f - (float)(i / 2 * 0.15f));
                }
                break;
            }
        }

        rectTransform.anchoredPosition = new Vector3(0, 0, 0);
    }

    private void Update()
    {
        if (gameManager.playerStat[index] != null)
        {
            Exist.SetActive(true);
            NotExist.SetActive(false);

            StatName.text = gameManager.Statname[gameManager.playerStat[index]];
            StatValue.text = gameManager.playerStatValue[index].ToString();

            if (StatName.text != "" && !gameManager.DataBaseControll.isDelete(StatName.text))
            {
                DeleteButton.interactable = false;
            }
        }
        else
        {
            NotExist.SetActive(true);
            Exist.SetActive(false);
        }
    }

}
