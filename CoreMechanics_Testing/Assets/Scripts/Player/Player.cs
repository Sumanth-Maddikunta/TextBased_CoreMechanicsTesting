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

    public Text inputDeviceText;

    int count = 0;
    private Touch touch;
    private TouchScreenKeyboard touchKeyboard;
    private int enemiesCount;
    private string inputFieldText;
  

    // Update is called once per frame
    void Update()
    {
        enemiesCount = GameManager.gameManager.enemySpawner.GetComponent<EnemySpawner>().enemiesList.Count;
       // Debug.LogWarning(" Enemies Count " + enemiesCount);
        if (enemiesCount>0)
        {
            

            if (SystemInfo.deviceType == DeviceType.Desktop)
            {
                inputFieldText = inputField.text + "\r";//"\r" for carriage return while taking inputs from resources
            }
            else if (SystemInfo.deviceType == DeviceType.Handheld)
            {
                inputDeviceText.text = "Handheld Mode :-" + inputFieldText
                    +"Taps="+count ;
                touchKeyboard = TouchScreenKeyboard.Open("", TouchScreenKeyboardType.Default, false, false, false, false);
                inputFieldText = touchKeyboard.text+"\r";


                //Select enemy

                touch = Input.GetTouch(0);
                count = touch.tapCount;

                if (touch.phase==TouchPhase.Stationary)
                {
                    selectedEnemy = Physics2D.OverlapCircle(touch.position, 0.2f).GetComponent<Enemy>();
                    if (selectedEnemy != null)
                    {
                        inputDeviceText.text += " SELECTED ENEMY TEXT " + selectedEnemy.enemyText;
                    }
                    else
                    {
                        inputDeviceText.text += " SELECTED ENEMY is NULLLLLL ";
                    }
                }


            }   
            
            if (selectedEnemy != null)//Manual Selection
            {
                if (string.Compare(inputFieldText, selectedEnemy.enemyText, true) == 0)
                {
                    Debug.Log("Text Match Success");
                    GameManager.gameManager.enemySpawner.GetComponent<EnemySpawner>().RemoveEnemyFromList(selectedEnemy.GetComponent<Enemy>());
                   
                    Destroy(selectedEnemy.gameObject);
                   

                    inputField.text = "";
                    touchKeyboard.text = "";

                }
                else
                {
                    //Debug.Log("Text Match Fail");
                }
            }else if(enemiesCount>0)//Match from auto selection
            {
                if(enemiesCount<0)
                {
                    Debug.Log("NULLL");
                }
                //Debug.Log("AutoSelect");
                for(int i=0;i<enemiesCount;i++)
                {
                    Enemy enemyInstance = GameManager.gameManager.enemySpawner.GetComponent<EnemySpawner>().enemiesList[i];
                    if (string.Compare(inputFieldText,enemyInstance.enemyText, true) == 0)
                    {
                        // Debug.Log(" Auto Text Match Success");
                        inputFieldText = "TEXT MATCH SUXCCCCESSSSSS";

                        GameManager.gameManager.enemySpawner.GetComponent<EnemySpawner>().RemoveEnemyFromList(enemyInstance.GetComponent<Enemy>());
                        
                        Destroy(enemyInstance.gameObject);
                     

                        inputField.text = "";
                        touchKeyboard.text = "";

                    }
                    else
                    {
                       // Debug.Log("Text Match Fail");
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
