using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawn : MonoBehaviour
{
    public GameObject[] throwables;
    private float xPos;
    private float zPos;
    public int collisionCount;
    private int spawnable;
    private float timeToNewSpawn = 3f;
    private void Start()
    {

        xPos = Random.Range(-1f, -2.2f);
        zPos = Random.Range(17f, 19f);
        spawnable = Random.Range(1, 12);
        Instantiate(throwables[spawnable], new Vector3(xPos, 12.5f, zPos), Quaternion.identity);

        xPos = Random.Range(-1f, -2.2f);
        zPos = Random.Range(17f, 19f);
        spawnable = Random.Range(1, 12);
        Instantiate(throwables[spawnable], new Vector3(xPos, 12.5f, zPos), Quaternion.identity);

        xPos = Random.Range(-1f, -2.2f);
        zPos = Random.Range(17f, 19f);
        spawnable = Random.Range(1, 12);
        Instantiate(throwables[spawnable], new Vector3(xPos, 12.5f, zPos), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        if(timeToNewSpawn > 0f)
        {
            timeToNewSpawn -= Time.deltaTime;
        }else 
        {
            if (collisionCount < 3) { 
                xPos = Random.Range(-1f, -2.2f);
                zPos = Random.Range(17f, 19f);
                spawnable = Random.Range(1, 12);
                StartCoroutine(SpawnObject());
                timeToNewSpawn = 3f;
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Throwable")
        {
            collisionCount++;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Throwable")
        {
            collisionCount--;
        }
    }
    IEnumerator SpawnObject()
    {
        Instantiate(throwables[spawnable], new Vector3(xPos, 12.5f, zPos), Quaternion.identity);
        yield return new WaitForSeconds(3);
    }
}
