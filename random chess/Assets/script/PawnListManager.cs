using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PawnListManager : PlayControll
{
    [SerializeField]
    private GameObject BSelectionListI;
    [SerializeField]
    private GameObject WSelectionListI;

    private RectTransform BSelectionListP;
    private RectTransform WSelectionListP;

    public static int BI;
    public static int WI;

    // Start is called before the first frame update
    void Start()
    {
        BI = -1;
        WI = -1;
        //BSelectionListI.SetActive(false);
        WSelectionListI.SetActive(false);
        //BSelectionListP = BSelectionListI.GetComponent<RectTransform>();
        WSelectionListP = WSelectionListI.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 8; i++) {
            if (PlayControll.map[0, i] == "WPawn") {
                WSelectionListP.anchorMin = new Vector2(0.125f * i, -3);
                WSelectionListP.anchorMax = new Vector2(0.125f * (i + 1), 1);
                WSelectionListI.SetActive(true);
                WI = i;
            }
        }
        // for (int i = 0; i < 8; i++) {
        //     if (PlayControll.map[7, i] == "BPawn") {
        //         BSelectionListP.anchorMin = new Vector2(0.125f * i, -3);
        //         BSelectionListP.anchorMax = new Vector2(0.125f * (i + 1), 1);
        //         BSelectionListI.SetActive(true);
        //         BI = i;
        //     }
        // }
    }
}
