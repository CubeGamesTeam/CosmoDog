using DG.Tweening;
using System.Collections;
using UnityEngine;

public class Enemy_Jumper : MonoBehaviour
{
    [SerializeField] private int damage = 1;
    [SerializeField] private int givenScore = 1;
    [SerializeField] private float speed;

    [SerializeField] private bool isOnLine = true;

    
    [SerializeField] private Vector2 targetPos;

    [SerializeField] private float yIncrement;
    [SerializeField] private Vector2 direction;


    [SerializeField] private DOTweenAnimation deathAnimation;

    [SerializeField] private GameObject deathEffect;

    [SerializeField] private GameObject fireEffect;
    [SerializeField] private GameObject fireObject;

    private void Start()
    {
        //StartCoroutine(ChandgeLine());
    }

    private void Update()
    {
        //direction = new Vector2 (-1, Random.Range(-1, 2));
        transform.Translate(direction * speed * Time.deltaTime);
        IsOnLine();
        //direction = new Vector2 (-1, 0);
        IsOnLine();
        if (isOnLine)
        {
            int rand = Random.Range(0, 3);

            switch (rand)
            {
                case 0:
                    targetPos = new Vector2(transform.position.x - 10, 0);
                    break;
                case 1:
                    targetPos = new Vector2(transform.position.x - 10, yIncrement);
                    break;
                case 2:
                    targetPos = new Vector2(transform.position.x - 10, -yIncrement);
                    break;
                default:
                    targetPos = new Vector2(transform.position.x - 10, 0);
                    break;
            }
            //Instantiate(fireEffect, fireObject.transform);

        }
        //transform.Translate(Vector2.left * speed * Time.deltaTime);
        //transform.Translate(direction * speed * Time.deltaTime);

        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

    }

    private void IsOnLine()
    {
        if ((transform.position.y == yIncrement) || (transform.position.y == -yIncrement) || (transform.position.y == 0f))
        {
            isOnLine = true;
            //direction = new Vector2(-1, Random.Range(-1, 2));
            //if (transform.position.y < yIncrement)
            //{
            //    direction = new Vector2(-1, Random.Range(0, 2));
            //}
            //else if (transform.position.y > -yIncrement)
            //{
            //    direction = new Vector2(-1, Random.Range(-1, 1));
            //}
        }
        else
        {
            isOnLine = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Instantiate(deathEffect,transform.position,Quaternion.identity);
            Player.Instance.GetDamage(damage);
            DestroyEnemy();
        }
        
        if (other.CompareTag("ScoreManager"))
        {
            deathAnimation.DOPlayForward();
        }   
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}

