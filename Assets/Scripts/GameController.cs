using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    public GameObject enemy;

    void GameStart()
    {
        InvokeRepeating("CreateEnemy", 0, 2);
    }
       
    void EndGame()
    {
        CancelInvoke("CreateEnemy");
    }
    void CreateEnemy()
    {
        float spawnHeight = 10.0f * Random.value - 5;
        GameObject NewEnemy = Instantiate(enemy);
        NewEnemy.transform.position = new Vector2(15.0f, spawnHeight);
    }
 
}
