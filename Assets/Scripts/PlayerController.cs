using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float gravity = 9.8f;
    private float _fallVelocity = 0;
    private CharacterController _characterController;
    public float jumpForce;
    public float speed;
    private Vector3 _moveVector3;

    private void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        _moveVector3 = Vector3.zero;
        if (Input.GetKey(KeyCode.W))
        {
            _moveVector3 += transform.forward;
        }
        if (Input.GetKey(KeyCode.A))
        {
            _moveVector3 -= transform.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            _moveVector3 += transform.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            _moveVector3 -= transform.forward;
        }
        if (Input.GetKeyDown(KeyCode.Space)&& _characterController.isGrounded)
        {
            _fallVelocity = -jumpForce;
        }
    }
    private void FixedUpdate()
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
