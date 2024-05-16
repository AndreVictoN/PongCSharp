using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst.Intrinsics;
using TMPro;

public class EnemyPaddleController : MonoBehaviour
{
    private Rigidbody2D rb;
    public float botSpeed;

    public float speed = 5f;

    private GameObject ball;

    public TextMeshProUGUI textEnter;

    private System.Random randSpeed = new System.Random();
    
    private WaitForSeconds _delay = new WaitForSeconds(5f);

    public bool newPlayer = false;

    public SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer.color = SaveController.instance.colorEnemy;

        rb = GetComponent<Rigidbody2D>();
        ball = GameObject.Find("Ball");

        if(SaveController.instance.two == true)
        {
            newPlayer = true;

            textEnter.text = "Press RShift to Leave";
        }else
        {
            newPlayer = false;
        }
    }

    void Update()
    {
        CheckKeyEnter();

        if(!newPlayer)
        {
            BotController();
        }else if(newPlayer)
        {
            NewPlayer();
        }
    }

    public void NewPlayer()
    {
        float moveInput = Input.GetAxis("VerticalPlayer2");

        Vector3 newPosition = transform.position + Vector3.up * moveInput * speed * Time.deltaTime;

        newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);

        transform.position = newPosition;
    }

    public void BotController()
    {
        if(ball != null)
        {
            ChangeSpeed();

            float targetY = Mathf.Clamp(ball.transform.position.y, -4.5f, 4.5f);
            
            Vector2 targetPosition = new Vector2(transform.position.x, targetY);

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * botSpeed);
        }
    }

    public void CheckKeyEnter()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            newPlayer = true;
            textEnter.text = "Press RShift to Leave";
        }
        if(Input.GetKeyDown(KeyCode.RightShift))
        {
            newPlayer = false;
            textEnter.text = "Press Enter to Join";
        }
    }

    public void ChangeSpeed()
    {
        botSpeed = randSpeed.Next(5,7);
    }
}
