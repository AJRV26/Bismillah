using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public int life;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            life -= collision.gameObject.GetComponent<Bullet>().damage;
            Destroy(collision.gameObject);
            if (life <= 0)
            {
                Destroy(gameObject);
            }

        }

    }

}
