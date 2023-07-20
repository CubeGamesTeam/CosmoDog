using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartPanel : MonoBehaviour
{
    [SerializeField] private GameObject[] heartsSprites;

    public void CheckHearts(int hp)
    {
        for(int i = 0; i < heartsSprites.Length; i++)
        {
            if (i < hp)
            {
                heartsSprites[i].SetActive(true);
            }
            else
            {
                heartsSprites[i].SetActive(false);
            }
        }
    }
}
