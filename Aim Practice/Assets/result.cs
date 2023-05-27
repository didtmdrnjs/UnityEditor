using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class result : MonoBehaviour
{
    [SerializeField]
    private Text HitValue;

    [SerializeField]
    private Text MissValue;

    [SerializeField]
    private Text ScoreValue;

    public static int hit;
    public static int miss; 
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = hit * 50 - miss * 10;
        HitValue.text = hit.ToString();
        MissValue.text = miss.ToString();
        ScoreValue.text = score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) {
            SceneManager.LoadScene("Start");
        }
    }
}
