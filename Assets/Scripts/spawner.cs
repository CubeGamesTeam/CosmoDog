using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyVariants;

    private float timeBtwnSpawn;
    public float startTimeBtwnSpawn;
    public float decreaseTime;
    public float minTime = 0.65f;

    private void Update()
    {
        if(timeBtwnSpawn <= 0)
        {
            int rand = Random.Range(0, enemyVariants.Length);
            Instantiate(enemyVariants[rand],transform.position, Quaternion.identity);
            timeBtwnSpawn = startTimeBtwnSpawn;
            if(startTimeBtwnSpawn > minTime)
            {
                startTimeBtwnSpawn -= decreaseTime;
            }
        }
        else
        {
            timeBtwnSpawn -= Time.deltaTime;
        }
    }
}
