using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BallControler : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Vector2 startingVelocity;

    public GameManager gameManager;

    private System.Random randVelx = new System.Random();
    private System.Random randVely = new System.Random();

    public bool x;
    public bool y;

    public float velBall = 5;

    public void ChangeDirections()
    {
        switch (randVelx.Next(1,3))
        {
            case 1:
                x = true;
                break;
            case 2:
                x = false;
                break;
        }

        switch (randVely.Next(1,3))
        {
            case 1:
                y = true;
                break;
            case 2:
                y = false;
                break;
        }

        if(x && y)
        {
            startingVelocity = new Vector2(velBall, velBall);
        }else if(x && !y)
        {
            startingVelocity = new Vector2(velBall, -velBall);
        }else if(!x && y)
        {
            startingVelocity = new Vector2(-velBall, velBall);
        }else if(!x && !y)
        {
            startingVelocity = new Vector2(-velBall, -velBall);
        }
    }

    public void ResetBall()
    {
        switch(gameManager.round)
        {
            case 1:
                velBall = 6.5f;
                break;
            case 2:
                velBall = 7f;
                break;
            case 3:
                velBall = 7.3f;
                break;
        }

        ChangeDirections();

        transform.position = Vector3.zero;

        if(_rb == null)
        {
            _rb = GetComponent<Rigidbody2D>();
        }

        _rb.velocity = startingVelocity;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            Vector2 newVelocity = _rb.velocity;

            newVelocity.y = -newVelocity.y;
            _rb.velocity = newVelocity;
        }

        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Enemy"))
        {
            _rb.velocity = new Vector2(-_rb.velocity.x, _rb.velocity.y);
        }

        if(collision.gameObject.CompareTag("WallPlayer"))
        {
            gameManager.ScorePlayer();
            ResetBall();
        }

        if(collision.gameObject.CompareTag("WallEnemy"))
        {
            gameManager.ScoreEnemy();
            ResetBall();
        }
    }
}
