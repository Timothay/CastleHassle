using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class RagdollManager : MonoBehaviour
{
    public BoxCollider mainCollider;
    public Rigidbody mainRigidBody;
    public GameObject ThisEnemy;
    public Animator ThisEnemyAnimator;
    Collider[] ragdollColliders;
    Rigidbody[] limbsRigidBodies;
    public int timeForDespawn = 7;
    void Start()
    {
        GetRagdollBits();
        RagdollModeOff();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RagdollModeOn()
    {
        this.GetComponent<NavMeshAgent>().enabled = false;
        ThisEnemyAnimator.enabled = false;
        foreach (Collider coll in ragdollColliders)
        {
            coll.enabled = true;
        }
        foreach (Rigidbody rigid in limbsRigidBodies)
        {
            rigid.isKinematic = false;
        }
        mainCollider.enabled = false;
        mainRigidBody.isKinematic = true;
        WaitAndDestroy();
    }
    void RagdollModeOff()
    {
        this.GetComponent<NavMeshAgent>().enabled = true;
        foreach (Collider coll in ragdollColliders)
        {
            coll.enabled = false;
        }
        foreach(Rigidbody rigid in limbsRigidBodies)
        {
            rigid.isKinematic = true;
        }
        ThisEnemyAnimator.enabled = true;
        mainCollider.enabled = true;
        mainRigidBody.isKinematic = false;

        

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Throwable")
        {
            RagdollModeOn();
            SoundManager.soundManager.PlayHurtSound();
        }
    }

    void WaitAndDestroy()
    {
        Destroy(this.gameObject, 7);
    }
    void GetRagdollBits()
    {
        ragdollColliders = ThisEnemy.GetComponentsInChildren<Collider>();
        limbsRigidBodies = ThisEnemy.GetComponentsInChildren<Rigidbody>();
    }
}
