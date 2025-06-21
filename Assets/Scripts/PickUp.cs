using System;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 5;
    [SerializeField] bool rotateX = false;
    [SerializeField] bool rotateY = false;
    [SerializeField] bool rotateZ = false;
    
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
        transform.Rotate(new Vector3(
            rotateX ? rotationSpeed : 0,
            rotateY ? rotationSpeed : 0,
            rotateZ ? rotationSpeed : 0
            )
        );
    }
}
