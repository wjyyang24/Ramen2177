using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimGun : MonoBehaviour
{
    public GameObject gun;

    // Update is called once per frame
    void FixedUpdate()
    {
        Plane ground = new Plane(Vector3.up, -gun.transform.position.y);
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdistance;

        if (ground.Raycast(mouseRay, out hitdistance))
        {
            Vector3 mousePt = mouseRay.GetPoint(hitdistance);
            gun.transform.LookAt(mousePt, Vector3.up);
        }
    }
}
