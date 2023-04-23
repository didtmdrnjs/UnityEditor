using System;
using UnityEngine;
using UnityEngine.UI;

public class ChessMove : ChessImage
{
    protected int alp;
    protected int num;
    protected char color;
    protected Image Tile;

    private static bool BenpL;
    private static bool BenpR;
    private static int BenpA;

    private static bool WenpL;
    private static bool WenpR;
    private static int WenpA;

    private static bool BKsC = true;
    private static bool BQsC = true;

    private static bool WKsC = true;
    private static bool WQsC = true;

    // Start is called before the first frame update
    void Start()
    {
        Tile = this.GetComponent<Image>();
        color = this.transform.parent.transform.parent.name[0];
        WhoAmI();
    }

    // Update is called once per frame
    void Update()
    {
        switch(PlayControll.map[num, alp]) {
            case "BKing": Tile.sprite = ChessImage.BKing; Tile.color = new Color(255, 255, 255, 1); break;
            case "BQueen": Tile.sprite = ChessImage.BQueen; Tile.color = new Color(255, 255, 255, 1); break;
            case "BRook": Tile.sprite = ChessImage.BRook; Tile.color = new Color(255, 255, 255, 1); break;
            case "BBishop": Tile.sprite = ChessImage.BBishop; Tile.color = new Color(255, 255, 255, 1); break;
            case "BKnight": Tile.sprite = ChessImage.BKnight; Tile.color = new Color(255, 255, 255, 1); break;
            case "BPawn": Tile.sprite = ChessImage.BPawn; Tile.color = new Color(255, 255, 255, 1); break;
            case "WKing": Tile.sprite = ChessImage.WKing; Tile.color = new Color(255, 255, 255, 1); break;
            case "WQueen": Tile.sprite = ChessImage.WQueen; Tile.color = new Color(255, 255, 255, 1); break;
            case "WRook": Tile.sprite = ChessImage.WRook; Tile.color = new Color(255, 255, 255, 1); break;
            case "WBishop": Tile.sprite = ChessImage.WBishop; Tile.color = new Color(255, 255, 255, 1); break;
            case "WKnight": Tile.sprite = ChessImage.WKnight; Tile.color = new Color(255, 255, 255, 1); break;
            case "WPawn": Tile.sprite = ChessImage.WPawn; Tile.color = new Color(255, 255, 255, 1); break;
            case " ": Tile.sprite = ChessImage.None; Tile.color = new Color(0, 0, 0, 0); break;
        }
    }

    void WhoAmI() {
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
    }

    private void IsCastlingB()
    {
        if (PlayControll.map[7, 4] != "BKing")
        {
            BKsC = false;
            BQsC = false;
        }
        if (PlayControll.map[7, 7] != "BRook")
        {
            BKsC = false;
        }
        if (PlayControll.map[7, 0] != "BRook")
        {
            BQsC = false;
        }
    }

    private void IsCastlingW()
    {
        if (PlayControll.map[7, 3] != "WKing")
        {
            WKsC = false;
            WQsC = false;
        }
        if (PlayControll.map[7, 0] != "WRook")
        {
            WKsC = false;
        }
        if (PlayControll.map[7, 7] != "WRook")
        {
            WQsC = false;
        }
    }

