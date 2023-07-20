using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    //public int apples = 1;
    public float temperature = 36.6f;

    [SerializeField] private int apples;
    [SerializeField] private int bananas;
    public string myName = "Roma";

    private void Awake()
    {
        
    }

    private void Start()
    {
        SayHello(myName);
    }

    private void Update()
    {
        
    }

    private int Sum()
    {
        int c = apples + bananas;
        Debug.Log(c);
        return c;
    }


    private void SayHello(string name)
    {
        Debug.Log("Hello, " + name);
    }
} 
