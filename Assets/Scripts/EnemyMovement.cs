using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject hitbox;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        hitbox = GameObject.FindGameObjectWithTag("Hitbox");
        agent = this.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(hitbox.transform.position);
    }
}
