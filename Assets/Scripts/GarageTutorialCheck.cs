using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarageTutorialCheck : MonoBehaviour
{
    public GameObject checkpoint1;
    public GameObject tutorialBox;

    void Start()
    {
        if (PlayerData.Instance.garageCompleted)
        {
            checkpoint1.SetActive(false);
            tutorialBox.SetActive(false);
        }
    }
}
