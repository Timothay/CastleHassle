using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject hitbox;
    public NavMeshAgent agent;
    public Animation anim;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        hitbox = GameObject.FindGameObjectWithTag("Hitbox");
        agent = this.GetComponent<NavMeshAgent>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Hitbox")
        {
            rb.constraints = RigidbodyConstraints.FreezeAll;
            this.GetComponent<EnemyMovement>().enabled = false;
            this.GetComponent<NavMeshAgent>().enabled = false;
            this.GetComponent<Animator>().SetBool("isWalking", false);
            this.GetComponent<Animator>().SetBool("isAttacking", true);
        }
    }
    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(hitbox.transform.position);
    }
}
