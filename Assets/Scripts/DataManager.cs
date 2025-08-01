using UnityEngine;
using UnityEngine.UI;
using TigerForge;

public class DataManager : MonoBehaviour
{
    
    public static DataManager Instance;

    private int shotBullet;
    public int totalShotBullet;
    private int enemyKilled;
    public int totalEnemyKilled;


    EasyFileSave myFile;
    
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public int ShotBullet
    {
        get
        {
            return shotBullet;
        }
        set
        {
            shotBullet = value;
            GameObject.Find("ShotBulletText").GetComponent<Text>().text = "SHOT BULLET: " + shotBullet.ToString();
        }
    }


    public int EnemyKilled
    {
        get
        {
            return enemyKilled;
        }
        set
        {
            enemyKilled = value;
            GameObject.Find("EnemyKilledText").GetComponent<Text>().text = "ENEMY KILLED: " + enemyKilled.ToString();
            WinProcess();
        }
    }


    void StartProcess()
    {
        myFile = new EasyFileSave();
        LoadData();
    }


    public void SaveData()
    {
        totalShotBullet += shotBullet;
        totalEnemyKilled += EnemyKilled;
        
        myFile.Add("totalShotBullet", totalShotBullet);
        myFile.Add("totalEnemyKilled", totalEnemyKilled);
        
        myFile.Save();
    }


    public void LoadData()
    {
        if (myFile.Load())
        {
            totalShotBullet = myFile.GetInt("totalShotBullet");
            totalEnemyKilled = myFile.GetInt("totalEnemyKilled");
        }
    }


    public void WinProcess()
    {
        if (enemyKilled >= 5)
        {
            print("You Win!");
        }
    }

    public void LoseProcess()
    {
        print("You Lose!");
    }
    
    
    
}
