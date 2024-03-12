using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIAim : MonoBehaviour
{
    public GameObject gun;
    public GameObject target;

    // Update is called once per frame
    void FixedUpdate()
    {
        gun.transform.LookAt(target.transform, Vector3.up);
    }
}
