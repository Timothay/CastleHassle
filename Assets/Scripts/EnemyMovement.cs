using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public GameObject path;
    public NavMeshAgent agent;
    public Animation anim;
    public Rigidbody rb;
    private int pathChosen;
    // Start is called before the first frame update
    void Start()
    {
        string[] paths = { "EnemyPath1", "EnemyPath2", "EnemyPath3", "EnemyPath4", "EnemyPath5", "EnemyPath6" };
        pathChosen = Random.Range(0, 6);
        Debug.Log(pathChosen);
        Debug.Log(paths[pathChosen]);
        path = GameObject.FindGameObjectWithTag(paths[pathChosen]);
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
        agent.SetDestination(path.transform.position);
    }
}
