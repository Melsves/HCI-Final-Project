using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    Animator _dooranim;
    private void OnTriggerEnter(Collider other)
    {
        _dooranim.SetBool("character_nearby", true);
    }
    private void OnTriggerExit(Collider other)
    {
        _dooranim.SetBool("character_nearby", false);
    }
    void Start()
    {
        _dooranim = this.transform.parent.GetComponent<Animator>();
    }

    void Update()
    {

    }
}
