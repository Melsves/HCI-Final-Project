using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMoment : MonoBehaviour
{
    public AudioSource playSound;
    bool playedOnce = false;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (!playedOnce)
        {
            playSound.Play();
            playedOnce = true;

        }
    }
}
