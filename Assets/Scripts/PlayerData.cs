using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData Instance;

    // data
    public int Money;
    public bool[] gunsOwned;
    public int equipped;
    public int currLevel;
    public bool lvl1completed;
    public bool lvl2completed;
    public bool garageCompleted;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Money = 0;
        gunsOwned = new bool[] { false, false, false, false };
        equipped = -1;
        currLevel = 0;
        lvl1completed = false;
        lvl2completed = false;
        garageCompleted = false;
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
