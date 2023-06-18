using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartSettings : MonoBehaviour
{
    [SerializeField]
    private Button ContinueButton;

    void Update()
    {
        if (!PlayerPrefs.HasKey("isSave"))
        {
            ContinueButton.interactable = false;
        }
    }
}
