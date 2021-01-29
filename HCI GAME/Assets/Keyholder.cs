using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keyholder : MonoBehaviour
{
    // Start is called before the first frame update
    private List<Key.KeyType> keyList;
    private void Awake()
    {
        keyList = new List<Key.KeyType>();

    }
    public void AddKey(Key.KeyType keyType)
    {
        keyList.Add(keyType);
    }
    public void RemoveKey(Key.KeyType keyType)
    {
        keyList.Remove(keyType);
    }
    public bool ContainsKey(Key.KeyType keyType)
    {
        return keyList.Contains(keyType);
    }

    public void Room2()
    {
        keyList.Add(Key.KeyType.Red);
    }

    private void OnTriggerEnter(Collider collider)
    {


        DoorController dc = collider.GetComponent<DoorController>();
        if (dc != null & ContainsKey(dc.GetKeyType()))
        {
            dc.locked = false;
            RemoveKey(dc.GetKeyType());
        }
    }


}