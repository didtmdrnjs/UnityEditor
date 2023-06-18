using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using Mono.Data;
using System.Data;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DataBaseControll : MonoBehaviour
{
    private GameManager gameManager;

    [SerializeField]
    private string DataBaseName;

    private string conn;
    private string SqlQuery;

    private int maxvalue;
    private int minvalue;

    IDbConnection dbcon = null;
    IDbCommand dbcmd = null;
    IDataReader reader = null;

    private void Awake()
    {
        conn = SetDataBaseClass.SetDataBase(DataBaseName + ".db");
    }

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void NewGame()
    {
        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        SqlQuery = "delete from PlayerStat where statnum not in (1, 2, 3, 4, 5)";
        dbcmd.CommandText = SqlQuery;
        reader = dbcmd.ExecuteReader();

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;

        SceneManager.LoadScene("SelectJob");
    }

    public void ContinueGame()
    {
        SceneManager.LoadScene("InGameScene");
    }

    public int GetStatMaxValue(string Stat)
    {
        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        SqlQuery = "select maxvalue from AllStat where name = '" + gameManager.Statname[Stat] + "'";
        dbcmd.CommandText = SqlQuery;
        reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            maxvalue =  reader.GetInt32(0);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;

        return maxvalue;
    }

    public int GetStatMinValue(string Stat)
    {
        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        SqlQuery = "select minvalue from AllStat where name = '" + gameManager.Statname[Stat] + "'";
        dbcmd.CommandText = SqlQuery;
        reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            minvalue = reader.GetInt32(0);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;

        return minvalue;
    }

    public string[] GetPlayerStat()
    {
        int count = 0;
        string[] PlayerStat = new string[10];

        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        SqlQuery = "select name from AllStat where statnum in (select statnum from PlayerStat)";
        dbcmd.CommandText = SqlQuery;
        reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            PlayerStat[count] = reader.GetString(0);
            count++;
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close(); 
        dbcon = null;

        return PlayerStat;
    }

    public int[] GetPlayerStatValue()
    {
        int count = 0;
        int[] PlayerStat = new int[10];

        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        SqlQuery = "select curvalue from PlayerStat";
        dbcmd.CommandText = SqlQuery;
        reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            PlayerStat[count] = reader.GetInt32(0);
            count++;
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;

        return PlayerStat;
    }

    public void SavePlayerStat(List<string> PlayerStat, List<int> PlayerStatValue)
    {
        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        SqlQuery = "delete from PlayerStat";
        dbcmd.CommandText = SqlQuery;
        reader = dbcmd.ExecuteReader();

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;

        for (int i = 0; i < PlayerStat.Count; i++)
        {
            if (PlayerStat != null)
            {
                dbcon = new SqliteConnection(conn);
                dbcon.Open();
                dbcmd = dbcon.CreateCommand();
                SqlQuery = "insert into PlayerStat values((select statnum from AllStat where name = '" + PlayerStat[i] + "'), " + PlayerStatValue[i] + ")";
                dbcmd.CommandText = SqlQuery;
                reader = dbcmd.ExecuteReader();

                reader.Close();
                reader = null;
                dbcmd.Dispose();
                dbcmd = null;
                dbcon.Close();
                dbcon = null;
            }
        }
    }

    public bool isDelete(string Stat) 
    {
        int value = 0;

        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        SqlQuery = "select statnum from AllStat where name = '" + gameManager.Statname[Stat] + "'";
        dbcmd.CommandText = SqlQuery;
        dbcmd.ExecuteNonQuery();
        reader = dbcmd.ExecuteReader();

        reader.Read();
        value = reader.GetInt32(0);

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;

        if (value == 1 || value == 2 || value == 3 || value == 4 || value == 5)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    public string[] GetOtherStat(List<string> GetParameter)
    {
        string[] Stat = new string[7];
        int count = 0;

        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        SqlQuery = "select name from AllStat where name not in ('" + GetParameter[0];
        for (int i = 1; i < GetParameter.Count; i++)
        {
            SqlQuery += "', '" + GetParameter[i];
        }
        SqlQuery += "')";
        dbcmd.CommandText = SqlQuery;
        reader = dbcmd.ExecuteReader();

        while (reader.Read()) 
        {
            Stat[count] = gameManager.Statname[reader.GetString(0)];
            count++;
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;

        return Stat;
    }

    public Dictionary<string, float> GetPlayerStatAll()
    {
        Dictionary<string, float> PlayerStatValue = new Dictionary<string, float>();

        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        SqlQuery = "select name, ifnull(curvalue, 0) from AllStat a left outer join PlayerStat p on a.statnum = p.statnum";
        dbcmd.CommandText= SqlQuery;
        reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {
            PlayerStatValue.Add(reader.GetString(0), reader.GetInt32(1));
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close(); 
        dbcon = null;

        return PlayerStatValue;
    }

    public void Query(int a)
    {
        dbcon = new SqliteConnection(conn);
        dbcon.Open();
        dbcmd = dbcon.CreateCommand();
        string SqlQuery = "select a from test";
        dbcmd.CommandText = SqlQuery;
        reader = dbcmd.ExecuteReader();
        
        while (reader.Read())
        {
            //text.text = reader.GetInt32(0).ToString();
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbcon.Close();
        dbcon = null;
    }
}
