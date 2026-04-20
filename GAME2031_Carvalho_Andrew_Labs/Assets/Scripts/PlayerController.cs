using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveForce = 5f;
    [SerializeField] private float maxSpeed = 5f;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private float pointInterval = 10f;

    private Rigidbody2D rb2D;

    private float input;
    private float linearVelocity;
    private int score;

    private LE9_Input playerInput;

    private float timeSinceLastPoint = 0f;

    private void Awake()
    {
        playerInput = new LE9_Input();
        rb2D = GetComponent<Rigidbody2D>();
    }


    private void Start()
    {
        SetScore(0);
    }


    private void OnEnable()
    {
        playerInput.Player.Enable();
        playerInput.Player.Move.performed += Move;
        playerInput.Player.Move.canceled += Move;
    }

    private void OnDisable()
    {
        playerInput.Player.Move.performed -= Move;
        playerInput.Player.Move.canceled -= Move;
        playerInput.Player.Disable();
    }

    private void Move (InputAction.CallbackContext context)
    {
        input = context.ReadValue<float>();
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(rb2D.linearVelocity.x) <= maxSpeed)
        {
            rb2D.AddForceX(input * moveForce);
        }
        else
        {
            if (Mathf.Sign(input) != Mathf.Sign(rb2D.linearVelocity.x))
            {
                rb2D.AddForceX(input * moveForce);
            }
        };
    }

    private void SetScore(int score)
    {
        this.score = score;
        scoreText.text = "Score: " + score.ToString();

        scoreText.text = $"Score: {score}";
    }

    public void IncrementScore(int incrementor)
    {
       SetScore(this.score + incrementor);
    }

    private void Update()
    {
        timeSinceLastPoint += Time.deltaTime;
        if (timeSinceLastPoint >= pointInterval)
        {
            IncrementScore(10);
            timeSinceLastPoint = 0f;
            print("Lasted ten seconds, 10 points!");
        }
    }
}


