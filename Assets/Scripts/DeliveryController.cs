using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DeliveryController : MonoBehaviour
{
    public GameObject deliveryZone;
    public GameObject player;
    public Scorekeeper scorekeeper;
    public int currLevel;
    
    public GameObject msgBox;
    public TMP_Text msgField;
    public string msg;
    
    // separate pause bool for tutorial and other game messages
    private bool isPaused;

    // if the checkpoint has been completed
    private bool isCompleted;

    private void Start()
    {
        msgBox.SetActive(false);
        isPaused = false;
    }

    private void OnTriggerEnter(Collider collider)
    {
        msg = $@"Delivery completed with {scorekeeper.minLeft:d2} minutes and {scorekeeper.secLeft:d2} seconds left
You earned ${1000}!";
        
        if (collider.gameObject == player)
        {
            print("DELIVERY COMPLETED");
            isPaused = true;
            print(msg);
            msgField.text = msg;
            msgBox.SetActive(true);
            isCompleted = true;
            PlayerData.Instance.Money += 1000;
        }
    }

    private void Update()
    {
        if (isPaused)
        {
            Time.timeScale = 0;
        }

        // wait for user input
        if (isCompleted && Input.GetKeyDown(KeyCode.Return))
        {
            if (currLevel == 1)
            {
                PlayerData.Instance.lvl1completed = true;
                UnityEngine.SceneManagement.SceneManager.LoadScene("garage");
            }
            else if (currLevel == 2)
            {
                PlayerData.Instance.lvl2completed = true;
                UnityEngine.SceneManagement.SceneManager.LoadScene("mainMenu");
            }
            else UnityEngine.SceneManagement.SceneManager.LoadScene("mainMenu");
        }
    }
}
