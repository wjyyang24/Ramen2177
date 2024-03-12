using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Checkpoint : MonoBehaviour
{
    public GameObject player;
    public GameObject msgBox;
    public TMP_Text msgField;
    public string msg;

    public GameObject nextMsg;

    // separate pause bool for tutorial and other game messages
    private bool isPaused;

    // if the checkpoint has been completed
    public bool isCompleted;

    public bool garageComplete = false;

    private void Start()
    {
        msgBox.SetActive(false);
        isPaused = false;
        isCompleted = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (!isCompleted && isPaused)
        {
            Time.timeScale = 0;

            // wait for user input
            if (Input.GetKeyDown(KeyCode.Return))
            {
                isPaused = false;
                isCompleted = true;
                Time.timeScale = 1;
                msgBox.SetActive(false);

                // activate next message if applicable
                if (nextMsg) nextMsg.SetActive(true);

                if (garageComplete) PlayerData.Instance.garageCompleted = true;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCompleted && other.gameObject == player)
        {
            isPaused = true;
            print(msg);
            msgField.text = msg;
            msgBox.SetActive(true);
        }
    }
}
