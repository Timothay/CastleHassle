using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherManager : MonoBehaviour
{
    private Animator archerAnimation;
    public int timeToShoot = 5;
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        archerAnimation = this.GetComponent<Animator>();
        archerAnimation.SetBool("isShooting", false);
        StartCoroutine(ArcherShoot());
    }

    IEnumerator ArcherShoot()
    {
        archerAnimation.SetBool("isShooting", true);
        Instantiate(arrow, new Vector3(-17.157f, 13.83f, -34.375f), Quaternion.identity);
        new WaitForSeconds(2.167f);      
        archerAnimation.SetBool("isShooting", false);
        yield return new WaitForSeconds(timeToShoot);
    }
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(ArcherShoot());
    }
}
