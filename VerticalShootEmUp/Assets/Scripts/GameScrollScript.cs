using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScrollScript : MonoBehaviour
{
    public List<PlayerScript> gamePlayers = new List<PlayerScript>();
    public float myScore;
    public Text scoreText;
    public int player1Lives;
    public Text player1LifeText;
    public int player2Lives;
    public Text player2LifeText;
    public int player3Lives;
    public Text player3LifeText;

    public int difficultyLevel;

    public GameObject gamePathRef;

	public float scrollSpeed;
    // Start is called before the first frame update
    void Start()
    {
        gamePathRef.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = myScore.ToString();
        player1LifeText.text = (" X " + player1Lives.ToString());
        player2LifeText.text = (" X " + player2Lives.ToString());
        player3LifeText.text = (" X " + player3Lives.ToString());
        gameObject.transform.Translate(0, 0, scrollSpeed);
    }
}
