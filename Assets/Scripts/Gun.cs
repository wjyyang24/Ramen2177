using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public int fireRate = 60; // how many frames should pass between bullets fired
    public int framesPassed = 0; // how many frames have passed since the last bullet fired
    public GameObject barrelStart;
    public GameObject barrelEnd;
    public float force = 20;
    public GameObject BulletPrefab;
    public bool auto = true; // whether the gun fires on its own or needs the player to fire
    private Vector3 endPos;
    public ParticleSystem effect;
    public int lifetime = 10;

    private void Start()
    {
        if (effect) effect.Stop();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (framesPassed < fireRate) framesPassed++;
        else if (auto)
        {
            endPos = new Vector3(barrelEnd.transform.position.x, barrelStart.transform.position.y, barrelEnd.transform.position.z);
            Fire();
            if (effect)
            {
                effect.Stop();
                effect.Play();
            }
        }
    }

    public void Fire()
    {
        Vector3 direction = endPos - barrelStart.transform.position;
        direction.Normalize();
        GameObject bullet = Instantiate(BulletPrefab, transform, true);
        bullet.transform.localPosition = new Vector3(0, 0, 0);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.velocity = direction * force;
        Destroy(bullet, lifetime);
        bullet.transform.SetParent(null);
        framesPassed = 0;
    }
}
