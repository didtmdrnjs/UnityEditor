using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTurn : MonoBehaviour
{
    GameManager gameManager;

    [SerializeField]
    private Image Turn;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.getTurn() == "White")
        {
            Turn.color = new Color(255, 255, 255);
        }
        else
        {
            Turn.color = new Color(0, 0, 0);
        }
    }
}
