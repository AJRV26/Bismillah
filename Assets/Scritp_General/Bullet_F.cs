using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_F : MonoBehaviour
{
    [Header("Bullet")]
    private Rigidbody2D rb2D;
    public int damage = 2; 
    public float speedB;
     
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {  
       transform.Translate(Vector3.up * speedB * Time.deltaTime);
       Destroy(gameObject, 3f);
    }

}
