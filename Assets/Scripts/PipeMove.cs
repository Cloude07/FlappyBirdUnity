using UnityEngine;

public class PipeMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _rigidbody;


    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidbody.velocity = new Vector2(-_speed, 0);
    }
}
