using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public Collider bola;
    public Material onMaterial;
    public Material offMaterial;

    public bool isOn;
    private Renderer renderer;

    public AudioSource audioSource;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();

        Set(false);
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other == bola)
        {
            audioSource.Play();
            Set(!isOn);
        }

    }

    private void Set(bool active)
    {
        isOn = active;
        if(isOn == true)
        {
            renderer.material = onMaterial;
        }
        else
        {
            renderer.material = offMaterial;
        }
    }
}
