using UnityEngine;

// INHERITANCE
public class Orange : Collectable
{
    private void Awake()
    {
        PointValue = 5;
    }

    // POLYMORPHISM
    public override void Collect()
    {
        Debug.Log("Orange Collected");

        base.Collect();
    }
}