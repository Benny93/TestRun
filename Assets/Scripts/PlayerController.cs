using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour {

    public float WalkSpeed = 4f;

    public GameObject DefaultBulletPrefab;

    public float TimeBetweenShots = 1f;

    [SerializeField]
    int score;
    [SerializeField]
    PlayerState state;
    [SerializeField]
    Orientation orientation;

    Animator animator;
    SpriteRenderer spriteRenderer;

    float passedTimeBetweenShots;

    public int Score
    {
        get
        {
            return score;
        }

        set
        {
            score = value;
        }
    }

    enum PlayerState {
        IDLE,
        RUN
    }

    enum Orientation {
        RIGHT,
        LEFT
       
    }   
	
	void Start () {
        animator = this.GetComponent<Animator>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
	}
	
	
	void Update () {
        bool keyInputReceived = false;        
        Vector3 direction = Vector3.zero;

        if (Input.GetKey(KeyCode.D)) {
            keyInputReceived = true;
            spriteRenderer.flipX = false;
            orientation = Orientation.RIGHT;
            ChangePlayerState(PlayerState.RUN);
            direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            keyInputReceived = true;
            spriteRenderer.flipX = true;
            orientation = Orientation.LEFT;
            ChangePlayerState(PlayerState.RUN);
            direction -= Vector3.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            keyInputReceived = true;
            ChangePlayerState(PlayerState.RUN);
            direction -= Vector3.up;
        }
        if (Input.GetKey(KeyCode.W))
        {
            keyInputReceived = true;
            ChangePlayerState(PlayerState.RUN);
            direction += Vector3.up;
        }
        passedTimeBetweenShots += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (passedTimeBetweenShots > TimeBetweenShots)
            {
                passedTimeBetweenShots = 0f;              
                if (direction == Vector3.zero) {
                    float polarity = orientation == Orientation.RIGHT ? 1f : -1f;
                    DefaultBullet.Shoot(transform.right * polarity, transform.position, DefaultBulletPrefab);
                }
                else {
                    DefaultBullet.Shoot(direction, transform.position, DefaultBulletPrefab);
                }
            }
        }


        MovePlayer(direction, WalkSpeed);

        if (!keyInputReceived) {
            ChangePlayerState(PlayerState.IDLE);
        }
	}

   

    private void MovePlayer(Vector3 direction, float speed)
    {
        if (state == PlayerState.IDLE) {
            return;
        }               
        // walk movement
        transform.position = Vector3.Lerp(transform.position, transform.position + direction * speed, Time.deltaTime);
        // linear gravity
       // transform.position = Vector3.Lerp(transform.position, transform.position + transform.up * -1f*  fallFactor, Time.deltaTime);
    }

    private void ChangePlayerState(PlayerState nextState)
    {
        if (nextState != state )
        {
            state = nextState;
            switch (state) {
                case PlayerState.RUN:
                    animator.SetBool("RUN", true);
                    spriteRenderer.flipX = false;
                    break;               
                case PlayerState.IDLE:
                    animator.SetBool("RUN", false);
                    break;
            }
         }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<RoadCollider>()) {
            //TODO: Stop bumping into collider
        }
    }

   
}
