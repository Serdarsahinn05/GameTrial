using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerMenuScene : MonoBehaviour
{
    public GameObject dataBoard;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }


    public void DataBoardButton()
    {
        DataManager.Instance.LoadData();
        
        dataBoard.transform.GetChild(1).GetComponent<Text>().text = "Total Bullet Shot: " + DataManager.Instance.totalShotBullet.ToString();
        dataBoard.transform.GetChild(2).GetComponent<Text>().text = "Total Enemy Killed: " + DataManager.Instance.totalEnemyKilled.ToString();
        dataBoard.SetActive(true);
    }



    public void XButton()
    {
        dataBoard.SetActive(false);
    }
    
    
}
