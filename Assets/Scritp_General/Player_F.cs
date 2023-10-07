using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class Player_F : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed;
    private Rigidbody2D rb2D;

    [Header("Dash")]
    public float activeMoveSpeed;
    public float dashSpeed;
    public float dashLeght = 0.5f, dashCooldown = 1f;
    private float dashCounter;
    private float dashCoolCounter;

    [Header("Rotacion")]
    public Transform weapon;
    private float offset = 90f;

    [Header("Disparo")]
    public Transform shotPoint;
    public GameObject bullet;

    public float timeShots;
    float nextShoop;

    [Header("Disparo")]
    public GameObject ulti;

    [Header("Vida")]
    public float life;
    public float vidaMaxima = 3;
    public Image lifeBar;
    public BarraDeVida barraDeVida;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        activeMoveSpeed = speed;
        life = vidaMaxima;
        barraDeVida.IncializarBarraDeVida(life);
    }
    void Update()
    {
        Mov();
        Rot();
        shooting(); 
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Ulti();
        }
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            if (dashCoolCounter <=0 && dashCounter <= 0)
            {
                activeMoveSpeed= dashSpeed;
                dashCounter = dashLeght;
            }
        }
        if(dashCounter > 0) 
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <= 0)
            {
                activeMoveSpeed = speed;
                dashCoolCounter = dashCooldown;
            }
        }
        if(dashCoolCounter > 0)
        {
            dashCoolCounter -= Time.deltaTime;
        }
    }

    void Mov()
    {
        Vector2 playerInput = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        playerInput.Normalize();
        rb2D.velocity = playerInput.normalized * activeMoveSpeed;
    }

    void Rot()
    {
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float playerInput = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, playerInput + offset);
    }

    void shooting()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Time.time > nextShoop)
            {
                nextShoop = Time.time + timeShots;
                Instantiate(bullet, shotPoint.position, shotPoint.rotation);

            }
        }
    }

    public void VidaBaja(int damage)
    {
        life -= damage;
        barraDeVida.CambiarVidaActual(life);
        if (life <= 0)
        {
            Muerte();
        }

    }

    public void Muerte()
    {
        Destroy(gameObject);
    }

    public void Ulti()
    {
        ulti.SetActive(true);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life -= collision.gameObject.GetComponent<Damage>().value;
        }
    }*/

}
