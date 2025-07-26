using UnityEditor.Profiling.Memory.Experimental;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] int timeToEnd;
    [SerializeField] AudioClip pauseClip;
    [SerializeField] AudioClip resumeClip;

    [SerializeField] Text timeText;
    [SerializeField] Text pointsText;
    [SerializeField] Text redKeysText;
    [SerializeField] Text greenKeysText;
    [SerializeField] Text goldKeysText;


    AudioSource audioSource;
    
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
        audioSource = GetComponent<AudioSource>();

        if (gameManager == null)
        {
            gameManager = this;
        }

        Debug.Log("Time: " + timeToEnd + " s");
        InvokeRepeating(nameof(TimerTick), 2, 1);

        pointsText.text = points.ToString();
        redKeysText.text = redKeys.ToString();
        greenKeysText.text = greenKeys.ToString();
        goldKeysText.text = goldKeys.ToString();
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
        PlayClip(pauseClip);
        Debug.Log("Pause Game");
        Time.timeScale = 0;
        gamePaused = true;
    }

    void ResumeGame()
    {
        PlayClip(resumeClip);
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
        pointsText.text = points.ToString();
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
                redKeysText.text = redKeys.ToString();
                break; 
            case KeyColor.Green: 
                greenKeys++;
                greenKeysText.text = greenKeys.ToString();
                break;
            case KeyColor.Gold:
                goldKeys++;
                goldKeysText.text = goldKeys.ToString();
                break;
        }
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
