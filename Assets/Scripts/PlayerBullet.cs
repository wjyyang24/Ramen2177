using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public GameObject bullet;
    // private const int lifetime = 60 * 3; // number of frames the bullet should last
    public int timeLived;
    public int damage = 20;

    // do damage if object with health script is hit
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Player")
        {
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
