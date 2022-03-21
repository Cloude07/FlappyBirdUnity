using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class BirdMover : MonoBehaviour
{
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private float _speed;
    [SerializeField] private float _tapForce = 10;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _maxRotationZ;
    [SerializeField] private float _minRotationZ;
    [SerializeField] private Animator _animator;
    [SerializeField] private SoundComponent _soundFly;

    public bool _startMover = false;
    private Rigidbody2D _rigidbody;
    private Quaternion _maxRotation;
    private Quaternion _minRotation;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
      
        _maxRotation = Quaternion.Euler(0, 0, _maxRotationZ);
        _minRotation = Quaternion.Euler(0, 0, _minRotationZ);
        _animator = GetComponent<Animator>();

        ResetBird();
    }

    private void Update()
    {
        if(_startMover==true)
        FlyBird();

    }

    public void ResetBird()
    {
        transform.position = _startPosition;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rigidbody.velocity = Vector2.zero;
    }

    private void AnimationBird()
    {
        if (transform.rotation.z > 0)
        {
            _animator.Play("Fly");

        }
        else
            _animator.Play("Idie");
    }

    public void FlyBird()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _rigidbody.velocity = new Vector2(_speed, 0);
            transform.rotation = _maxRotation;

            _rigidbody.AddForce(Vector2.up * _tapForce, ForceMode2D.Force);
            AnimationBird();
            _soundFly.SoundFly();
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
        AnimationBird();
    }
}
