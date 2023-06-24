using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSponer : MonoBehaviour
{
    [SerializeField]
    private GameObject Duck;
    [SerializeField]
    private GameObject SliderMan;
    [SerializeField]
    private GameObject Wizard;

    private int MonsterCount;

    // Update is called once per frame
    void Update()
    {
        if (MonsterCount < 100)
        {
            MonsterCount++;
            switch (Random.Range(0, 3))
            {
                case 0:
                    Instantiate(Duck, new Vector3(Random.Range(-120, 121), -2, 0), Quaternion.identity);
                    break;
                case 1:
                    Instantiate(SliderMan, new Vector3(Random.Range(-120, 121), -2, 0), Quaternion.identity);
                    break;
                case 2:
                    Instantiate(Wizard, new Vector3(Random.Range(-120, 121), -2, 0), Quaternion.identity);
                    break;
            }
        }
    }
}
