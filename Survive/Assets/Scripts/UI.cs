using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    private GameManager gameManager;
    private Player player;

    [SerializeField]
    private Image HPValue;

    [SerializeField]
    private Text TimeScore;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        player = gameManager.Player;
    }

    // Update is called once per frame
    void Update()
    {
        HPValue.rectTransform.anchorMax = new Vector2(player.HP / player.MaxHP, 1);
        TimeScore.text = ((int)gameManager.TimeScore).ToString();
    }
}
