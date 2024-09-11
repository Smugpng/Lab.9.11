using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    private float enemyCount;
    // Start is called before the first frame update
    void Start()
    {
        enemyCount = Random.Range(5,10);
        for (int i = 0; i < enemyCount; i++)
        {
            Instantiate(enemyPrefab);
        }
    }

}
