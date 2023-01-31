using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] enemies;

    public float timeBetweenSpawns;
    public float maxSpawnTime;
    public float minSpawnTime;
    public float decreaseAmt;

    private float spawnTimer;


    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = timeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer <= 0)
        {
            //do the spawn
            GameObject enemy = enemies[Random.Range(0, enemies.Length)];
            float xPos = Random.Range(-9.0f, 9.0f);
            Vector3 location = new Vector3(xPos, 5.5f, 0f);

            Instantiate(enemy,location,Quaternion.identity);


            //difficulty stuff
            //decrease the spawn time
            timeBetweenSpawns -= decreaseAmt;
            //if the spawn time is less than minimum
            //set spawn time to minimium
            if (timeBetweenSpawns < minSpawnTime)
            {
                timeBetweenSpawns = minSpawnTime;
            }

            //reset timer
            spawnTimer = timeBetweenSpawns;
        } else
        {
            spawnTimer -= Time.deltaTime;
        }
    }

    public void reset()
    {
        timeBetweenSpawns = maxSpawnTime;
        spawnTimer = timeBetweenSpawns;
    }
}
