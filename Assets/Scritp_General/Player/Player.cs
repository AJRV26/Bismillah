using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed;
    private Rigidbody2D rb2D;
    private Vector2 playerInput;

    [Header("Dash")]
    public float activeMSpeed;
    public float dashSpeed;

    private float dashLeght = 0.5f;
    private float dashCoolDown = 1f;

    public float dashCounter;
    private float dashCoolCounter;

    [Header("Rotacion")]
    public Transform weapon;
    private float offset = 90f;

    [Header("Disparo")]
    public Transform shotPoint;
    public GameObject bullet;

    public float timeShots;
    float nextShoop;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Mov();
        Rot();
        Shooting();
        Dash();
    }

    void Mov()
    {
      //Movimiento
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        
        playerInput = new Vector2(moveX, moveY).normalized;
    }

    private void FixedUpdate()
    {
        rb2D.MovePosition(rb2D.position + playerInput * speed * Time.deltaTime);

    }
    void Rot()
    {
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float playerInput = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, playerInput + offset);
    }

    void Shooting()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time > nextShoop)
            {
                nextShoop = Time.time + timeShots;
                Instantiate(bullet, shotPoint.position, shotPoint.rotation);

            }
        }
    }

    void Dash()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            if(dashCoolCounter <= 0 && dashCounter <= 0)
            {
                activeMSpeed = dashSpeed;
                dashCoolDown = dashLeght;
            }

            if(dashCounter > 0)
            {
                dashCoolCounter -= Time.deltaTime;
                if(dashCounter <= 0)
                {
                    activeMSpeed = speed;
                    dashCoolCounter = dashCoolDown;
                }
            }

            if(dashCoolCounter > 0)
            {
                dashCoolCounter -= Time.deltaTime;
            }
        }
    }
}
