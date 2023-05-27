using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text TimeValue;

    private float time;

    // Start is called before the first frame update
    void Start()
    {
        time = 100;    
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        TimeValue.text = time.ToString();
        if (time <= 0) {
            SceneManager.LoadScene("Result");
        }
    }
}