    public void Clicked() {
        if (color == 'B') {
            if (PlayControll.BEnableMap[num, alp]) {
                if (BenpL && PlayControll.map[num - 1, alp] == "WPawn") {
                    PlayControll.map[num - 1, alp] = " ";
                    BenpL = false;
                    BenpR = false;
                }
                if (BenpR && PlayControll.map[num - 1, alp] == "WPawn") {
                    PlayControll.map[num - 1, alp] = " ";
                    BenpL = false;
                    BenpR = false;
                }
                PlayControll.map[num, alp] = PlayControll.ChoiceChessPieces;
                PlayControll.map[PlayControll.ChoiceChessPiecesNum, PlayControll.ChoiceChessPiecesAlp] = " ";
                IsCastlingB();
                if (PlayControll.map[num, alp][0] == 'B') {
                    if (BenpL && PlayControll.map[3, BenpA - 1] == "WPawn") {
                        BenpL = false;
                    }
                    if (BenpR && PlayControll.map[3, BenpA + 1] == "WPawn") {
                        BenpR = false;
                    }
                }
                if (num == 3 && PlayControll.map[num, alp] == "BPawn") {
                    if (alp == 0) {
                        if (PlayControll.map[num + 1, alp + 1] == " " && PlayControll.map[num, alp + 1] == " ") {
                            BenpR = true;
                            BenpA = alp;
                        }
                    }
                    else if (alp == 7) {
                        if (PlayControll.map[num + 1, alp - 1] == " " && PlayControll.map[num, alp - 1] == " ") {
                            BenpL = true;
                            BenpA = alp;
                        }
                    }
                    else {
                        if (PlayControll.map[num + 1, alp - 1] == " " && PlayControll.map[num, alp - 1] == " ") {
                            BenpL = true;
                            BenpA = alp;
                        }
                        if (PlayControll.map[num + 1, alp + 1] == " " && PlayControll.map[num, alp + 1] == " ") {
                            BenpR = true;
                            BenpA = alp;
                        }
                    }
                }
                else if (num != 3) {
                    BenpL = false;
                    BenpR = false;
                }
                PlayControll.ResetBEnableMap();
            }
            else {
                PlayControll.ResetBEnableMap();
                ClickChessPieces(PlayControll.map[num, alp], 'B');
            }
        }
        else {
            if (PlayControll.WEnableMap[num, alp]) {
                if (WenpL && PlayControll.map[num + 1, alp] == "BPawn") {
                    PlayControll.map[num + 1, alp] = " ";
                    WenpL = false;
                    WenpR = false;
                }
                if (WenpR && PlayControll.map[num + 1, alp] == "BPawn") {
                    PlayControll.map[num + 1, alp] = " ";
                    WenpL = false;
                    WenpR = false;
                }
                PlayControll.map[num, alp] = PlayControll.ChoiceChessPieces;
                PlayControll.map[PlayControll.ChoiceChessPiecesNum, PlayControll.ChoiceChessPiecesAlp] = " ";
                IsCastlingW();
                if (PlayControll.map[num, alp][0] == 'W') {
                    if (WenpL && PlayControll.map[3, WenpA - 1] == "BPawn") {
                        WenpL = false;
                    }
                    if (WenpR && PlayControll.map[3, WenpA + 1] == "BPawn") {
                        WenpR = false;
                    }
                }
                if (num == 3 && PlayControll.map[num, alp] == "WPawn") {
                    if (alp == 0) {
                        if (PlayControll.map[num - 1, alp + 1] == " " && PlayControll.map[num, alp + 1] == " ") {
                            WenpR = true;
                            WenpA = alp;
                        }
                    }
                    else if (alp == 7) {
                        if (PlayControll.map[num - 1, alp - 1] == " " && PlayControll.map[num, alp - 1] == " ") {
                            WenpL = true;
                            WenpA = alp;
                        }
                    }
                    else {
                        if (PlayControll.map[num - 1, alp - 1] == " " && PlayControll.map[num, alp - 1] == " ") {
                            WenpL = true;
                            WenpA = alp;
                        }
                        if (PlayControll.map[num - 1, alp + 1] == " " && PlayControll.map[num, alp + 1] == " ") {
                            WenpR = true;
                            WenpA = alp;
                        }
                    }
                }
                else if (num != 3) {
                    WenpL = false;
                    WenpR = false;
                }
                PlayControll.ResetWEnableMap();
            }
            else {
                PlayControll.ResetWEnableMap();
                ClickChessPieces(PlayControll.map[num, alp], 'W');
            }
        }
    }

