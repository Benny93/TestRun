using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultBullet : MonoBehaviour {

    public float Speed = 4f;


    float lifeTime;
    float passedTime = 0f;
    Vector3 direction;

    bool isFlying = false;

	void Start () {
		
	}

    
	
	void Update () {
        if (isFlying)
        {
            transform.position = Vector3.Lerp(transform.position, transform.position + direction, Time.deltaTime * Speed);
            passedTime += Time.deltaTime;
            if (passedTime > lifeTime) {
                isFlying = false;
                DestroyBullet(gameObject);
            }
        }
	}    

    public void FlyInDirection(Vector3 direction, float lifeTime)
    {
        this.lifeTime = lifeTime;
        this.direction = direction;
        isFlying = true;
    }


    public static void Shoot(Vector3 direction, Vector3 initPos, GameObject bulletPrefab)
    {      
        GameObject bullet = GameObject.Instantiate(bulletPrefab);
        bullet.transform.position = initPos;
        DefaultBullet defaultBullet = bullet.GetComponent<DefaultBullet>();
        defaultBullet.FlyInDirection(direction, lifeTime: 3f);
      
    }

    static void DestroyBullet(GameObject bullet)
    {
        Destroy(bullet);
    }
}
