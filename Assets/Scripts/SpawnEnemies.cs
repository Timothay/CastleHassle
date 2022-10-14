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
    public int numberOfEnemies;
    private int spawnable;
    public int leastNumberOfEnemies = 1;
    public int MaxNumberOfEnemies = 2;
    private float timeToNewSpawn = 7f;
    public int difficultyIncrease = 0;
    private int spawnDistance = 1;
    // Update is called once per frame
    void Update()
    {
        if (timeToNewSpawn > 0f)
        {
            timeToNewSpawn -= Time.deltaTime;
        }else{
            xPos = Random.Range(-33, 30);
            zPos = Random.Range(-20, -21);
            spawnable = 0;
            numberOfEnemies = Random.Range(leastNumberOfEnemies, MaxNumberOfEnemies + 1);
            StartCoroutine(EnemySpawning());
            timeToNewSpawn = 15f;
            difficultyIncrease += 1;
            if(difficultyIncrease % 8 == 0)
            {
                leastNumberOfEnemies += 1;
            }
            if (difficultyIncrease % 4 == 0)
            {
                
                MaxNumberOfEnemies += 1;
            }
        }

        
    }
    IEnumerator EnemySpawning()
    {
        Vector3[] directions = new Vector3[] { -Vector3.right, Vector3.forward, Vector3.right, -Vector3.forward, -Vector3.right, Vector3.forward, Vector3.right, -Vector3.forward, -Vector3.right, Vector3.forward, Vector3.right, -Vector3.forward };
        for (int i = 0; i < numberOfEnemies; i++)
        {
            clone = Instantiate(walkingEnemies[spawnable], new Vector3(xPos, 4.23f, zPos) + directions[i] * spawnDistance, Quaternion.identity);
        }
        yield return new WaitForSeconds(timeToNewSpawn);
    }
}
