using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPart : MonoBehaviour
{
    public float speed;
    private GameObject player;

    Transform target;

    public float d;
    public float z;

    public float inc;

    
    private void Start()
    {
        GetComponent<SpriteRenderer>().color = UnityEngine.Random.ColorHSV();

        player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<PlayerController>().bodyParts.Add(gameObject);

        gameObject.name = player.GetComponent<PlayerController>().bodyParts.Count.ToString();

        transform.position = new Vector2(player.transform.position.x, (player.GetComponent<PlayerController>().bodyParts.Count * d) - z);

        if(player.GetComponent<PlayerController>().bodyParts.Count - 1 <= 0)
        {
            target = player.transform;
        }
        else
        {
            target = player.GetComponent<PlayerController>().bodyParts[player.GetComponent<PlayerController>().bodyParts.Count - 2].transform;
        }

       // target = transform.parent.GetChild(transform.parent.childCount - 1).transform.position;


        for (int i = 0; i < player.GetComponent<PlayerController>().bodyParts.Count; i++)
        {
            speed *= inc;
        }


        Debug.Log(target);
    }

    
    private void Update()
    {
        float x = Mathf.Lerp(transform.position.x, target.position.x, speed * Time.deltaTime);

        transform.position = new Vector2(x, transform.position.y);

        if(gameObject == player.GetComponent<PlayerController>().bodyParts[player.GetComponent<PlayerController>().bodyParts.Count - 1] && player.GetComponent<PlayerController>().bodyParts.Count > player.GetComponent<PlayerController>().health)
        {
            player.GetComponent<PlayerController>().bodyParts.Remove(gameObject);

           Destroy(gameObject);
        }
    }
}
