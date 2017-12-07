using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

    public GameObject LeftSpawnArea;
    public GameObject RightSpawnArea;
    public GameObject EnemyPrefab;

    public PlayerController Player;

    public float TimeBetweenSpawns = 5f;

    
    float passedTimeBetweenSpawns = 0f;

    void Start () {
       
	}
	
	
	void Update () {
        passedTimeBetweenSpawns += Time.deltaTime;
        if (passedTimeBetweenSpawns > TimeBetweenSpawns) {
            passedTimeBetweenSpawns = 0f;
            Spawn();
        }
	}

    private void Spawn()
    {
        GameObject enemy = GameObject.Instantiate(EnemyPrefab, transform);
        enemy.GetComponent<DefaultEnemy>().Player = Player;
        int leftOrRight = UnityEngine.Random.Range(0, 1);

        if (leftOrRight == 0)
        {
            //left
            enemy.transform.position = LeftSpawnArea.transform.position + UnityEngine.Random.Range(1.0f, 3.0f) * new Vector3(1.0f, 1.0f, 0f);
        }
        else {
            //right
            enemy.transform.position = RightSpawnArea.transform.position + UnityEngine.Random.Range(1.0f, 3.0f) * new Vector3(1.0f, 1.0f, 0f);
        }
    }
}
