using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : EnemyBase
{
    [HideInInspector]
    public string enemyText;
    public Text enemyTextUI;
    public float enemySpeed;
   

    
    private GameObject player;
    private Canvas canvas;
    private Vector2 direction;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        canvas= transform.GetComponentInChildren<Canvas>();
        canvas.worldCamera = Camera.main.GetComponent<Camera>();
        
    }
    private void Start()
    {
        direction = Vector2.down;
       //enemyText = transform.GetComponentInChildren<Canvas>().GetComponentInChildren<Text>().text;
        enemyTextUI.text = enemyText;
        
    }
    private void Update()
    {
        transform.position +=(Vector3)direction* enemySpeed * Time.deltaTime;
        if(player.GetComponent<Player>().selectedEnemy==this)
        {
            transform.localScale = new Vector3(2, 2, 2);
        }
        else
        {
            transform.localScale = new Vector3(1.5f,1.5f,1.5f);
        }


        //Destroy after crossing the player position

        /*Debug.Log("Player Position" + player.transform.position.y);
        Debug.Log("Enemy Position" + transform.position.y);*/

        if (transform.position.y<-0.5f)
        {
            Debug.Log("Enemy Dead");
            Destroy(this.gameObject);
        }
    }

    private void OnMouseDown()
    {
        player.GetComponent<Player>().selectedEnemy = this;
        //Debug.Log("Selected Enemy Text is "+GetComponentInChildren<Canvas>().GetComponentInChildren<Text>().text);
    }

   
}