    void ClickChessPieces(string chessPieces, char color) {
        if (color == 'B') {
            if (chessPieces[0] == 'B') {
                switch(chessPieces) {
                    case "BKing": 
                        for (int i = -1; i < 2; i++) {
                            for (int j = -1; j < 2; j++) {
                                if ((!(i == 0 && j == 0)) && ((num + i < 8 && alp + j < 8) && (num + i > -1 && alp + j > -1))) {
                                    if (PlayControll.map[num + i, alp + j][0] != 'B') {
                                        PlayControll.BEnableMap[num + i, alp + j] = true;
                                    }
                                }
                            }
                        }
                        break;  
                    case "BQueen":
                        for (int i = 1; i < 8; i++)
                        {
                            if (num + i < 8)
                            {
                                if (PlayControll.map[num + i, alp][0] == 'W')
                                {
                                    PlayControll.BEnableMap[num + i, alp] = true;
                                    break;
                                }
                                else if (PlayControll.map[num + i, alp][0] != 'B')
                                {
                                    PlayControll.BEnableMap[num + i, alp] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (alp + i < 8)
                            {
                                if (PlayControll.map[num, alp + i][0] == 'W')
                                {
                                    PlayControll.BEnableMap[num, alp + i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num, alp + i][0] != 'B')
                                {
                                    PlayControll.BEnableMap[num, alp + i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (num - i >= 0)
                            {
                                if (PlayControll.map[num - i, alp][0] == 'W')
                                {
                                    PlayControll.BEnableMap[num - i, alp] = true;
                                    break;
                                }
                                else if (PlayControll.map[num - i, alp][0] != 'B')
                                {
                                    PlayControll.BEnableMap[num - i, alp] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (alp - i >= 0)
                            {
                                if (PlayControll.map[num, alp - i][0] == 'W')
                                {
                                    PlayControll.BEnableMap[num, alp - i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num, alp - i][0] != 'B')
                                {
                                    PlayControll.BEnableMap[num, alp - i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (num + i < 8 && alp + i < 8)
                            {
                                if (PlayControll.map[num + i, alp + i][0] == 'W')
                                {
                                    PlayControll.BEnableMap[num + i, alp + i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num + i, alp + i][0] != 'B')
                                {
                                    PlayControll.BEnableMap[num + i, alp + i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (alp - i >= 0 && num + i < 8)
                            {
                                if (PlayControll.map[num + i, alp - i][0] == 'W')
                                {
                                    PlayControll.BEnableMap[num + i, alp - i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num + i, alp - i][0] != 'B')
                                {
                                    PlayControll.BEnableMap[num + i, alp - i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (num - i >= 0 && alp - i >= 0)
                            {
                                if (PlayControll.map[num - i, alp - i][0] == 'W')
                                {
                                    PlayControll.BEnableMap[num - i, alp - i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num - i, alp - i][0] != 'B')
                                {
                                    PlayControll.BEnableMap[num - i, alp - i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (alp + i < 8 && num - i >= 0)
                            {
                                if (PlayControll.map[num - i, alp + i][0] == 'W')
                                {
                                    PlayControll.BEnableMap[num - i, alp + i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num - i, alp + i][0] != 'B')
                                {
                                    PlayControll.BEnableMap[num - i, alp + i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        break; 
                    case "BRook":
                        for (int i = 1; i < 8; i++)
                        {
                            if (num + i < 8)
                            {
                                if (PlayControll.map[num + i, alp][0] == 'W')
                                {
                                    PlayControll.BEnableMap[num + i, alp] = true;
                                    break;
                                }
                                else if (PlayControll.map[num + i, alp][0] != 'B')
                                {
                                    PlayControll.BEnableMap[num + i, alp] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (alp + i < 8)
                            {
                                if (PlayControll.map[num, alp + i][0] == 'W')
                                {
                                    PlayControll.BEnableMap[num, alp + i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num, alp + i][0] != 'B')
                                {
                                    PlayControll.BEnableMap[num, alp + i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (num - i >= 0)
                            {
                                if (PlayControll.map[num - i, alp][0] == 'W')
                                {
                                    PlayControll.BEnableMap[num - i, alp] = true;
                                    break;
                                }
                                else if (PlayControll.map[num - i, alp][0] != 'B')
                                {
                                    PlayControll.BEnableMap[num - i, alp] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (alp - i >= 0)
                            {
                                if (PlayControll.map[num, alp - i][0] == 'W')
                                {
                                    PlayControll.BEnableMap[num, alp - i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num, alp - i][0] != 'B')
                                {
                                    PlayControll.BEnableMap[num, alp - i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    case "BBishop":
                        for (int i = 1; i < 8; i++)
                        {
                            if (num + i < 8 && alp + i < 8)
                            {
                                if (PlayControll.map[num + i, alp + i][0] == 'W')
                                {
                                    PlayControll.BEnableMap[num + i, alp + i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num + i, alp + i][0] != 'B')
                                {
                                    PlayControll.BEnableMap[num + i, alp + i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (alp - i >= 0 && num + i < 8)
                            {
                                if (PlayControll.map[num + i, alp - i][0] == 'W')
                                {
                                    PlayControll.BEnableMap[num + i, alp - i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num + i, alp - i][0] != 'B')
                                {
                                    PlayControll.BEnableMap[num + i, alp - i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (num - i >= 0 && alp - i >= 0)
                            {
                                if (PlayControll.map[num - i, alp - i][0] == 'W')
                                {
                                    PlayControll.BEnableMap[num - i, alp - i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num - i, alp - i][0] != 'B')
                                {
                                    PlayControll.BEnableMap[num - i, alp - i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (alp + i < 8 && num - i >= 0)
                            {
                                if (PlayControll.map[num - i, alp + i][0] == 'W')
                                {
                                    PlayControll.BEnableMap[num - i, alp + i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num - i, alp + i][0] != 'B')
                                {
                                    PlayControll.BEnableMap[num - i, alp + i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    case "BKnight":
                        for (int i = -2; i < 3; i++)
                        {
                            for (int j = -2; j < 3; j++)
                            {
                                if (((Math.Abs(i) == 1 && Math.Abs(j) == 2) || (Math.Abs(i) == 2 && Math.Abs(j) == 1)))
                                {
                                    if ((num + i >= 0 && num + i < 8) && (alp + j >= 0 && alp + j < 8))
                                    {
                                        if (PlayControll.map[num + i, alp + j][0] != 'B')
                                        {
                                            PlayControll.BEnableMap[num + i, alp + j] = true;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "BPawn": 
                        if (alp == 0) {
                            if (PlayControll.map[num + 1, alp + 1][0] == 'W') {
                                PlayControll.BEnableMap[num + 1, alp + 1] = true;
                            }
                        }
                        else if (alp == 7) {
                            if (PlayControll.map[num + 1, alp - 1][0] == 'W') {
                                PlayControll.BEnableMap[num + 1, alp - 1] = true;
                            }
                        }
                        else {
                            if (PlayControll.map[num + 1, alp - 1][0] == 'W') {
                                PlayControll.BEnableMap[num + 1, alp - 1] = true;
                            }
                            if (PlayControll.map[num + 1, alp + 1][0] == 'W') {
                                PlayControll.BEnableMap[num + 1, alp + 1] = true;
                            }
                        }
                        if (num == 1) {
                            for (int i = 1; i <= 2; i++) {
                                if (PlayControll.map[num + i, alp] == " ") { 
                                    PlayControll.BEnableMap[num + i, alp] = true;
                                }
                                else {
                                    break;
                                }
                            }
                        }
                        else {
                            if (num + 1 <= 7) {
                                if (PlayControll.map[num + 1, alp] == " ") { 
                                    PlayControll.BEnableMap[num + 1, alp] = true;
                                }
                            }
                        }
                        if (num == 3) {
                            if (BenpL && PlayControll.map[num, alp - 1] == "WPawn") {
                                PlayControll.BEnableMap[num + 1, alp - 1] = true;
                            }
                            else {
                                PlayControll.BEnableMap[num + 1, alp - 1] = false;
                            }
                            if (BenpR && PlayControll.map[num, alp + 1] == "WPawn") {
                                PlayControll.BEnableMap[num + 1, alp + 1] = true;
                            }
                            else {
                                PlayControll.BEnableMap[num + 1, alp + 1] = false;
                            }
                        }
                        break;
                }
            }
            else {
                PlayControll.ResetBEnableMap();
            }
        }
        else if (color == 'W') {
            if (chessPieces[0] == 'W') {
                switch(chessPieces) {
                    case "WKing": 
                        for (int i = -1; i < 2; i++) {
                            for (int j = -1; j < 2; j++) {
                                if (((num + i < 8 && alp + j < 8) && (num + i > -1 && alp + j > -1))) { 
                                    if (PlayControll.map[num + i, alp + j][0] != 'W') {
                                        PlayControll.WEnableMap[num + i, alp + j] = true;
                                    }
                                }
                            }
                        }
                        break;  
                    case "WQueen":
                        for (int i = 1; i < 8; i++)
                        {
                            if (num + i < 8)
                            {
                                if (PlayControll.map[num + i, alp][0] == 'B')
                                {
                                    PlayControll.WEnableMap[num + i, alp] = true;
                                    break;
                                }
                                else if (PlayControll.map[num + i, alp][0] != 'W')
                                {
                                    PlayControll.WEnableMap[num + i, alp] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (alp + i < 8)
                            {
                                if (PlayControll.map[num, alp + i][0] == 'B')
                                {
                                    PlayControll.WEnableMap[num, alp + i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num, alp + i][0] != 'W')
                                {
                                    PlayControll.WEnableMap[num, alp + i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (num - i >= 0)
                            {
                                if (PlayControll.map[num - i, alp][0] == 'B')
                                {
                                    PlayControll.WEnableMap[num - i, alp] = true;
                                    break;
                                }
                                else if (PlayControll.map[num - i, alp][0] != 'W')
                                {
                                    PlayControll.WEnableMap[num - i, alp] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (alp - i >= 0)
                            {
                                if (PlayControll.map[num, alp - i][0] == 'B')
                                {
                                    PlayControll.WEnableMap[num, alp - i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num, alp - i][0] != 'W')
                                {
                                    PlayControll.WEnableMap[num, alp - i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (num + i < 8 && alp + i < 8)
                            {
                                if (PlayControll.map[num + i, alp + i][0] == 'B')
                                {
                                    PlayControll.WEnableMap[num + i, alp + i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num + i, alp + i][0] != 'W')
                                {
                                    PlayControll.WEnableMap[num + i, alp + i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (alp - i >= 0 && num + i < 8)
                            {
                                if (PlayControll.map[num + i, alp - i][0] == 'B')
                                {
                                    PlayControll.WEnableMap[num + i, alp - i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num + i, alp - i][0] != 'W')
                                {
                                    PlayControll.WEnableMap[num + i, alp - i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (num - i >= 0 && alp - i >= 0)
                            {
                                if (PlayControll.map[num - i, alp - i][0] == 'B')
                                {
                                    PlayControll.WEnableMap[num - i, alp - i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num - i, alp - i][0] != 'W')
                                {
                                    PlayControll.WEnableMap[num - i, alp - i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (alp + i < 8 && num - i >= 0)
                            {
                                if (PlayControll.map[num - i, alp + i][0] == 'B')
                                {
                                    PlayControll.WEnableMap[num - i, alp + i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num - i, alp + i][0] != 'W')
                                {
                                    PlayControll.WEnableMap[num - i, alp + i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        break; 
                    case "WRook":
                        for (int i = 1; i < 8; i++)
                        {
                            if (num + i < 8)
                            {
                                if (PlayControll.map[num + i, alp][0] == 'B')
                                {
                                    PlayControll.WEnableMap[num + i, alp] = true;
                                    break;
                                }
                                else if (PlayControll.map[num + i, alp][0] != 'W')
                                {
                                    PlayControll.WEnableMap[num + i, alp] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (alp + i < 8)
                            {
                                if (PlayControll.map[num, alp + i][0] == 'B')
                                {
                                    PlayControll.WEnableMap[num, alp + i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num, alp + i][0] != 'W')
                                {
                                    PlayControll.WEnableMap[num, alp + i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (num - i >= 0)
                            {
                                if (PlayControll.map[num - i, alp][0] == 'B')
                                {
                                    PlayControll.WEnableMap[num - i, alp] = true;
                                    break;
                                }
                                else if (PlayControll.map[num - i, alp][0] != 'W')
                                {
                                    PlayControll.WEnableMap[num - i, alp] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (alp - i >= 0)
                            {
                                if (PlayControll.map[num, alp - i][0] == 'B')
                                {
                                    PlayControll.WEnableMap[num, alp - i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num, alp - i][0] != 'W')
                                {
                                    PlayControll.WEnableMap[num, alp - i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    case "WBishop":
                        for (int i = 1; i < 8; i++)
                        {
                            if (num + i < 8 && alp + i < 8)
                            {
                                if (PlayControll.map[num + i, alp + i][0] == 'B')
                                {
                                    PlayControll.WEnableMap[num + i, alp + i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num + i, alp + i][0] != 'W')
                                {
                                    PlayControll.WEnableMap[num + i, alp + i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (alp - i >= 0 && num + i < 8)
                            {
                                if (PlayControll.map[num + i, alp - i][0] == 'B')
                                {
                                    PlayControll.WEnableMap[num + i, alp - i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num + i, alp - i][0] != 'W')
                                {
                                    PlayControll.WEnableMap[num + i, alp - i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (num - i >= 0 && alp - i >= 0)
                            {
                                if (PlayControll.map[num - i, alp - i][0] == 'B')
                                {
                                    PlayControll.WEnableMap[num - i, alp - i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num - i, alp - i][0] != 'W')
                                {
                                    PlayControll.WEnableMap[num - i, alp - i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        for (int i = 1; i < 8; i++)
                        {
                            if (alp + i < 8 && num - i >= 0)
                            {
                                if (PlayControll.map[num - i, alp + i][0] == 'B')
                                {
                                    PlayControll.WEnableMap[num - i, alp + i] = true;
                                    break;
                                }
                                else if (PlayControll.map[num - i, alp + i][0] != 'W')
                                {
                                    PlayControll.WEnableMap[num - i, alp + i] = true;
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    case "WKnight": 
                        for (int i = -2; i < 3; i++)
                        {
                            for (int j = -2; j < 3; j++)
                            {
                                if(((Math.Abs(i) == 1 && Math.Abs(j) == 2) || (Math.Abs(i) == 2 && Math.Abs(j) == 1)))
                                {
                                    if ((num + i >= 0 && num + i < 8) && (alp + j >= 0 && alp + j < 8))
                                    {
                                        if (PlayControll.map[num + i, alp + j][0] != 'W')
                                        {
                                            PlayControll.WEnableMap[num + i, alp + j] = true;
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    case "WPawn": 
                        if (alp == 0) {
                            if (PlayControll.map[num - 1, alp + 1][0] == 'B') {
                                PlayControll.WEnableMap[num - 1, alp + 1] = true;
                            }
                        }
                        else if (alp == 7) {
                            if (PlayControll.map[num - 1, alp - 1][0] == 'B') {
                                PlayControll.WEnableMap[num - 1, alp - 1] = true;
                            }
                        }
                        else {
                            if (PlayControll.map[num - 1, alp - 1][0] == 'B') {
                                PlayControll.WEnableMap[num - 1, alp - 1] = true;
                            }
                            if (PlayControll.map[num - 1, alp + 1][0] == 'B') {
                                PlayControll.WEnableMap[num - 1, alp + 1] = true;
                            }
                        }
                        if (num == 6) {
                            for (int i = -1; i >= -2; i--) {
                                if (PlayControll.map[num + i, alp] == " ") { 
                                    PlayControll.WEnableMap[num + i, alp] = true;
                                }
                                else {
                                    break;
                                }
                            }
                        }
                        else {
                            if (num - 1 >= 0) {
                                if (PlayControll.map[num - 1, alp] == " ") { 
                                    PlayControll.WEnableMap[num - 1, alp] = true;
                                }
                            }
                        }
                        if (num == 3) {
                            if (WenpL && PlayControll.map[num, alp - 1] == "BPawn") {
                                PlayControll.WEnableMap[num - 1, alp - 1] = true;
                            }
                            else {
                                PlayControll.WEnableMap[num - 1, alp - 1] = false;
                            }
                            if (WenpR && PlayControll.map[num, alp + 1] == "BPawn") {
                                PlayControll.WEnableMap[num - 1, alp + 1] = true;
                            }
                            else {
                                PlayControll.WEnableMap[num - 1, alp + 1] = false;
                            }
                        }
                        break;
                }
            }
            else {
                PlayControll.ResetWEnableMap();
            }
        }
        PlayControll.ChoiceChessPieces = PlayControll.map[num, alp];
        PlayControll.ChoiceChessPiecesNum = num;
        PlayControll.ChoiceChessPiecesAlp = alp;
    }
}
