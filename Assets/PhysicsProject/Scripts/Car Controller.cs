using System;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public Rigidbody rb;
    public float torque;

    public HingeJoint[] motorControl;
    public GameObject[] wheels;
    public bool motorToggle;

    private void Update()
    {
        foreach (var motar in motorControl)
        {
            motar.useMotor = motorToggle ? true : false;
        }

        foreach (var wheel in wheels)
        {   
            wheel.transform.Rotate(0, torque, 0);
        }
    }

    void FixedUpdate()
    {
        float turn = Input.GetAxis("Horizontal");
    }
    
}
