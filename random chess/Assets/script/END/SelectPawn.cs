using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPawn : PawnListManager
{
    public void WClicked() {
        PlayControll.map[0, PawnListManager.WI] = "W" + this.name;
        this.transform.parent.gameObject.SetActive(false);
    }

    public void BClicked() {
        PlayControll.map[0, PawnListManager.WI] = "B" + this.name;
        this.transform.parent.gameObject.SetActive(false);
    }
}
    