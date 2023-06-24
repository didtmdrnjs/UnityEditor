using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private GameManager gameManager;

    public float HP;
    public float MaxHP;

    private void Awake()
    {
        MaxHP = 100;
        HP = 100;
    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;
        StartCoroutine(HPsub());
    }

    IEnumerator HPsub()
    {
        yield return new WaitForSeconds(5);
        HP -= 20;
        StartCoroutine(HPsub());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
