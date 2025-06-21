using JetBrains.Annotations;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] Transform closePosition;
    [SerializeField] Transform openPosition;
    [SerializeField] Transform door;

    [SerializeField] float speed = 5;
    [SerializeField] bool isOpen = false;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        door.position = closePosition.position;
    }

    public void Open()
    {
        isOpen = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen && Vector3.Distance(door.position, openPosition.position) > 0.001f)
        {
            door.position = Vector3.MoveTowards(door.position, openPosition.position, speed * Time.deltaTime);
        }
    }
}
