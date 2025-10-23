using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Instance;

    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 playerDirection;
    public float boost = 1f;
    private float boostPower = 5f;

    [SerializeField] private float moveSpeed;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        } else
        {
            Instance = this;
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float directionX = Input.GetAxisRaw("Horizontal");
        float directionY = Input.GetAxisRaw("Vertical");
        animator.SetFloat("moveX", directionX);
        animator.SetFloat("moveY", directionY);
        playerDirection = new Vector2(directionX, directionY).normalized;

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2"))
        {
            EnterBoost();
        } else if (Input.GetKeyUp(KeyCode.Space) || Input.GetButtonUp("Fire2"))
        {
            ExitBoost();
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(playerDirection.x * moveSpeed, playerDirection.y * moveSpeed);
    }

    private void EnterBoost()
    {
        animator.SetBool("boosting", true);
        boost = boostPower;
    }
    
    private void ExitBoost()
    {
        animator.SetBool("boosting", false);
        boost = 1f;
    }
}
