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
        StatName.Add("��", "Strength");  
        StatName.Add("ü��", "Health");
        StatName.Add("��ø", "Agility");
        StatName.Add("����", "Mana");
        StatName.Add("���� �ӵ�", "AttackSpeed");
        StatName.Add("ġ��Ÿ ������", "CriticalDamage");
        StatName.Add("ġ��Ÿ Ȯ��", "CriticalPercentage");
        StatName.Add("���� ȿ��", "ManaEfficiency");
        StatName.Add("���� ���õ�", "WeaponProficiency");
        StatName.Add("����", "Intelligence");
        StatName.Add("���", "Luck");
        StatName.Add("�ΰ���", "SenseOfPain");

        StatName.Add("Strength", "��");
        StatName.Add("Health", "ü��");
        StatName.Add("Agility", "��ø");
        StatName.Add("Mana", "����");
        StatName.Add("AttackSpeed", "���� �ӵ�");
        StatName.Add("CriticalDamage", "ġ��Ÿ ������");
        StatName.Add("CriticalPercentage", "ġ��Ÿ Ȯ��");
        StatName.Add("ManaEfficiency", "���� ȿ��");
        StatName.Add("WeaponProficiency", "���� ���õ�");
        StatName.Add("Intelligence", "����");
        StatName.Add("Luck", "���");
        StatName.Add("SenseOfPain", "�ΰ���");
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
