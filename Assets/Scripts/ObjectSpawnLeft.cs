using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawnLeft : MonoBehaviour
{
    public GameObject[] throwables;
    public int collisionCount;
    private int spawnable;
    private float timeToNewSpawn = 3f;

    private void Start()
    {
        spawnable = Random.Range(0, 14);
        Instantiate(throwables[spawnable], this.transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        if(timeToNewSpawn > 0f)
        {
            timeToNewSpawn -= Time.deltaTime;
        }else 
        {
            if (collisionCount == 0) { 
                spawnable = Random.Range(0, 14);
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
        Instantiate(throwables[spawnable], this.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(3);
    }
}
