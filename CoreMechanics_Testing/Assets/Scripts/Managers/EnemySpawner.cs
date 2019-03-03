using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    //public static EnemySpawner spawnerInstance;//Singleton
    public GameObject enemyPrefab;
    public WordPool wp;
    public int waveCount = 1;
    public int enemyCount;
    public int wordCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;
    [HideInInspector]
    public List<Enemy> enemiesList;


    private float horizontalExtent;
    private float verticalExtent;


    private void Start()
    {
        
        verticalExtent = Camera.main.orthographicSize;
        horizontalExtent = verticalExtent * Camera.main.aspect;
        StartCoroutine( SpawnEnemy());
        
    }
    public struct waveComponents
    {
        int enemyCount;
        int bossEnemyCount;
    }


    private void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(startWait);
        while (GameManager.gameManager.player.GetComponent<Player>().isAlive)
        {
            for (int i = 0; i < enemyCount+(5*waveCount); i++)
            {
                GameObject enemyInstance = Instantiate(enemyPrefab);
                enemyInstance.transform.position = new Vector2(Random.Range(-horizontalExtent, horizontalExtent), verticalExtent + 2f);
                enemyInstance.transform.SetParent(transform);
              
                enemyInstance.GetComponent<Enemy>().enemyText = wp.CheckInput(7);//Random Text
                
                enemiesList.Add(enemyInstance.GetComponent<Enemy>());
                yield return new WaitForSeconds(spawnWait);
            }
            waveCount++;
            yield return new WaitForSeconds(waveWait);
        }
    }

    public void RemoveEnemyFromList(Enemy enemy)
    {
        
        enemiesList.Remove(enemy);
    }
   
   
}
