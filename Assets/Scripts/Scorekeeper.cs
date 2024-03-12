using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scorekeeper : MonoBehaviour
{
    // amount of time to complete level in seconds
    public float timeLeft = 6;
    private bool isTimeLeft;
    private bool isDead;

    public GameObject loseBox;
    public TMP_Text failText;

    // time remaining in minutes and seconds
    public int minLeft;
    public int secLeft;
    public TMP_Text timer;

    // percent of reward earned
    public float rewardMult = 1f;

    public int reward = 500;

    private void Start()
    {
        isTimeLeft = true;
        isDead = false;
        loseBox.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // timer
        if (isTimeLeft)
        {
            if (timeLeft > 0)
            {
                if (!isDead) timeLeft -= Time.deltaTime;
            }
            else
            {
                print("Time Fail");
                isTimeLeft = false;
                timeLeft = 0;
            }
        }
        else
        {
            Die("You ran out of time");
        }

        // timed payout
        
    }

    private void FixedUpdate()
    {
        // calculate time remaining
        minLeft = Mathf.FloorToInt(timeLeft / 60);
        secLeft = Mathf.FloorToInt(timeLeft % 60);

        // display time remaining
        timer.text = $"{minLeft:d2}:{secLeft:d2}";
    }

    public void Die(string msg)
    {
        PauseMenu.pausingEnabled = false;
        isDead = true;
        failText.text = msg;
        loseBox.SetActive(true);
        GetComponent<AimGun>().enabled = false;
        GetComponent<CarController>().enabled = false;
        GetComponent<GunController>().enabled = false;
    }
}
