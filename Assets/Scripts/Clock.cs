using UnityEngine;

public class Clock : PickUp
{
    [SerializeField] int time = 5;

    public override void Picked()
    {
        GameManager.gameManager.AddTime(time);
        base.Picked();
    }
}
