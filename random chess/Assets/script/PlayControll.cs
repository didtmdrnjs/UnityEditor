using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PlayControll : MonoBehaviour
{
    protected static string[, ] map = new string[8, 8]; // 위치 

    protected static bool[, ] WEnableMap = new bool[8, 8];
    protected static bool[, ] BEnableMap = new bool[8, 8];

    protected static string ChoiceChessPieces;
    protected static int ChoiceChessPiecesNum;
    protected static int ChoiceChessPiecesAlp;

    protected static void ResetWEnableMap() {
        WEnableMap = new bool[8, 8];
    }

    protected static void ResetBEnableMap() {
        BEnableMap = new bool[8, 8];
    }

    void Start() {
        map = new string[8, 8] { {"BRook", "BKnight", "BBishop", "BKing", "BQueen", "BBishop", "BKnight", "BRook"},
                                 {"BPawn", "BPawn", "BPawn", "BPawn", "BPawn", "BPawn", "BPawn", "BPawn"},
                                 {" ", " ", " ", " ", " ", " ", " ", " "},
                                 {" ", " ", " ", " ", " ", " ", " ", " "},
                                 {" ", " ", " ", " ", " ", " ", " ", " "},
                                 {" ", " ", " ", " ", " ", " ", " ", " "},
                                 {"WPawn", "WPawn", "WPawn", "WPawn", "WPawn", "WPawn", "WPawn", "WPawn"},
                                 {"WRook", "WKnight", "WBishop", "WKing", "WQueen", "WBishop", "WKnight", "WRook"} };
        ResetWEnableMap();
        ResetBEnableMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}