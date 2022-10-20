using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherManager : MonoBehaviour
{
    private Animator archerAnimation;
    public float timeToShoot = 10f;
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Animator>().enabled = false;
        archerAnimation = this.GetComponent<Animator>();
    }

    IEnumerator ArcherShoot()
    {
        new WaitForSeconds(2.167f);
        Instantiate(arrow, new Vector3(-17.157f, 13.83f, -34.375f), Quaternion.Euler(0,19,0));
        yield return new WaitForSeconds(timeToShoot);
    }
    // Update is called once per frame
    void Update()
    {
        if(timeToShoot > 0f)
        {
            timeToShoot -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(ArcherShoot());
            timeToShoot = 10f;
        }
    }
}
