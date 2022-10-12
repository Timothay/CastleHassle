using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject[] walkingEnemies;
    public GameObject catapult;
    private GameObject clone;
    private int xPos;
    private int zPos;
    private int numberOfEnemies;
    private int leastNumberOfEnemies = 1;
    private int MaxNumberOfEnemies = 1;
    private float timeToNewSpawn = 15f;
    private int difficultyIncrease = 0;
    private int spawnDistance = 1;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (timeToNewSpawn > 0f)
        {
            timeToNewSpawn -= Time.deltaTime;
        }else{
            xPos = Random.Range(1, 6);
            zPos = Random.Range(1, 6);
            numberOfEnemies = Random.Range(leastNumberOfEnemies, MaxNumberOfEnemies + 1);
            StartCoroutine(EnemySpawning());
            timeToNewSpawn = 15f;
            difficultyIncrease += 1;
        }

        if(difficultyIncrease % 2 == 0)
        {
            leastNumberOfEnemies += 1;
            MaxNumberOfEnemies += 1;
        }
    }
    IEnumerator EnemySpawning()
    {

        yield return new WaitForSeconds(timeToNewSpawn);
    }
}
