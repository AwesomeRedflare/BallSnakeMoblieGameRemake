using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public float o;

    private void Start()
    {
        float i = Random.Range(-o, o);

        transform.position = new Vector2(transform.position.x + i, transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "delete")
        {
            Destroy(gameObject);
        }
    }
}
