using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPickUp : MonoBehaviour
{
    public Text healthText;

    public float o;

    public int minHealth;
    public int maxHealth;
    public int healthAmount;

    private void Start()
    {
        GetComponent<SpriteRenderer>().color = UnityEngine.Random.ColorHSV();
        float i = Random.Range(-o, o);

        transform.position = new Vector2(transform.position.x + i, transform.position.y);

        healthAmount = Random.Range(minHealth, maxHealth);
        healthText.text = healthAmount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "delete")
        {
            Destroy(gameObject);
        }
    }
}
