using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : MonoBehaviour
{
    public float speed;
    private int golpe = 1;

    private Transform player;
    private Vector2 target;

    private float lifeTime = 2.5f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if(player != null) 
        {
            target = new Vector2(player.position.x, player.position.y);
            transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0)
            {
                DestroyProjectile();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Player_F>().VidaBaja(golpe);
            DestroyProjectile();
        }
        if (collision.CompareTag("Pared"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
