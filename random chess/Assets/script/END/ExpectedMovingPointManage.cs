using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpectedMovingPointManage : PlayControll
{
    [SerializeField]
    private Sprite ExpectedMovingPoint;

    private Image ExpectedMovingPointMark;

    private int alp;
    private int num;

    private char color;

    // Start is called before the first frame update
    void Start()
    {
        color = this.transform.parent.transform.parent.name[0];

        if (color == 'W') {
            switch(this.name[0]) {
                case 'a': alp = 0; break;
                case 'b': alp = 1; break;
                case 'c': alp = 2; break;
                case 'd': alp = 3; break;
                case 'e': alp = 4; break;
                case 'f': alp = 5; break;
                case 'g': alp = 6; break;
                case 'h': alp = 7; break;
            }

            switch(this.name[1]) {
                case '1': num = 7; break;
                case '2': num = 6; break;
                case '3': num = 5; break;
                case '4': num = 4; break;
                case '5': num = 3; break;
                case '6': num = 2; break;
                case '7': num = 1; break;
                case '8': num = 0; break;
            }
        }
        else {
            switch(this.name[0]) {
                case 'a': alp = 7; break;
                case 'b': alp = 6; break;
                case 'c': alp = 5; break;
                case 'd': alp = 4; break;
                case 'e': alp = 3; break;
                case 'f': alp = 2; break;
                case 'g': alp = 1; break;
                case 'h': alp = 0; break;
            }

            switch(this.name[1]) {
                case '1': num = 0; break;
                case '2': num = 1; break;
                case '3': num = 2; break;
                case '4': num = 3; break;
                case '5': num = 4; break;
                case '6': num = 5; break;
                case '7': num = 6; break;
                case '8': num = 7; break;
            }
        }

        ExpectedMovingPointMark = this.GetComponent<Image>();
        ExpectedMovingPointMark.sprite = ExpectedMovingPoint;
        ExpectedMovingPointMark.raycastTarget = false;
    }

    // Update is called once per frame
    void Update()
    {
        ShowEnableMap();
    }

    void ShowEnableMap() {
        if (color == 'W') {
            if (PlayControll.WEnableMap[num, alp]) {
                ExpectedMovingPointMark.color = new Color(255, 255, 255, 1);
            }
            else {
                ExpectedMovingPointMark.color = new Color(255, 255, 255, 0);
            }
        }
        else {
            if (PlayControll.BEnableMap[num, alp]) {
                ExpectedMovingPointMark.color = new Color(255, 255, 255, 1);
            }
            else {
                ExpectedMovingPointMark.color = new Color(255, 255, 255, 0);
            }
        }
    }
}
