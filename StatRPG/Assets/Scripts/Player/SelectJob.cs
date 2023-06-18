using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectJob : MonoBehaviour
{
    [SerializeField]
    private GameObject Soldier;
    [SerializeField]
    private GameObject Priest;
    [SerializeField]
    private GameObject Peasant;
    [SerializeField]
    private GameObject Thief;

    public string job;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "InGameScene")
        {
            switch (job)
            {
                case "Soldier":
                    Instantiate(Soldier, new Vector3(0, 0, 0), Quaternion.identity);
                    break;
                case "Priest":
                    Instantiate(Priest, new Vector3(0, 0, 0), Quaternion.identity);
                    break;
                case "Peasant":
                    Instantiate(Peasant, new Vector3(0, 0, 0), Quaternion.identity);
                    break;
                case "Thief":
                    Instantiate(Thief, new Vector3(0, 0, 0), Quaternion.identity);
                    break;
            }
        }
    }

    public void SelectSoldier()
    {
        SceneManager.LoadScene("InGameScene");
        job = "Soldier";
    }

    public void SelectPriest()
    {
        SceneManager.LoadScene("InGameScene");
        job = "Priest";
    }

    public void SelectPeasant()
    {
        SceneManager.LoadScene("InGameScene");
        job = "Peasant";
    }

    public void SelectThief()
    {
        SceneManager.LoadScene("InGameScene");
        job = "Thief";
    }
}
