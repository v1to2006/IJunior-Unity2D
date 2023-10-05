using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private Transform _groundCheck;
    [SerializeField] private LayerMask _groundLayer;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(_groundCheck.position, 0.2f, _groundLayer);
    }

    private void Jump()
    {
        const string ParameterJump = "IsJump";

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce);
            _animator.SetBool(ParameterJump, true);
        }
        else
        {
            _animator.SetBool(ParameterJump, false);
        }
    }

    private void Move()
    {
        const string ParameterSpeed = "Speed";
        const string AxisHorizontal = "Horizontal";

        float horizontalMove = Input.GetAxisRaw(AxisHorizontal);
        _animator.SetFloat(ParameterSpeed, horizontalMove);

        _rigidbody2D.velocity = new Vector2(horizontalMove * _speed * Time.deltaTime, _rigidbody2D.velocity.y);

        if (horizontalMove < 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        if (horizontalMove > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
