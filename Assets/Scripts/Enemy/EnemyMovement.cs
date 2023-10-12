using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
	[SerializeField] private Enemy _template;
	[SerializeField] private Transform[] _movementPoints;
	[SerializeField] private float _movementSpeed;
	[SerializeField] private float _arrivalThreshold = 0.1f;

	private Rigidbody2D _rigidbody2d;
	private int _currentPoint;

	private void Awake()
	{
		_rigidbody2d = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		Move();
	}

	private void Move()
	{
		Transform target = _movementPoints[_currentPoint];
		_template.transform.position = Vector2.MoveTowards(_template.transform.position, target.position, _movementSpeed * Time.deltaTime);
		Flip();

		if (Vector2.Distance(_template.transform.position, target.position) <= _arrivalThreshold)
		{
			_currentPoint++;

			if (_currentPoint >= _movementPoints.Length)
			{
				_currentPoint = 0;
			}
		}
	}

	private void Flip()
	{
		if (_template.transform.position.x < _movementPoints[_currentPoint].position.x)
		{
			_template.transform.localRotation = Quaternion.Euler(0, 0, 0);
		}
		else if (_template.transform.position.x > _movementPoints[_currentPoint].position.x)
		{
			_template.transform.localRotation = Quaternion.Euler(0, -180, 0);
		}
	}
}