using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChessImage : PlayControll
{
    [SerializeField]
    private Sprite BKingR;
    [SerializeField]
    private Sprite BQueenR;
    [SerializeField]
    private Sprite BRookR;
    [SerializeField]
    private Sprite BBishopR;
    [SerializeField]
    private Sprite BKnightR;
    [SerializeField]
    private Sprite BPawnR;
    [SerializeField]
    private Sprite WKingR;
    [SerializeField]
    private Sprite WQueenR;
    [SerializeField]
    private Sprite WRookR;
    [SerializeField]
    private Sprite WBishopR;
    [SerializeField]
    private Sprite WKnightR;
    [SerializeField]
    private Sprite WPawnR;
    [SerializeField]
    private Sprite NoneR;

    protected static Sprite BKing;
    protected static Sprite BQueen;
    protected static Sprite BRook;
    protected static Sprite BBishop;
    protected static Sprite BKnight;
    protected static Sprite BPawn;
    protected static Sprite WKing;
    protected static Sprite WQueen;
    protected static Sprite WRook;
    protected static Sprite WBishop;
    protected static Sprite WKnight;
    protected static Sprite WPawn;
    protected static Sprite None;

    void Start() {
        BKing = BKingR;
        BQueen = BQueenR;
        BRook = BRookR;
        BBishop = BBishopR;
        BKnight = BKnightR;
        BPawn = BPawnR;
        WKing = WKingR;
        WQueen = WQueenR;
        WRook = WRookR;
        WBishop = WBishopR;
        WKnight = WKnightR;
        WPawn = WPawnR;
        None = NoneR;
    }
}
