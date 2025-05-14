// Script 1 (collectablescript.cs):

using UnityEngine;

public class collectablescript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // detects when the collision happens
        {
            ScoreManager.AddScore(1); // Add to shared score
            gameObject.SetActive(false); // Make cheese disappear
        }
    }
}


// Script 2 (ScoreManager.cs):

using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static int currentScore = 0;
    public Text scoreText;

    void Update()
    {
        scoreText.text = currentScore.ToString(); //makes the text the score
    }

    public static void AddScore(int amount) //Complete add score function
    {
        //Adds score
        currentScore += amount;
        Debug.Log("Score: " + currentScore);
    }
}
