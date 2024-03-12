using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocket : MonoBehaviour
{
    public GameObject bullet;
    private const int damage = 150;

    // do damage if object with health script is hit
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Enemy")
        {
            print(collision.gameObject.name);
            Health health = collision.gameObject.GetComponent<Health>();
            if (health)
            {
                health.Damage(damage);
            }
            print("hit");
            Destroy(bullet);
        }
    }
}
