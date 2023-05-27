using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float x;
    private float y;
    private float CreateDelay;
    private float CurrentDelay;

    [SerializeField]
    private GameObject TargetObject;

    // Start is called before the first frame update
    void Start()
    {
        CreateDelay = 2.5f;
        CurrentDelay = 0;
    }

    // Update is called once per frame
    void Update()
    {
        CurrentDelay -= Time.deltaTime;
        if (CurrentDelay <= 0) {
            CreateTarget();
        }
    }

    private void CreateTarget() {
        x = Random.Range(-5.8f, 5.8f);
        y = Random.Range(-4.8f, 4.8f);
        Instantiate(TargetObject, new Vector3(x, y, -1), Quaternion.identity);
        if (CreateDelay > 0.5) {
            CreateDelay -= CreateDelay / 20;
        }
        CurrentDelay = CreateDelay;
    }
}
