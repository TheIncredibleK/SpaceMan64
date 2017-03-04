using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthTracker : MonoBehaviour {

    public Image healthBar;
    public float maxHealth;
    private float health;
    public GameObject raceController;
    // Use this for initialization
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.fillAmount = health / maxHealth;
        if (health <= 0)
        {
            raceController.GetComponent<raceController>().waypointsController.GetComponent<waypointsController>().gameOver(false);
        }
    }

    public void damagePlayer(float damage)
    {
        health -= damage;
    }

    public void healPlayer(float healing)
    {
        health += healing;
    }
}
