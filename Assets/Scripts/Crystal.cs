using Unity.VisualScripting;
using UnityEngine;

public class Crystal : PickUp
{
    [SerializeField] int points = 5;
    
    public override void Picked()
    {
        GameManager.gameManager.AddPoints(points);
        base.Picked();
    }
}
