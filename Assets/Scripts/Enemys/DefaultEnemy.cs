using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultEnemy : MonoBehaviour {


    public PlayerController Player;
    public float TimeBetweenShots = 30f;
    public GameObject Bullet;

    float passedTimeSinceLastShot = 0f;

	void Start () {
		
	}
	
	
	void Update () {
        if (Player != null)
        {
            passedTimeSinceLastShot += Time.deltaTime;
            if (passedTimeSinceLastShot > TimeBetweenShots)
            {
                passedTimeSinceLastShot = 0f;
                Vector3 directionToPlayer = Player.transform.position - transform.position;
                DefaultBullet.Shoot(directionToPlayer.normalized, transform.position + directionToPlayer.normalized * 1.2f, Bullet);
            }
        }
	}

    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<DefaultBullet>())
        {
            // was hit by a bullet
            // destroy bullet
            Destroy(other.gameObject);
            // raise player score
            Model.Instance.PlayerScore += 1;
            // destroy self
            DestroyEnemy(gameObject);
        }
       
    }

    static void DestroyEnemy(GameObject enemy)
    {
        Destroy(enemy);
    }
}
