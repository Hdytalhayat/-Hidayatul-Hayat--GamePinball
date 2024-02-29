using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public enum SwitchState
    {
        Off,
        On,
        Blink
    }
    [SerializeField] private float score;
    [SerializeField] private ScoreManager scoreManager;
    public Collider bola;
    public Material onMaterial;
    public Material offMaterial;
    [SerializeField] private VFXManager vfxManager;

    public SwitchState state;
    private Renderer renderer;

    public AudioSource audioSource;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        audioSource = GetComponent<AudioSource>();

        Set(false);
        StartCoroutine(BlinkTimer(5f));
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other == bola)
        {
            vfxManager.PlaySwitchVFX(other.transform.position);
            scoreManager.AddScore(score);

            audioSource.Play();
            Toggle();
        }

    }

    private void Set(bool active)
    {
        if(active == true)
        {
            state = SwitchState.On;
            renderer.material = onMaterial;

            StopAllCoroutines();
        }
        else
        {
            state = SwitchState.Off;
            renderer.material = offMaterial;
            StartCoroutine(BlinkTimer(5f));

        }
    }

    private void Toggle()
    {
        if (state==SwitchState.On)
        {
            Set(false);
        }
        else
        {
            Set(true);
        }
    }
    private IEnumerator Blink(int times)
    {
        state = SwitchState.Blink;
        for (int i=0; i<times; i++)
        {
            renderer.material = onMaterial;
            yield return new WaitForSeconds(.5f);
            renderer.material = offMaterial;
            yield return new WaitForSeconds(.5f);

        }
        state = SwitchState.Off;
        StartCoroutine(BlinkTimer(5f));

    }

    private IEnumerator BlinkTimer(float times)
    {
        yield return new WaitForSeconds(times);
        StartCoroutine(Blink(3));
    }
}


