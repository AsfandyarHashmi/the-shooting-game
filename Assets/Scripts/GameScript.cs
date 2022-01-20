using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScript : MonoBehaviour
{
    public GameObject[] enemyTypes;

    private static int Round = 0;
    static GameObject[] SpawnPoints;
    private static bool[] SpawnedOnPoint; 
    public static int CurrentNumberOfEnemies = 0;
    // Start is called before the first frame update
    void Start()
    {
        SpawnPoints = GameObject.FindGameObjectsWithTag("EnemySpawnPoint");
        SpawnedOnPoint = new bool[SpawnPoints.Length];
        nextRound();
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentNumberOfEnemies <= 0) {
            nextRound();
        }
    }

    void nextRound() {
        Round++;
        CurrentNumberOfEnemies = Random.Range(1, SpawnPoints.Length);
        Debug.Log("Round #" + Round + ": " + CurrentNumberOfEnemies + " enemies spawned");
        spawnEnemies();
    }

    void spawnEnemies() {
        //List<GameObject> enemies = new List<GameObject>();
        GameObject[] spawnPoints = RandomizeArray(SpawnPoints);
        for(int i = 0; i < CurrentNumberOfEnemies; i++) {
            GameObject enemyToSpawn = enemyTypes[Random.Range(0, enemyTypes.Length)];
            GameObject spawnedEnemy = Instantiate(enemyToSpawn, spawnPoints[i].transform.position, Quaternion.identity);
        }
    }

    private GameObject[] RandomizeArray(GameObject[] arr){
        for (int i = 0; i < arr.Length; i++) {
            GameObject temp = arr[i];
            int randomIndex = Random.Range(i, arr.Length);
            arr[i] = arr[randomIndex];
            arr[randomIndex] = temp;
        }
        return arr;
    }
}
