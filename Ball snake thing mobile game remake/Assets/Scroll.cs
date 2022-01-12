using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{

    public float scrollSpeed;

    private void Update()
    {
        transform.Translate(Vector2.up * scrollSpeed * Time.deltaTime);
    }
}
