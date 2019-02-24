using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [HideInInspector]
    public  Enemy selectedEnemy;
    public InputField inputField;
    public bool isAlive = true;
    public EnemySpawner enemySpawner;

    private int enemiesCount;
    private string inputFieldText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemiesCount = GameManager.gameManager.enemySpawner.GetComponent<EnemySpawner>().enemiesList.Count;
        Debug.LogWarning(" Enemies Count " + enemiesCount);
        if (enemiesCount>0)
        {

            if (SystemInfo.deviceType==DeviceType.Desktop)
            {
                inputFieldText = inputField.text + "\r";//"\r" for carriage return while taking inputs from resources
            }
            else
            {

            }

           
            if (selectedEnemy != null)//Manual Selection
            {
                if (string.Compare(inputFieldText, selectedEnemy.enemyText, true) == 0)
                {
                    Debug.Log("Text Match Success");
                    enemySpawner.RemoveEnemyFromList(selectedEnemy.GetComponent<Enemy>());
                    Destroy(selectedEnemy.gameObject);
                   // enemySpawner.SelectEnemy();

                    inputField.text = "";

                }
                else
                {
                    //Debug.Log("Text Match Fail");
                }
            }else if(enemiesCount>0)//Match from auto selection
            {
                //Debug.Log("AutoSelect");
                for(int i=0;i<enemiesCount;i++)
                {
                    Enemy enemyInstance = GameManager.gameManager.enemySpawner.GetComponent<EnemySpawner>().enemiesList[i];
                    if (string.Compare(inputFieldText,enemyInstance.enemyText, true) == 0)
                    {
                       // Debug.Log(" Auto Text Match Success");
                        enemySpawner.RemoveEnemyFromList(enemyInstance);
                        Destroy(enemyInstance.gameObject);
                       //enemySpawner.SelectEnemy();

                        inputField.text = "";

                    }
                    else
                    {
                        Debug.Log("Text Match Fail");
                    }
                }
            }
        }
        
    }

    void stringInput(string s)
    {
        string temp="";
        foreach(char c in s)
        {
            //temp += c.ToString()+" ";
            int x = c;
            temp += x.ToString()+" ";
        }
        Debug.Log(temp);
    }
}
