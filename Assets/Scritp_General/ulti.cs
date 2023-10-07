using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ulti : MonoBehaviour
{
    float timelife = 0.5f;

    void Update()
    {
        timelife -= Time.deltaTime;
        if (timelife < 0 )
        {
            timelife = 0.5f;
            gameObject.SetActive( false );
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("BulletEnemy")) 
        {
            Destroy(collision.gameObject);
        }
    }
}
