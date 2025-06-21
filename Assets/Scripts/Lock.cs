using UnityEngine;

public class Lock : MonoBehaviour
{
    Door[] doors;
    bool canOpen = false;
    public KeyColor myColor;
    bool open = false;
    Animator key;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        key = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canOpen = false;
        }
    }

    public void UseKey()
    {
        foreach (Door door in doors)
        {
            door.Open();
        }
    }

    public bool CheckKey()
    {
        if (myColor == KeyColor.Red && GameManager.gameManager.redKeys > 0)
        {
            GameManager.gameManager.redKeys--;
            open = true;
            return true;
        } 
        else if (myColor == KeyColor.Green && GameManager.gameManager.greenKeys > 0)
        {
            GameManager.gameManager.greenKeys--;
            open = true;
            return true;
        }
        else if (myColor == KeyColor.Gold && GameManager.gameManager.goldKeys > 0)
        {
            GameManager.gameManager.goldKeys--;
            open = true;
            return true;
        }
        else
        {
            return false;
        }
    }
}
