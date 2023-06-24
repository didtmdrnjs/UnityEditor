using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private Player player;
    public  Player Player { get { return player; } }

    private float time;
    public float TimeScore { get { return time; } } 

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        player = GameObject.Find("player").GetComponent<Player>();

        Cursor.visible = false;
        time = 0;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        time += Time.deltaTime;
    }
}
