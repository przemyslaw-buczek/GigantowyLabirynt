using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] int timeToEnd;
    bool gamePaused = false;
    bool win = false;
    public int points = 0;
    public static GameManager gameManager;
    public int redKeys = 0;
    public int greenKeys = 0;
    public int goldKeys = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }

        Debug.Log("Time: " + timeToEnd + " s");
        InvokeRepeating(nameof(TimerTick), 2, 1);
    }

    // Update is called once per frame
    void Update()
    {
        PauseCheck();
    }

    void TimerTick()
    {
        timeToEnd--;
        Debug.Log("Time: " + timeToEnd + " s");

        if (timeToEnd <= 0)
        {
            timeToEnd = 0;
            EndGame();
        }
    }

    void PauseGame()
    {
        Debug.Log("Pause Game");
        Time.timeScale = 0;
        gamePaused = true;
    }

    void ResumeGame()
    {
        Debug.Log("Resume Game");
        Time.timeScale = 1;
        gamePaused = false;
    }

    public void EndGame()
    {
        CancelInvoke(nameof(TimerTick));

        Debug.Log(win ? "You win" : "You lose");
    }

    void PauseCheck()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (gamePaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void AddPoints(int points)
    {
        this.points += points;
    }

    public void AddTime(int time)
    {
        timeToEnd += time;
    }

    public void FreezeTime(int duration)
    {
        CancelInvoke(nameof(TimerTick));
        InvokeRepeating(nameof(TimerTick), duration, 1);
    }

    public void AddKey(KeyColor color)
    {
        switch (color)
        {
            case KeyColor.Red:
                redKeys++;
                break; 
            case KeyColor.Green: 
                greenKeys++;
                break;
            case KeyColor.Gold:
                goldKeys++; 
                break;
        }
    }
}
