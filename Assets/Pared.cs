using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("BulletEnemy"))
        {
            Destroy(collision.gameObject);
        }
    }
}
