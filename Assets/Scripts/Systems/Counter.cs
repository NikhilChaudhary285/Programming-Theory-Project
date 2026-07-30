using UnityEngine;
using TMPro;
using System;

/// <summary>
/// Tracks the player's score via trigger-based fruit collection
/// and broadcasts changes so UI and other systems can react
/// without depending on this class directly.
/// </summary>
public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI counterText;

    /// <summary>Current score. Read-only from outside this class.</summary>
    public int Score { get; private set; } = 0;

    /// <summary>Fires whenever the score changes, passing the new value.</summary>
    public event Action<int> OnScoreChanged;

    void OnTriggerEnter(Collider other)
    {
        // Any collider entering this trigger counts as a "catch" —
        // the Basket's collider is the only trigger in the scene, so no tag check needed here.

        //Replaced with below code: Fruit fruit = other.GetComponent<Fruit>();
        Collectable collectable = other.GetComponent<Collectable>();
        //Replaced with below code: int value = fruit != null ? fruit.PointValue : 1;
        int value = collectable != null ? collectable.PointValue : 1;

        Score += value;
        //Replaced with below code: counterText.text = Score.ToString();
        if (collectable != null)
        {
            collectable.Collect();
        }
        counterText.text = Score.ToString();

        OnScoreChanged?.Invoke(Score);
    }

    public void ResetScore()
    {
        Score = 0;
        counterText.text = Score.ToString();
        OnScoreChanged?.Invoke(Score);
    }
}