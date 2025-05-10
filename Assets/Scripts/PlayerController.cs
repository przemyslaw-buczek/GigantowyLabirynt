using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float defaultSpeed = 12;
    CharacterController characterController;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundMask;
    [SerializeField] float fastGroundFactor = 2;
    [SerializeField] float slowGroundFactor = 0.25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
    }

    void PlayerMove()
    {
        float speed = defaultSpeed;
        RaycastHit hit;

        if (Physics.Raycast(
            groundCheck.position,
            transform.TransformDirection(Vector3.down),
            out hit,
            0.4f,
            groundMask
        ))
        {
            string terrainType = hit.collider.gameObject.tag;

            switch(terrainType)
            {
                case "Slow":
                    speed = defaultSpeed * slowGroundFactor;
                    break;
                case "Fast":
                    speed = defaultSpeed * fastGroundFactor;
                    break;
                default:
                    speed = defaultSpeed;
                    break;
            }
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        characterController.Move(move * speed * Time.deltaTime);
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PickUp"))
        {
            other.gameObject.GetComponent<PickUp>().Picked();
        }
    }
}
