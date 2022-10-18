using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherShoot : MonoBehaviour
{
    public float speed = 2f;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); 
    }

    // Update is called once per frame
    void Update()
    {
        var step = speed * Time.deltaTime;
        Vector3 newDirection = Vector3.RotateTowards(transform.forward, player.transform.position, step, 0.0f);
        transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, step);
    }
}
