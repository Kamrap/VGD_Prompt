// collectablescript.cs:
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


// ScoreManager.cs:
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
            Debug.Log("Score: " + currentScore + "/11");
        }
    }


// Timer.cs:
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text stopwatchText;

    public static float elapsedTime = 0f;
    private static bool isRunning = false;

    void Start()
    {
        if (!isRunning)
        {
            isRunning = true;
        }
    }

    void Update()
    {
        if (isRunning && IsMasterTimer())
        {
            elapsedTime += Time.deltaTime;
        }

        UpdateDisplay();
    }

    void UpdateDisplay()
    {
        int minutes = Mathf.FloorToInt(elapsedTime / 60);
        int seconds = Mathf.FloorToInt(elapsedTime % 60);

        if (stopwatchText != null)
        {
            stopwatchText.text = string.Format("Time: {0:00}:{1:00}", minutes, seconds);
        }
    }

    public void StartStopwatch()
    {
        isRunning = true;
    }

    public void StopStopwatch()
    {
        isRunning = false;
    }

    public void ResetStopwatch()
    {
        isRunning = false;
        elapsedTime = 0f;
        UpdateDisplay();
    }

    bool IsMasterTimer()
    {
        return FindObjectsOfType<Timer>()[0] == this;
    }

    public static float finalTime = 0f;

}


// WinSceneScoreDispay.cs:
using UnityEngine;
using UnityEngine.UI;

public class WinSceneScoreDisplay : MonoBehaviour
{
    public Text finalScoreText;

    void Start()
    {
        finalScoreText.text = "Final Score: " + ScoreManager.currentScore + "/11";
    }
}


// WinSceneTimeDisplay.cs:
using UnityEngine;
using UnityEngine.UI;

public class WinSceneTimeDisplay : MonoBehaviour
{
    public Text finalTimeText;

    void Start()
    {
        int minutes = Mathf.FloorToInt(Timer.elapsedTime / 60);
        int seconds = Mathf.FloorToInt(Timer.elapsedTime % 60);

        finalTimeText.text = "Final Time: " + string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}


// PlayerMovement.cs:
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int keys = 0;
    public float speed = 5.0f;

    public Text keyAmount;
    public Text youWin;
    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime , 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }

        if(keys==3)
        {
            Destroy(door);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Keys")
        {
            keys++;
            keyAmount.text = "Keys: " + keys;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Princess")
        {
            youWin.text = "YOU WIN!!!";
        }
        if (collision.gameObject.tag == "Enemies")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        
    }
}


// Level2.cs
using UnityEngine;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    
    void Start()
    {
        // Optional: Any initialization
    }

    void Update()
    {
        // Optional: Any frame logic
    }

    // Collision detection
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Timer.finalTime = Timer.elapsedTime;
            SceneManager.LoadScene(2);
        }
    }
}


// winn.cs:
using UnityEngine;

public class winn : MonoBehaviour
{
    public GameObject winscreen;
    public Timer timerScript; // Drag the object that has the Timer script

    private bool hasWon = false;

    void Start()
    {
        if (winscreen != null)
            winscreen.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!hasWon && collision.gameObject.CompareTag("Player"))
        {
            hasWon = true;

            Timer.finalTime = Timer.elapsedTime;

            if (winscreen != null)
                winscreen.SetActive(true);

            if (timerScript != null)
                timerScript.enabled = false; // Freeze the Timer script
        }
    }
}
