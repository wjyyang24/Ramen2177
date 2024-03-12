using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Code written using unity tutorial series by pablos lab
 */
public class CarController : MonoBehaviour
{
    public WheelCollider[] wheels = new WheelCollider[4];
    public GameObject[] wheelMesh = new GameObject[4];
    public Rigidbody rb;
    public float torque = 100f;
    public float brakeTorque = 5000f;
    public float steeringMax = 20f;

    // FixedUpdate is called before each step in the physics engine.
    private void FixedUpdate()
    {
        animateWheels();

        // drive
        if (Input.GetKey(KeyCode.W))
        {
            for (int i = 2; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = torque;
            }
        }
        else if (Input.GetKey(KeyCode.S))
        {
            for (int i = 2; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = -torque;
            }
        }
        else
        {
            for (int i = 2; i < wheels.Length; i++)
            {
                wheels[i].motorTorque = 0;
            }
        }

        // brake
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (WheelCollider wheel in wheels)
            {
                wheel.brakeTorque = brakeTorque;
            }
        }
        else
        {
            foreach (WheelCollider wheel in wheels)
            {
                wheel.brakeTorque = 0;
            }
        }

        // steering
        if (Input.GetAxis("Horizontal") != 0)
        {
            for (int i = 0; i < wheels.Length - 2; i++)
            {
                wheels[i].steerAngle = Input.GetAxis("Horizontal") * steeringMax;
            }
        }
        else
        {
            for (int i = 0; i < wheels.Length - 2; i++)
            {
                wheels[i].steerAngle = 0;
            }
        }
    }

    void animateWheels()
    {
        Vector3 wheelPosition = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for (int i = 0; i < 4; i++)
        {
            wheels[i].GetWorldPose(out wheelPosition, out wheelRotation);
            wheelMesh[i].transform.position = wheelPosition;
            wheelMesh[i].transform.rotation = wheelRotation;
        }
    }
}