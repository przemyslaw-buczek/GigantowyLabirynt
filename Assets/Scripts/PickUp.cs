using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Rotate();
    }

    public virtual void Picked()
    {
        Debug.Log("Picked up: " + gameObject.name);
        Destroy(gameObject);
    }

    public void Rotate()
    {
        transform.Rotate(new Vector3(rotationSpeed, 0, 0));
    }
}
