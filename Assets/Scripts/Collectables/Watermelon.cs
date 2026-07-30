using UnityEngine;

// INHERITANCE
public class Watermelon : Collectable
{
    private void Awake()
    {
        PointValue = 7;
    }

    // POLYMORPHISM
    public override void Collect()
    {
        Debug.Log("Watermelon Collected");

        base.Collect();
    }
}