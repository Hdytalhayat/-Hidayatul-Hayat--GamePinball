using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bumper : MonoBehaviour
{
    public Collider bola;
    public float multiplier;

    public Color color;
    public Color colorDefault;

    private Renderer renderer;
    private Animator animator;

    public AudioSource audioSource;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
       
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider == bola)
        {
            Rigidbody bolaRig = bola.GetComponent<Rigidbody>();

            bolaRig.velocity *= multiplier;

            animator.SetTrigger("hit");

            GetComponent<Renderer>().material.color = color;

            audioSource.Play();
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Renderer>().material.color = colorDefault;
    }
}
