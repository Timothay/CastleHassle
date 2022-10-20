using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public GameObject gameOverMenu;
    public bool isGameOver;
    private const float MAX_HEALTH = 5000f;
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
        if(health <= 0)
        {
            gameOverMenu.SetActive(true);
        }
    }
   
}
