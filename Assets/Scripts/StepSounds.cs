using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepSounds : MonoBehaviour
{
    [SerializeField]
    AudioSource _audio;
    [SerializeField]
    AudioClip walkSound;
    void Start()
    {
        InvokeRepeating("PlaySound", 0.0f, 0.5f);
    }
    private void Update()
    {
        if (_audio.panStereo > 0)
        {
            _audio.panStereo = -1;
        }
        if (_audio.panStereo < 0)
        {
            _audio.panStereo = -1;
        }
    }
    void PlaySound()
    {

        if (Input.GetButton("Vertical") || Input.GetButton("Horizontal"))
        {
            _audio.PlayOneShot(walkSound);
        }
    }
}
