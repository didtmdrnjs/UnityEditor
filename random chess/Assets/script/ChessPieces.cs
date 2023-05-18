using JetBrains.Annotations;
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessPieces
{
    protected int num;
    protected int alp;
    protected char color;

    protected int x;
    protected int y;

    protected int SaveX;
    protected int SaveY;

    public void setPieces(int num, int alp, char color)
    {
        this.num = num;
        this.alp = alp;
        this.color = color;
    }

    public virtual void ShowPoint() {  }

    public virtual void Move(int num, int alp) {  }

    public virtual void setKMap(char color) {  }

    public virtual void isCheckmate(char color) {  }

    public virtual void isDefence(char color) {  }
}
