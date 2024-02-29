using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleControl : MonoBehaviour
{
    public KeyCode input;
    public float pressed;
    public float released;

    private HingeJoint hinge;
    void Start()
    {
        hinge = GetComponent<HingeJoint>();

        pressed = hinge.limits.max;
        released = hinge.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        JointSpring jointSpring = hinge.spring;
        if (Input.GetKey(input))
        {
            jointSpring.targetPosition = pressed;
        }
        else
        {
            jointSpring.targetPosition = released;

        }

        hinge.spring = jointSpring;
    }
}
