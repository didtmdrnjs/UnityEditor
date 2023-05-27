using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetDelete : MonoBehaviour
{
    private float DeleteTime;
    private float currentTime;

    // Start is called before the first frame update
    void Start()
    {
        DeleteTime = 3.5f;
        currentTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= DeleteTime) {
            Destroy(gameObject);
            result.miss++;
        }
    }

    public void Hit() {
        Destroy(gameObject);
    }
}
