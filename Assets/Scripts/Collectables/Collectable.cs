using UnityEngine;

/// <summary>
/// Base class for all collectible objects.
/// Handles common behaviour such as scoring and destruction.
/// </summary>
public class Collectable : MonoBehaviour
{
    [Header("Collectable Settings")]

    [SerializeField]
    private int pointValue = 1;

    [SerializeField]
    private float destroyBelowY = -10f;

    // ENCAPSULATION
    public int PointValue
    {
        get { return pointValue; }
        protected set { pointValue = value; }
    }

    protected virtual void Update()
    {
        if (transform.position.y < destroyBelowY)
        {
            Destroy(gameObject);
        }
    }

    // ABSTRACTION
    // POLYMORPHISM
    public virtual void Collect()
    {
        Destroy(gameObject);
    }
}