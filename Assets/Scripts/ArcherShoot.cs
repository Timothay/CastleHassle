using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherShoot : MonoBehaviour
{
    private float speed = 10f;
    private GameObject player;
    private bool isStopped = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        this.transform.LookAt(player.transform.position);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Throwable")
        {
            isStopped = true;
            other.gameObject.tag = "Throwable";
            this.gameObject.transform.SetParent(other.gameObject.transform);
        }
        if(other.gameObject.tag == "Player")
        {
            GameObject.Find("Health").GetComponent<HealthManager>().health -= 100;
            Destroy(this.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (!isStopped)
        {
            var step = speed * Time.deltaTime;
            transform.position += transform.forward * step;
        }
       
    }
}
