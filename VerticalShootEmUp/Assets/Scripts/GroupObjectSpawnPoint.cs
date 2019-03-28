using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupObjectSpawnPoint : MonoBehaviour
{
    public GameObject myObject;

    public bool isOneShot;
    // Start is called before the first frame update
    void Start()
    {
        myObject.SetActive(false); 
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyTrigger")
        {
            myObject.SetActive(true);
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "EnemyTrigger" && isOneShot == true)
        {
            myObject.SetActive(false);
        }
    }
}
