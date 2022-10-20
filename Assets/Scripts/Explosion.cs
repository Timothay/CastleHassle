using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    [SerializeField] float explosionRadius = 5f;
    [SerializeField] float explosionForce = 500f;

    void onCollisionEnter(Collision collision) 
    {
        var surrondingObjects = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (var obj in surrondingObjects)
        {
            var rb = obj.GetComponent<Rigidbody>();
            if (rb == null) continue;

            rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }
    }
}
