using UnityEngine;

public class Freeze : PickUp
{
    [SerializeField] int duration = 5;

    public override void Picked()
    {
        GameManager.gameManager.FreezeTime(duration);
        Destroy(gameObject);
    }
}
