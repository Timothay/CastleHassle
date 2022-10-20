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
        string[] paths = { "EnemyPath1", "EnemyPath2", "EnemyPath3", "EnemyPath4", "EnemyPath5", "EnemyPath6", "EnemyPath7", "EnemyPath8" };
        pathChosen = Random.Range(0, 8);
        path = GameObject.FindGameObjectWithTag(paths[pathChosen]);
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(path.transform.position);
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
            StartCoroutine(EnemyDamaging());

        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.tag == "Hitbox")
        {
            
        }
    }
    IEnumerator EnemyDamaging()
    {
        GameObject.Find("Health").GetComponent<HealthManager>().health -= 5;
        yield return new WaitForSeconds(2);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
