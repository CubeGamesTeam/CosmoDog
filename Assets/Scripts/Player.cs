using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    private Vector2 targetPos;

    private float playerOffsetX;

    [SerializeField] private float yIncrement;

    [SerializeField] private float speed;

    [SerializeField] private int _health = 5;
    public int health =>this._health;

    [SerializeField] private int maxHealth = 10;

    [SerializeField] private GameObject fireEffect;
    [SerializeField] private GameObject fireObject;

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


    private void Start()
    {
        targetPos = transform.position;
        playerOffsetX = targetPos.x;
    }

    private void Update()
    {
        //каждый кадр перемещаем игрока из текущей позиции в таргет позицию с шагом скорость*время кадра
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        //если игрок на одной из линий
        if ((transform.position.y == yIncrement) || (transform.position.y == -yIncrement) || (transform.position.y == 0f))
        {
            if (Input.GetAxisRaw("Vertical") > 0 && transform.position.y < yIncrement)
            {
                PlayerMove(yIncrement); //перемещение
            }
            else if (Input.GetAxisRaw("Vertical") < 0 && transform.position.y > -yIncrement)
            {
                PlayerMove(-yIncrement);
            }
        }
    }

    public void MobilePlayerMove(int direction)
    {
        if ((transform.position.y == yIncrement) || (transform.position.y == -yIncrement) || (transform.position.y == 0f))
        {
            if (direction > 0 && transform.position.y < yIncrement)
            {
                PlayerMove(yIncrement); //перемещение
            }
            else if (direction < 0 && transform.position.y > -yIncrement)
            {
                PlayerMove(-yIncrement);
            }
        }
    }

    //Метод для перемещения игрока, получает смещение по оси Y
    private void PlayerMove(float increment)
    {
        Instantiate(fireEffect, fireObject.transform);

        if (transform.position.y != 0)                              //если игрок не в центре
        {
            targetPos = new Vector2(playerOffsetX, 0);              //то задаём целевую позицию центральной линии
        }
        else                                                        //иначе
        {
            targetPos = new Vector2(playerOffsetX, increment);  //задаем целевой позицией линию, в зависимости от полученного смещения
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
