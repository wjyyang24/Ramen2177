using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject bullet;
    // private const int lifetime = 60 * 3; // number of frames the bullet should last
    public int timeLived;
    private const int damage = 20;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        /*if (timeLived < lifetime) timeLived++;
        else
        {
            print("bye");
            Destroy(bullet);
            Destroy(this);
        }*/
    }

    // do damage if object with health script is hit
    // must set and exclude layers to disable friendly fire
    private void OnCollisionEnter(Collision collision)
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
