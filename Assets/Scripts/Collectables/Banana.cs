using UnityEngine;

// INHERITANCE
public class Banana : Collectable
{
    private void Awake()
    {
        PointValue = 2;
    }

    // POLYMORPHISM
    public override void Collect()
    {
        Debug.Log("Banana Collected");

        base.Collect();
    }
}