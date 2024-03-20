using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    public float jumpForce;
    public float speed;


    [SerializeField] private Animator animator;
    public LightningCast lightningCast;

    private Vector3 _moveVector3;
    private float _fallVelocity = 0;
    private CharacterController _characterController;


    private void Start()
    {
        InitComponentLinks();
    }
    private void Update()
    {
        MoveUpdate();
    }
    private void FixedUpdate()
    {
        CharacterControllerFixedUpdate();
    }

    private void InitComponentLinks()
    {
        _characterController = GetComponent<CharacterController>();
    }
    public void MoveUpdate()
    {
        var runningDir = 0;
        _moveVector3 = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector3 += transform.forward;
            runningDir = 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector3 -= transform.right;
            runningDir = 2;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector3 += transform.right;
            runningDir = 3;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector3 -= transform.forward;
            runningDir = 4;
        }
        //if (Input.GetKeyDown(KeyCode.Space) && _characterController.isGrounded)
        //{
        //_fallVelocity = -jumpForce;
        //}
        animator.SetInteger("running", runningDir);
    }
    private void CharacterControllerFixedUpdate()
    {
        _characterController.Move(_moveVector3 * speed * Time.fixedDeltaTime);
        _fallVelocity += gravity * Time.fixedDeltaTime;
        _characterController.Move(Vector3.down * _fallVelocity * Time.deltaTime);
        if (_characterController.isGrounded)
        {
            _fallVelocity = 0;
        }
    }
}
