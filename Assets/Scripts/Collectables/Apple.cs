using UnityEngine;

// INHERITANCE
public class Apple : Collectable
{
    private void Awake()
    {
        PointValue = 1;
    }

    // POLYMORPHISM
    public override void Collect()
    {
        Debug.Log("Apple Collected");

        base.Collect();
    }
}