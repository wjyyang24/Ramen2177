using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // A reference to the player object.
    public GameObject Player;

    // The distance between the camera and the player object
    private Vector3 Offset;

    // Start is called before the first frame update.
    void Start()
    {
        Offset = this.transform.position - Player.transform.position;
    }

    // LateUpdate is called after Update but before rendering the frame.
    void LateUpdate()
    {
        this.transform.position = Player.transform.position + Offset;
    }
}
