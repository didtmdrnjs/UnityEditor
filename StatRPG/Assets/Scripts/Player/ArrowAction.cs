using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ArrowAction : MonoBehaviour
{
    private float time;
    public int Rotation;

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<CapsuleCollider2D>().isTrigger = false;
        time += Time.deltaTime;
        if (time > 0.933)
        {
            GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color.WithAlpha(1);
            if (time > 2)
            {
                Destroy(gameObject);
            }
            transform.position += new Vector3(Rotation, 0, 0);
        }
        else
        {
            GetComponent<Renderer>().material.color = GetComponent<Renderer>().material.color.WithAlpha(0);
        }
    }
}
