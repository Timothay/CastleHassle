using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private const float MAX_HEALTH = 1000f;
    public float health = MAX_HEALTH;
    private Image healthBar;
    // Start is called before the first frame update
    void Awake()
    {
        healthBar = this.GetComponent<Image>();
    }
  
    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / MAX_HEALTH;   
    }
   
}
