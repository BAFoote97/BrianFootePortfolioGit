using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBossScript : MonoBehaviour
{
    public bool invincibleBase;
    public float hp;
    public List<float> hpSettings = new List<float>();
    public PlayerScript gamePlayer;
    public GameScrollScript gamePlayerSystem;

    public List<EnemyScript> EnemyParts = new List<EnemyScript>();

    public bool isAgro;


    // Start is called before the first frame update
    void Start()
    {
        isAgro = false;
        gamePlayerSystem = FindObjectOfType<GameScrollScript>();
        //gamePlayer = gamePlayerSystem.gamePlayer;
        hp = hpSettings[gamePlayerSystem.difficultyLevel];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
