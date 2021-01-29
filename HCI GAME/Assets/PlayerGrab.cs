using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerGrab : MonoBehaviour
{
    public GameObject key1;
    public GameObject myHand;
    public Keyholder keyholder;
    public bool inHands = false;

    int keynr = 0;
    Vector3 keyPos;
    // Start is called before the first frame update
    void Start()
    {
        keyPos = key1.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!inHands)
            {
                Key.KeyType tempkey = key1.GetComponent<Key>().GetKeyType();

                if (tempkey != null)
                {
                    keyholder.AddKey(tempkey);
                    Destroy(key1);
                    inHands = true;
                }

            }
            else if (inHands)
            {
                this.GetComponent<PlayerGrab>().enabled = false;
                inHands = false;
            }
           
        }
    }
}
