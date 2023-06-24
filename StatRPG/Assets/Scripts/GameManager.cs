using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    [SerializeField]
    private GameObject DataBaseObject;
    [SerializeField]
    private GameObject Stat;
    [SerializeField]
    private GameObject StatWindow;

    private DataBaseControll dataBaseControll;
    public DataBaseControll DataBaseControll { get { return dataBaseControll; } }

    private SelectJob SelectJob;
    public SelectJob selectJob { get { return SelectJob; } }

    private Player Player;
    public Player player { get { return Player; } }

    private Dictionary<string, string> StatName = new Dictionary<string, string>();
    public Dictionary<string, string> Statname { get { return StatName; } }

    private List<string> PlayerStat = new List<string>(); 
    public List<string> playerStat { get { return PlayerStat; } } 

    private List<int> PlayerStatValue = new List<int>();
    public List<int> playerStatValue { get { return PlayerStatValue; } }

    public GameObject[] Stats = new GameObject[10];

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        dataBaseControll = DataBaseObject.GetComponent<DataBaseControll>();
        SelectJob = GameObject.Find("Select").GetComponent<SelectJob>();

        SetDictionary();
    }

    private void Start()
    {
        Player = GameObject.Find(SelectJob.job + "(Clone)").GetComponent<Player>();
    }

    private void Update()
    {
        if (StatWindow != null)
        {
            CreateStat();
            StopCoroutine(CreateStatC());
        }
        else
        {
            StartCoroutine(CreateStatC());
        }
    }

    IEnumerator CreateStatC()
    {
        yield return null;
        StatWindow = GameObject.Find("StateWindow");
    }

    private void SetDictionary()
    {
        StatName.Add("힘", "Strength");  
        StatName.Add("체력", "Health");
        StatName.Add("민첩", "Agility");
        StatName.Add("마력", "Mana");
        StatName.Add("공격 속도", "AttackSpeed");
        StatName.Add("치명타 데미지", "CriticalDamage");
        StatName.Add("치명타 확률", "CriticalPercentage");
        StatName.Add("마력 효률", "ManaEfficiency");
        StatName.Add("무기 숙련도", "WeaponProficiency");
        StatName.Add("지능", "Intelligence");
        StatName.Add("행운", "Luck");
        StatName.Add("민감도", "SenseOfPain");

        StatName.Add("Strength", "힘");
        StatName.Add("Health", "체력");
        StatName.Add("Agility", "민첩");
        StatName.Add("Mana", "마력");
        StatName.Add("AttackSpeed", "공격 속도");
        StatName.Add("CriticalDamage", "치명타 데미지");
        StatName.Add("CriticalPercentage", "치명타 확률");
        StatName.Add("ManaEfficiency", "마력 효률");
        StatName.Add("WeaponProficiency", "무기 숙련도");
        StatName.Add("Intelligence", "지능");
        StatName.Add("Luck", "행운");
        StatName.Add("SenseOfPain", "민감도");
    }

    private void CreateStat()
    {
        for (int i = 0; i < 10; i++)
        {
            Stats[i] = Instantiate(Stat, new Vector3(0, 0, 0), Quaternion.identity, StatWindow.transform);
        }
    }

    public void SetPlayerStat()
    {
        string[] GetParameter = dataBaseControll.GetPlayerStat();

        for (int i = 0; i < GetParameter.Length; i++)
        {
            PlayerStat.Add(GetParameter[i]);
        }
    }

    public void SetPlayerStatValue()
    {
        int[] GetParameter = dataBaseControll.GetPlayerStatValue();

        for (int i = 0; i < GetParameter.Length; i++)
        {
            PlayerStatValue.Add(GetParameter[i]);
        }
    }
}
