using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollManager : MonoBehaviour
{
    public BoxCollider mainCollider;
    public Rigidbody mainRigidBody;
    public GameObject ThisEnemy;
    public Animator ThisEnemyAnimator;
    Collider[] ragdollColliders;
    Rigidbody[] limbsRigidBodies;
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
    }
    void RagdollModeOff()
    {
        foreach(Collider coll in ragdollColliders)
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
        }
    }
    void GetRagdollBits()
    {
        ragdollColliders = ThisEnemy.GetComponentsInChildren<Collider>();
        limbsRigidBodies = ThisEnemy.GetComponentsInChildren<Rigidbody>();
    }
}
