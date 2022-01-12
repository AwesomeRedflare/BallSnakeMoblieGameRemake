using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticallyFollow : MonoBehaviour
{
    private Transform player;
    public float offSet;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, player.transform.position.y + offSet, transform.position.z);
    }
}
