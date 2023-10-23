using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPlatform : MonoBehaviour
{
    private SliderJoint2D platformJoint;

    private void Start()
    {
        platformJoint = GetComponent<SliderJoint2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        JointMotor2D motor = platformJoint.motor;
        
        if (collision.tag == "SliderBorders")
        {
            if (collision.name == "TriggerBottom")
                motor.motorSpeed = -1.0f;
            else
                motor.motorSpeed = 1.0f;
        }
        platformJoint.motor = motor;
    }
}
