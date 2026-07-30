using System;
using UnityEngine;
using UnityEngine.Rendering;

public enum GameState { Playing, GameOver }

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Round Settings")]
    [Tooltip("Total round length in seconds.")]
    [SerializeField] private float roundDuration = 60f;

    public GameState CurrentState { get; private set; } = GameState.Playing;
    public float TimeRemaining { get; private set; }

    public event Action<float> OnTimerChanged;
    public event Action OnGameOver;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        TimeRemaining = roundDuration;
        CurrentState = GameState.Playing;
        //CheckRenderPipeline();
    }

    void Update()
    {
        if (CurrentState != GameState.Playing) return;

        TimeRemaining -= Time.deltaTime;
        OnTimerChanged?.Invoke(TimeRemaining);
        if (TimeRemaining <= 0f)
        {
            TimeRemaining = 0f;
            CurrentState = GameState.GameOver;
            OnGameOver?.Invoke();
        }
    }

    void CheckRenderPipeline()
    {
        if (GraphicsSettings.currentRenderPipeline == null)
        {
            Debug.Log("Using the Built-in Render Pipeline");
        }
        else
        {
            // Will return the name of your specific pipeline asset (URP/HDRP)
            string pipelineName = GraphicsSettings.currentRenderPipeline.GetType().Name;
            Debug.Log("Using Render Pipeline: " + pipelineName);
        }
    }
}