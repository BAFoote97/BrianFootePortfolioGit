using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TestSceneChange : MonoBehaviour {

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            ToMission1();
        }
    }

    public void ToMission1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
