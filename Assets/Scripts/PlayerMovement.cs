using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] Joystick _joystick;
    [SerializeField] float _force, _constantSpeed;

    Rigidbody _rigidbody;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }


    void FixedUpdate()
    {
        Move();
    }


    void Move()
    {
        if(_joystick.Direction != Vector2.zero)
        {
            Vector3 direction = new Vector3(_joystick.Horizontal, 0f, _joystick.Vertical);
            _rigidbody.AddForce(direction * _force * Time.deltaTime, ForceMode.Force);
        }

        transform.position += new Vector3(0, 0, _constantSpeed) * Time.deltaTime;

        _constantSpeed += 0.001f;

    }
}
