using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    static int playerScore;
    public int PlayerScore => playerScore;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SetScore(int incomingScore)
    {
        playerScore += incomingScore;
    }

    public void ResetScore()
    {
        playerScore = 0;
    }
}
