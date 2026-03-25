using UnityEngine;

public class CommandPlayer : MonoBehaviour
{
    [SerializeField] private float moveStep = 1.0f;

    [SerializeField] private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        if (spriteRenderer == null)
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
        }
    }

    public Color CurrentColor => spriteRenderer != null ? spriteRenderer.color : Color.white;

    public void MoveLeft()
    {
        transform.position += Vector3.left * moveStep;
        Debug.Log("Player moves left");
    }

    public void MoveRight()
    {
        transform.position += Vector3.right * moveStep;
        Debug.Log("Player moves right");
    }

    public void SetColor(Color color)
    {
        if (spriteRenderer == null) return;

        spriteRenderer.color = color;

        Debug.Log($"Player changes color to {color}");
    }

}
