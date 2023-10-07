using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShots;
    public float startTimeBtwShots;

    public GameObject projectile;
    private Transform player;

    public float tiempo = 2f;

    Vector2 randomDestination;
    float range = 5;
    private float DistanciaMaxima = 50f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        SetPosicion();

        timeBtwShots = startTimeBtwShots;
    }

    void Update()
    {
        if(player!= null)
        {
            tiempo -= Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, randomDestination, speed * Time.deltaTime);

            float distancia = Vector2.Distance(player.position, randomDestination);
            if (distancia <= DistanciaMaxima)
            {
                if (timeBtwShots <= 0)
                {
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    timeBtwShots = startTimeBtwShots;
                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
                if (Vector2.Distance(transform.position, randomDestination) < range|| tiempo <= 0)
                {
                    tiempo = 2f;
                    SetPosicion();
                }
            }
        }
    }
    void SetPosicion()
    {
        randomDestination = new Vector2(Random.Range(-10f, 10f), Random.Range(-10f, 10f));
    }
}
