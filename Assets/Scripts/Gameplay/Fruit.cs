using UnityEngine;

public class Fruit : MonoBehaviour
{
    [Header("Scoring")]
    [Tooltip("Points this fruit is worth when caught. Lets future fruit types have different values.")]
    [SerializeField] private int pointValue = 1;

    public int PointValue => pointValue;

    [Header("Despawn Settings")]
    [Tooltip("Y position below which the fruit is automatically destroyed to prevent unused objects from accumulating.")]
    [SerializeField] private float destroyBelowY = -10f;

    void Update()
    {
        if (transform.position.y < destroyBelowY)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // The Basket's Counter.cs handles scoring on its own OnTriggerEnter.
        // This just cleans up the fruit once it's been caught.
        if (other.CompareTag("Basket"))
        {
            Destroy(gameObject);
        }
    }
}