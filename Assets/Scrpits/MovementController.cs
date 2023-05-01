using UnityEngine;

public class MovementController : MonoBehaviour
{
    public static MovementController _instance;
    [Header("Variables")]
    [SerializeField] private InputController inputController;

    public float verticalSpeed;

    public float horizontalSpeed;

    public float horizontalLimits;

    bool canMove = true;//it was false

    private float newPosX;

    private void Awake()
    {
        _instance = this;
    }
    private void FixedUpdate()
    {
        if (canMove)
        {
            HorizontalMove();
        }
    }
    private void Update()
    {
        if (canMove)
        {
            VerticalMove();
        }
    }

    private void VerticalMove()
    {
        transform.Translate(Vector3.forward * verticalSpeed * Time.fixedDeltaTime);
    }

    private void HorizontalMove()
    {
        newPosX = transform.position.x + inputController.HorizontalValue * horizontalSpeed * Time.fixedDeltaTime;
        newPosX = Mathf.Clamp(newPosX, -horizontalLimits, horizontalLimits);
        transform.position = new Vector3(newPosX, transform.position.y, transform.position.z);

    }

    public void GameStarted()
    {
        canMove = true;
    }


}