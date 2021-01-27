using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasAppear : MonoBehaviour
{
    public void AppearGameObject()
    {
        gameObject.active = true;

    }
    // Update is called once per frame
    void Start()
    {
        gameObject.active = false;
    }
}
