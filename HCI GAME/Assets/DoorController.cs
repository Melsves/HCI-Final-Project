using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator _dooranim;
    public AudioSource playSound;
    public AudioSource tut_sound;
    bool played_once = false;

    public int minLevel = 0;
    public int currentLevel;

    public levelBar levelBar;
    private void OnTriggerEnter(Collider other)
    {
        _dooranim.SetBool("character_nearby", true);
        playSound.Play();
        if(tut_sound != null & !played_once)
        {
            tut_sound.Play();
            played_once = true;
            Addlevel(1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _dooranim.SetBool("character_nearby", false);
        playSound.Play();
    }
    void Start()
    {
        _dooranim = this.transform.parent.GetComponent<Animator>();
        currentLevel = minLevel;
        levelBar.SetMinLevel(minLevel);
    }

    void Update()
    {

    }
    void Addlevel(int level)
    {
        currentLevel += level;

        levelBar.SetLevel(currentLevel);
    }
}
