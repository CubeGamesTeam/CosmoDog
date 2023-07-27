using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float endX;
    [SerializeField] private float startX;


    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= endX)
        {
            Vector2 pos = new Vector2(startX, transform.position.y);
            transform.position = pos;
        }
    }
}
