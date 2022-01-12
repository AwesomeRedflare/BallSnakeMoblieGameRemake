using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Blocker : MonoBehaviour
{
    public Text healthText;

    public int minHealth;
    public int maxHealth;
    public int health;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = UnityEngine.Random.ColorHSV();
        health = Random.Range(minHealth, maxHealth);
        healthText.text = health.ToString();
    }

    private void Update()
    {
        healthText.text = health.ToString();

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.name == "delete")
        {
            Destroy(gameObject);
        }
    }
}
