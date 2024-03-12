using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public Gun gun;
    public GameObject[] guns;

    private void Start()
    {
        if (PlayerData.Instance.equipped > -1) gun = guns[PlayerData.Instance.equipped].GetComponent<Gun>();
        for (int i = 0; i < guns.Length; i++)
        {
            if (i == PlayerData.Instance.equipped) guns[i].SetActive(true);
            else guns[i].SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gun)
        {
            if (Input.GetMouseButton(0)) gun.auto = true;
            else gun.auto = false;
        }
    }
}
