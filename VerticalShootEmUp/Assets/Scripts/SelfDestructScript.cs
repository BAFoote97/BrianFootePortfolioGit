using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructScript : MonoBehaviour
{

    public float timeBeforeDestroy;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SelfDestructTime());

    }



    public IEnumerator SelfDestructTime()
    {
        yield return new WaitForSeconds(timeBeforeDestroy);
        Destroy(gameObject);
    }
}
