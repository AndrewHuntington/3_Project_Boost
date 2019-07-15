using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource rocketAudioSource;

    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        rocketAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (Input.GetKey(KeyCode.Space)) // can thrust while rotating
        {
            // AddRelativeForce() -- adds a thrust force to push an object in its currect forward direction
            rigidBody.AddRelativeForce(Vector3.up);
            SoundController(true, rocketAudioSource);
        } else
        {
            SoundController(false, rocketAudioSource);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward); // rotate left
        } else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward); // rotate right
        }
    }

    private void SoundController(bool shouldPlay, AudioSource audioSource)
    {
        if (shouldPlay == true && !audioSource.isPlaying) //If sound should be playing, but isn't, play the sound.
        {
            audioSource.Play();
        }
        if (shouldPlay == true && audioSource.volume < 0.6) //If sound should be playing, but the volume is below 0.6, slowly increase the volume.
        {
            audioSource.volume += Time.deltaTime * 0.9F;
        }
        if (shouldPlay == false && audioSource.isPlaying) //If sound should not be playing, but is, slowly decrease the volume.
        {
            audioSource.volume += Time.deltaTime * -0.9F;
        }
        if (shouldPlay == false && audioSource.volume <= 0) //If sound should not be playing, and the volume is <=0, stop the sound.
        {
            audioSource.Stop();
        }
    }
}
