using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject[] enemy;

    private void Start()
    {
        int rand = Random.Range(0, enemy.Length);
        Instantiate(enemy[rand], transform.position, Quaternion.identity);
    }
}
