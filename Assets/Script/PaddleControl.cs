using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PaddleControl : MonoBehaviour
{
    public KeyCode input;
    public float pressed;
    public float released;

    private HingeJoint hinge;
    private AudioSource audioSource;
    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        audioSource = GetComponent<AudioSource>();
        pressed = hinge.limits.max;
        released = hinge.limits.min;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
        JointSpring jointSpring = hinge.spring;
        if (Input.GetKey(input))
        {
            jointSpring.targetPosition = pressed;
            audioSource.Play();
            
        }
        else
        {
            jointSpring.targetPosition = released;

        }

        hinge.spring = jointSpring;
    }
}
