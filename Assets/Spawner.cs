using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] dragons;

    //private float spawnInterval;
    private float targetTime;
    public int targetNumber;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
        targetTime = 2;
        targetNumber = 15;
    }
    private void Update()
    {
        targetTime -= Time.deltaTime;
        if (targetTime <= 0 && targetNumber>=0)
        {
            SpawnRandomEnemy();
            targetTime = Random.Range(3, 6);
            targetNumber--;
            //Debug.Log(targetTime);
        }
        //Debug.Log(targetTime);

    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomEnemy()
    {

        int dIndex = Random.Range(0, dragons.Length);

        int spawnX = Random.Range(-45, 45);
        int spawnZ = Random.Range(-45, 45);

        Vector3 spawnPos = new Vector3(spawnX, 0.086f, spawnZ);

        Instantiate(dragons[dIndex], spawnPos, Quaternion.identity);




        //Debug.Log(targetTime);
        //targetTime = 0;

    }
    
}
