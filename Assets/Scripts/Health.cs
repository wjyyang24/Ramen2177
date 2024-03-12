using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public bool isAlive;
    public int maxHp = 150;
    public float hp;
    public GameObject healthBar;
    public Slider healthSlider;
    public GameObject gun;
    public bool isRegen = false; // if the character can regenerate health
    private float regenRate = 0.1f; // amount of hp regenerated per frame
    public GameObject effects;
    public ParticleSystem explosion;
    public ParticleSystem fire;
    public ParticleSystem smoke;
    public Scorekeeper sk;
    public bool isPlayer = false;
    public GameObject extra;

    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
        hp = maxHp;

        effects.SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAlive)
        {
            healthSlider.value = hp / maxHp;
        
            if (hp <= 0)
            {
                isAlive = false;
                print("~~~~~~ DEAD ~~~~~~");
                if (isPlayer) sk.Die("YOU DIED");

                effects.SetActive(true);
                
                var exMain = explosion.main;
                exMain.loop = false;
                ParticleSystem[] exChildren = explosion.GetComponentsInChildren<ParticleSystem>();
                foreach (ParticleSystem child in exChildren)
                {
                    var chMain = child.main;
                    chMain.loop = false;
                }
                explosion.Play();

                var fireMain = fire.main;
                fireMain.loop = true;
                fire.Play();

                var smokeMain = smoke.main;
                smokeMain.loop = true;
                smoke.Play();

                if (gun) gun.SetActive(false);
                if (healthBar) healthBar.SetActive(false);
                if (extra) extra.SetActive(false);
            }

            if (isRegen && hp < maxHp) hp += regenRate;

            if (hp > maxHp) hp = maxHp;
        }
    }

    public void Damage(int damage)
    {
        if (isAlive)
        {
            hp -= damage;
            print($"{damage} damage taken");
            print($"Current hp: {hp}");
        }
        
    }
}
