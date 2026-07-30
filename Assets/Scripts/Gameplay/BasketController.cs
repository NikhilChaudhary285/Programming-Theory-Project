using UnityEngine;

public class BasketController : MonoBehaviour
{
    [Header("Movement")]
    [Tooltip("Units per second the basket moves at full input.")]
    [SerializeField] private float moveSpeed = 8f;
    [Header("Screen Bounds")]
    [Tooltip("Leftmost X position the basket can reach.")]
    [SerializeField] private float minX = -7f;
    [Tooltip("Rightmost X position the basket can reach.")]
    [SerializeField] private float maxX = 7f;

    void Update()
    {
        if (GameManager.Instance != null &&
            GameManager.Instance.CurrentState != GameState.Playing)
            return;

        float input = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right by default
        Vector3 pos = transform.position;
        pos.x += input * moveSpeed * Time.deltaTime;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }
}