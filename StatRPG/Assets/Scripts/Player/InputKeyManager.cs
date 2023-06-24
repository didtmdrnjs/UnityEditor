using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputKeyManager : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private GameObject StateWindow;

    private bool isSWOpen = false;

    private void Start()
    {
        gameManager = GameManager.Instance;
        StateWindow = GameObject.Find("StateWindow");
        StateWindow.SetActive(false);
    }

    void Update()
    {
        StateWindows();
        GameEnd();
    }

    private void StateWindows()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!isSWOpen)
            {
                StateWindow.SetActive(true);
                isSWOpen = true;

                gameManager.SetPlayerStat();
                gameManager.SetPlayerStatValue();
            }
            else if (isSWOpen)
            {
                StateWindow.SetActive(false);
                isSWOpen = false;

                gameManager.DataBaseControll.SavePlayerStat(gameManager.playerStat, gameManager.playerStatValue);
                gameManager.playerStat.Clear();
                gameManager.playerStatValue.Clear();
            }
        }
    }

    private void GameEnd()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            PlayerPrefs.SetInt("isSave", 1);
            Application.Quit();
        }
    }
}
