using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveInput;
    public float sideSpeed;
    public float scrollSpeed;

    public Text healthText;

    public int health;

    public float detectDistance;

    public Transform point;

    public GameObject bodyPart;

    public List<GameObject> bodyParts = new List<GameObject>();

    private void Start()
    {

        GetComponent<SpriteRenderer>().color = UnityEngine.Random.ColorHSV();
        health = 10;
        rb = GetComponent<Rigidbody2D>();

        for (int i = 0; i < health; i++)
        {
            //Vector2 bodyPartPos = new Vector2(transform.position.x, (bodyParts.Count * d) - z);

            Instantiate(bodyPart, transform.position, Quaternion.identity);
        }
    }

    private void Update()
    {
        Debug.DrawRay(point.position, point.TransformDirection(Vector2.up) * 10f, Color.red);

        RaycastHit2D hit = Physics2D.Raycast(point.position, point.TransformDirection(Vector2.up), 10f);

        if(hit.collider != null)
        {
            if (hit.distance < detectDistance && hit.collider.CompareTag("Blocker"))
            {
                Debug.Log("hit");
                hit.collider.GetComponent<Blocker>().health--;
                health--;
            }
        }

        if(health <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
        }

        healthText.text = "Health:" + health.ToString();
    }

    private void FixedUpdate()
    {
        moveInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(moveInput * sideSpeed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("health"))
        {
            for (int i = 0; i < col.GetComponent<HealthPickUp>().healthAmount; i++)
            {
                health++;
                Instantiate(bodyPart, transform.position, Quaternion.identity);
            }

            Destroy(col.gameObject);
        }
    }
}
