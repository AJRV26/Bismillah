using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class Player : MonoBehaviour
{
    [Header("Movimiento")]
    public float speed;
    private Rigidbody2D rb2D;
    
    
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
        shooting();
    }

    void Mov()
    {
        Vector2 playerInput = new Vector2 (Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        rb2D.velocity = playerInput.normalized * speed;
    }

    void Rot()
    {
        Vector3 displacement = weapon.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float playerInput = Mathf.Atan2(displacement.y, displacement.x) * Mathf.Rad2Deg;
        weapon.rotation = Quaternion.Euler(0f, 0f, playerInput + offset);
    }

    void shooting()
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

    

}
