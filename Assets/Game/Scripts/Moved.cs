using UnityEngine;
using UnityEngine.UI;

public class Moved : MonoBehaviour
{
  private Animator _animator;
  private Rigidbody _rigidbody;

  public float _rotationspeed = 15f;
  public float _speed = 4.5f;
	public Slider _mainSlider;

  void Start()
  {
      _animator = GetComponent<Animator>();
      _rigidbody = GetComponent<Rigidbody>();
  }

  void Update()
  {
    float h = Input.GetAxis("Horizontal");
    float v = Input.GetAxis("Vertical");
    Vector3 _directionVector = new Vector3(-v, 0, h + _mainSlider.value);
		if(_directionVector.magnitude > Mathf.Abs(0.5f)) {
      transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_directionVector), Time.deltaTime * 10);
		}

    _animator.SetFloat("speed", Vector3.ClampMagnitude(_directionVector, 1).magnitude);
    _rigidbody.velocity = Vector3.ClampMagnitude(_directionVector, 1) * _speed;
  }
}