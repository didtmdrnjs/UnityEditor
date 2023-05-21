using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviourPunCallbacks, IPunObservable
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    private new PhotonView photonView;

    private string[,] map;

    private bool[,] WEMap;
    private bool[,] BEMap;

    private string PName;
    private int PNum;
    private int PAlp;

    private bool BenpL;
    private bool BenpR;
    private int BenpA;

    private bool WenpL;
    private bool WenpR;
    private int WenpA;

    private bool isWKsC = false;
    private bool isWQsC = false;

    private bool isBKsC = false;
    private bool isBQsC = false;

    private bool isWCheck;
    private bool isBCheck;

    private bool isWCheckmate;
    private bool isBCheckmate;

    private bool isWDefence;
    private bool isBDefence;

    private bool isDraw;
    private bool isWDraw;
    private bool isBDraw;

    private string Turn;

    [SerializeField]
    private Sprite BKing;
    [SerializeField]
    private Sprite BQueen;
    [SerializeField]
    private Sprite BRook;
    [SerializeField]
    private Sprite BBishop;
    [SerializeField]
    private Sprite BKnight;
    [SerializeField]
    private Sprite BPawn;
    [SerializeField]
    private Sprite WKing;
    [SerializeField]
    private Sprite WQueen;
    [SerializeField]
    private Sprite WRook;
    [SerializeField]
    private Sprite WBishop;
    [SerializeField]
    private Sprite WKnight;
    [SerializeField]
    private Sprite WPawn;
    [SerializeField]
    private Sprite None;
    [SerializeField]
    private Sprite EMP;

    [SerializeField]
    private GameObject WBCheck;
    [SerializeField]
    private GameObject WWCheck;

    [SerializeField]
    private GameObject BBCheck;
    [SerializeField]
    private GameObject BWCheck;

    [SerializeField]
    private GameObject Loading;

    [SerializeField]
    private GameObject Result;
    [SerializeField]
    private Text textbox;

    [SerializeField]
    private GameObject WDrawRecive;
    [SerializeField]
    private GameObject BDrawRecive;

    void Update()
    {
        if (isWCheck)
        {
            WWCheck.SetActive(true);
            BWCheck.SetActive(true);
        }
        else if (isBCheck)
        {
            WBCheck.SetActive(true);
            BBCheck.SetActive(true);
        }
        else
        {
            WWCheck.SetActive(false);
            BWCheck.SetActive(false);
            WBCheck.SetActive(false);
            BBCheck.SetActive(false);
        }

        if (isDraw)
        {
            Result.SetActive(true); 
            GameEnd(new Color(10, 10, 10), "Draw");
        }

        WDrawRecive.SetActive(isWDraw);

        BDrawRecive.SetActive(isBDraw);
    }

    private void Awake()
    {
        photonView = gameObject.GetComponent<PhotonView>();

        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        //map = new string[8, 8] { {" ", " ", " ", " ", " ", " ", " ", " "},
        //                         {" ", " ", " ", " ", " ", " ", " ", " "},
        //                         {" ", " ", " ", " ", " ", " ", " ", " "},
        //                         {" ", " ", " ", " ", " ", " ", " ", " "},
        //                         {" ", " ", "BQueen", "BQueen", " ", " ", " ", " "},
        //                         {" ", " ", " ", "BQueen", " ", " ", " ", " "},
        //                         {" ", "WPawn", " ", " ", " ", " ", " ", " "},
        //                         {"WKing", " ", " ", " ", " ", " ", " ", " "} };

        map = new string[8, 8] { {"BRook", "BKnight", "BBishop", "BQueen", "BKing", "BBishop", "BKnight", "BRook"},
                                 {"BPawn", "BPawn", "BPawn", "BPawn", "BPawn", "BPawn", "BPawn", "BPawn"},
                                 {" ", " ", " ", " ", " ", " ", " ", " "},
                                 {" ", " ", " ", " ", " ", " ", " ", " "},
                                 {" ", " ", " ", " ", " ", " ", " ", " "},
                                 {" ", " ", " ", " ", " ", " ", " ", " "},
                                 {"WPawn", "WPawn", "WPawn", "WPawn", "WPawn", "WPawn", "WPawn", "WPawn"},
                                 {"WRook", "WKnight", "WBishop", "WQueen", "WKing", "WBishop", "WKnight", "WRook"} };

        WEMap = new bool[8, 8];
        BEMap = new bool[8, 8];

        Turn = "White";

        WWCheck.SetActive(false);
        WBCheck.SetActive(false);
        BWCheck.SetActive(false);
        BBCheck.SetActive(false);

        Result.SetActive(false);

        WDrawRecive.SetActive(false);
        BDrawRecive.SetActive(false);
    }

    public void ResetWEMap()
    {
        WEMap = new bool[8, 8];
    }
    public void ResetBEMap()
    {
        BEMap = new bool[8, 8];
    }

    public void setP(string name, int num, int alp)
    {
        PName = name;
        PNum = num;
        PAlp = alp;
    }

    public void PrePMove(int num, int alp, string PName, int PNum, int PAlp)
    {
        map[num, alp] = PName;
        map[PNum, PAlp] = " ";
    }

    public void PMove(int num, int alp)
    {
        if ((PName[0] == 'W' && Turn == "White") || (PName[0] == 'B' && Turn == "Black"))
        {
            map[num, alp] = PName;
            map[PNum, PAlp] = " ";
        }
        else
        {
            return;
        }

        if (Turn == "White")
        {
            Turn = "Black";
        }
        else if (Turn == "Black")
        {
            Turn = "White";
        }
    }

    public void setMap(int num, int alp, string value)
    {
        map[num, alp] = value;
    }
    public string getMap(int num, int alp)
    {
        return map[num, alp];
    }

    public void setMap(string[,] value)
    {
        map = value;
    }

    public string[,] getMap()
    {
        return map;
    }

    public void setWEMap(int num, int alp, bool value)
    {
        WEMap[num, alp] = value;
    }
    public bool getWEMap(int num, int alp)
    {
        return WEMap[num, alp];
    }

    public void setBEMap(int num, int alp, bool value)
    {
        BEMap[num, alp] = value;
    }
    public bool getBEMap(int num, int alp)
    {
        return BEMap[num, alp];
    }

    public bool getWenpL()
    {
        return WenpL;
    }

    public void setWenpL(bool value)
    {
        WenpL = value;
    }

    public bool getBenpL()
    {
        return BenpL;
    }

    public void setBenpL(bool value)
    {
        BenpL = value;
    }

    public bool getWenpR()
    {
        return WenpR;
    }

    public void setWenpR(bool value)
    {
        WenpR = value;
    }

    public bool getBenpR()
    {
        return BenpR;
    }

    public void setBenpR(bool value)
    {
        BenpR = value;
    }

    public int getWenpA()
    {
        return WenpA;
    }

    public void setWenpA(int value)
    {
        WenpA = value;
    }

    public int getBenpA()
    {
        return BenpA;
    }

    public void setBenpA(int value)
    {
        BenpA = value;
    }

    public bool getisWKsC()
    {
        return isWKsC;
    }

    public void setisWKsC()
    {
        isWKsC = false;
    }

    public bool getisWQsC()
    {
        return isWQsC;
    }

    public void setisWQsC()
    {
        isWQsC = false;
    }

    public bool getisBKsC()
    {
        return isBKsC;
    }

    public void setisBKsC()
    {
        isBKsC = false;
    }

    public bool getisBQsC()
    {
        return isBQsC;
    }

    public void setisBQsC()
    {
        isBQsC = false;
    }

    public void setisWCheck(bool value)
    {
        isWCheck = value;
    }

    public bool getisWCheck()
    {
        return isWCheck;
    }

    public void setisBCheck(bool value)
    {
        isBCheck = value;
    }

    public bool getisBCheck()
    {
        return isBCheck;
    }

    public void setisWCheckmate(bool value)
    {
        isWCheckmate = value;
    }

    public bool getisWCheckmate()
    {
        return isWCheckmate;
    }

    public void setisBCheckmate(bool value)
    {
        isBCheckmate = value;
    }

    public bool getisBCheckmate()
    {
        return isBCheckmate;
    }

    public void setisWDefence(bool value)
    {
        isWDefence = value;
    }

    public bool getisWDefence()
    {
        return isWDefence;
    }

    public void setisBDefence(bool value)
    {
        isBDefence = value;
    }

    public bool getisBDefence()
    {
        return isBDefence;
    }

    public Sprite getImage(string name)
    {
        switch (name)
        {
            case "WKing": return WKing;
            case "WQueen": return WQueen;
            case "WRook": return WRook;
            case "WBishop": return WBishop;
            case "WKnight": return WKnight;
            case "WPawn": return WPawn;
            case "BKing": return BKing;
            case "BQueen": return BQueen;
            case "BRook": return BRook;
            case "BBishop": return BBishop;
            case "BKnight": return BKnight;
            case "BPawn": return BPawn;
            case " ": return None;
            case "EMP": return EMP;
        }
        return null;
    }

    public void WhoAmI(char color, string name, ref int num, ref int alp)
    {
        if (color == 'W')
        {
            switch (name[0])
            {
                case 'a': alp = 0; break;
                case 'b': alp = 1; break;
                case 'c': alp = 2; break;
                case 'd': alp = 3; break;
                case 'e': alp = 4; break;
                case 'f': alp = 5; break;
                case 'g': alp = 6; break;
                case 'h': alp = 7; break;
            }

            switch (name[1])
            {
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
        else
        {
            switch (name[0])
            {
                case 'a': alp = 7; break;
                case 'b': alp = 6; break;
                case 'c': alp = 5; break;
                case 'd': alp = 4; break;
                case 'e': alp = 3; break;
                case 'f': alp = 2; break;
                case 'g': alp = 1; break;
                case 'h': alp = 0; break;
            }

            switch (name[1])
            {
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

    public string getTurn()
    {
        return Turn;
    }

    public ChessPieces getPieces(string name)
    {
        switch (name)
        {
            case "King": return new King();
            case "Queen": return new Queen();
            case "Rook": return new Rook();
            case "Bishop": return new Bishop();
            case "Knight": return new Knight();
            case "Pawn": return new Pawn();
            case " ": return new ChessPieces();
        }
        return new ChessPieces();
    }

    public void WCheck(bool value)
    {
        WWCheck.SetActive(value);
        BWCheck.SetActive(value);
    }

    public void BCheck(bool value)
    {
        WBCheck.SetActive(value);
        BBCheck.SetActive(value);
    }

    public void GameEnd(Color color, string value)
    {
        textbox.color = color;
        textbox.text = value;

        Invoke("SceneChange", 5f);
    }

    public void ShowResult(bool value)
    {
        Result.SetActive(value);
    }

    public GameObject getLoading()
    {
        return Loading;
    }

    public void setisDraw(bool value)
    {
        isDraw = value;
    }

    public void setisWDraw(bool value)
    {
        isWDraw = value;
    }

    public void setisBDraw(bool value)
    {
        isBDraw = value;
    }

    private void SceneChange()
    {
        SceneManager.LoadScene("Start");
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            foreach (string i in map)
            {
                stream.SendNext(i);
            }
            stream.SendNext(Turn);
            stream.SendNext(WenpL);
            stream.SendNext(WenpR);
            stream.SendNext(WenpA);
            stream.SendNext(BenpL);
            stream.SendNext(BenpR);
            stream.SendNext(BenpA);
            stream.SendNext(isWCheck);
            stream.SendNext(isBCheck);
            stream.SendNext(isWCheckmate);
            stream.SendNext(isBCheckmate);
            stream.SendNext(isWDefence);
            stream.SendNext(isBDefence);
            stream.SendNext(isWDraw);
            stream.SendNext(isBDraw);
            stream.SendNext(isDraw);
        }
        else
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    map[i, j] = (string)stream.ReceiveNext();
                }
            }
            Turn = (string)stream.ReceiveNext();
            WenpL = (bool)stream.ReceiveNext();
            WenpR = (bool)stream.ReceiveNext();
            WenpA = (int)stream.ReceiveNext();
            BenpL = (bool)stream.ReceiveNext();
            BenpR = (bool)stream.ReceiveNext();
            BenpA = (int)stream.ReceiveNext();
            isWCheck = (bool)stream.ReceiveNext();
            isBCheck = (bool)stream.ReceiveNext();
            isWCheckmate = (bool)stream.ReceiveNext();
            isBCheckmate = (bool)stream.ReceiveNext();
            isWDefence = (bool)stream.ReceiveNext();
            isBDefence = (bool)stream.ReceiveNext();
            isWDraw = (bool)stream.ReceiveNext();
            isBDraw = (bool)stream.ReceiveNext();
            isDraw = (bool)stream.ReceiveNext();
        }
    }

    [PunRPC]
    public void mapSync(int i, int j, string newMap)
    {
        map[i, j] = newMap;
    }

    [PunRPC]
    public void TurnSync(string ChangedTurn)
    {
        Turn = ChangedTurn;
    }

    [PunRPC]
    public void DataSync(bool BL, bool BR, int BA, bool WL, bool WR, int WA)
    {
        BenpL = BL;
        BenpR = BR;
        BenpA = BA;
        WenpL = WL;
        WenpR = WR;
        WenpA = WA;
    }

    [PunRPC]
    public void CheckSync(bool WC, bool BC, bool WCM, bool BCM)
    {
        isWCheck = WC;
        isBCheck = BC;
        isWCheckmate = WCM;
        isBCheckmate = BCM;
    }

    [PunRPC]
    public void DefenceSync(bool WD, bool BD)
    {
        isWDefence = WD;
        isBDefence = BD;
    }

    [PunRPC]
    public void DrawSync(bool WD, bool BD, bool D)
    {
        isWDraw = WD;
        isBDraw = BD;
        isDraw = D;
    }

    public void sentMap()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    photonView.RPC("mapSync", RpcTarget.MasterClient, i, j, map[i, j]);
                }
            }
        }
    }

    public void sentTurn()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("TurnSync", RpcTarget.MasterClient, Turn);
        }
    }

    public void sentData()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("DataSync", RpcTarget.MasterClient, BenpL, BenpR, BenpA, WenpL, WenpR, WenpA);
        }
    }

    public void sentCheck()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("CheckSync", RpcTarget.MasterClient, isWCheck, isBCheck, isWCheckmate, isBCheckmate);
        }
    }

    public void sentDefence()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("DefenceSync", RpcTarget.MasterClient, isWDefence, isBDefence);
        }
    }

    public void sentDraw()
    {
        if (!PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("DrawSync", RpcTarget.MasterClient, isWDraw, isBDraw, isDraw);
        }
    }
}