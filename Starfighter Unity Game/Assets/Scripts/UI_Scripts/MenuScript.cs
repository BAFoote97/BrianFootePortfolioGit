using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

    public GameObject gamePlayer;

    

    public void ToMission1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
    public void ToMission2()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }
    public void ToMission3()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }
    public void ToMission4()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);

    }
    public void ToMission5()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);

    }
    public void ToMission6()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 6);

    }
    public void ToMission7()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 7);

    }
    public void ToMission8()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 8);

    }
    public void ToMission9()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 9);

    }
    public void ToMission10()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 10);

    }
    public void ToMenu()
    {
        if (gamePlayer.GetComponent<PauseScript>().paused == true)
        {
            Time.timeScale = 1;
            gamePlayer.GetComponent<PauseScript>().paused = false;
            gamePlayer.GetComponent<PauseScript>().pauseMenu.SetActive(false);
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }
}
