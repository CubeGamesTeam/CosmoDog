using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private Vector2 targetPos;

    [SerializeField] private float yIncrement;

    [SerializeField] private float speed;

    [SerializeField] private float maxHeight;
    [SerializeField] private float minHeight;

    [SerializeField] private int _health = 5;
    public int health =>this._health;

    [SerializeField] private int maxHealth = 10;

    public Action<int> onHealthChanged;
    public Action onGameOver;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }
        Destroy(this.gameObject);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < maxHeight)
        {
            PlayerMove(yIncrement);
        }
        else if (Input.GetKeyDown(KeyCode.S) && transform.position.y > minHeight)
        {
            PlayerMove(-yIncrement);
        }
    }

    private void PlayerMove(float increment)
    {
        if(transform.position.y != 0)
        {
            targetPos = new Vector2(0, 0);
        }
        else
        {
            targetPos = new Vector2(0, 0 + increment);
        }   
    }

    public void GetDamage(int damage)
    {
        if (_health > 1)
        {

            _health -= damage;
            if (_health >= maxHealth)
            {
                _health = maxHealth;
            } 
            onHealthChanged?.Invoke(_health);
        }
        else
        {
            if(damage < 0)
            {
                _health -= damage;
                if (_health >= maxHealth)
                {
                    _health = maxHealth;
                }
                onHealthChanged?.Invoke(_health);
            }
            else
            {
                //Помер
                onGameOver?.Invoke();
                Destroy(gameObject);
            }
        }   
    }

    

}
