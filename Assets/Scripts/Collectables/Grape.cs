using UnityEngine;

// INHERITANCE
public class Grape : Collectable
{
    private void Awake()
    {
        PointValue = 8;
    }

    // POLYMORPHISM
    public override void Collect()
    {
        Debug.Log("Grape Collected");

        base.Collect();
    }
}