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
        //������ ���� ���������� ������ �� ������� ������� � ������ ������� � ����� ��������*����� �����
        transform.position = Vector2.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);

        //���� ����� �� ����� �� �����
        if ((transform.position.y == yIncrement) || (transform.position.y == -yIncrement) || (transform.position.y == 0f))
        {
            if (Input.GetAxisRaw("Vertical") > 0 && transform.position.y < yIncrement)
            {
                PlayerMove(yIncrement); //�����������
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
                PlayerMove(yIncrement); //�����������
            }
            else if (direction < 0 && transform.position.y > -yIncrement)
            {
                PlayerMove(-yIncrement);
            }
        }
    }

    //����� ��� ����������� ������, �������� �������� �� ��� Y
    private void PlayerMove(float increment)
    {
        Instantiate(fireEffect, fireObject.transform);

        if (transform.position.y != 0)                              //���� ����� �� � ������
        {
            targetPos = new Vector2(playerOffsetX, 0);              //�� ����� ������� ������� ����������� �����
        }
        else                                                        //�����
        {
            targetPos = new Vector2(playerOffsetX, increment);  //������ ������� �������� �����, � ����������� �� ����������� ��������
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
                //�����
                onGameOver?.Invoke();
                Destroy(gameObject);
            }
        }   
    }

    

}
