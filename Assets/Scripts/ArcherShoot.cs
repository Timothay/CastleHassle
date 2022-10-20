using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherShoot : MonoBehaviour
{
    public float speed = 4f;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Throwable")
        {
            other.gameObject.tag = "Throwable";
            other.gameObject.transform.SetParent(this.transform);
        }
        if(other.gameObject.tag == "Player")
        {
            GameObject.Find("Health").GetComponent<HealthManager>().health -= 50;
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, step);
    }
}
