using UnityEngine;
using UnityEngine.UI;

public class Moved : MonoBehaviour
{
  private Animator _animator;
  private Rigidbody _rigidbody;
	private MobileJustik _movedContoller;
	public Slider _mainSlider;

  public float _rotationspeed = 15f;
  public float _speed = 4.5f;

  void Start()
  {
      _animator = GetComponent<Animator>();
      _rigidbody = GetComponent<Rigidbody>();
			_movedContoller = GameObject.FindGameObjectWithTag("Joystick").GetComponent<MobileJustik>();
  }

  void Update()
  {
    Vector3 _directionVector = new Vector3( _movedContoller.Horizontal() + _mainSlider.value, 0, _movedContoller.Vertical() + _mainSlider.value);

		if(_directionVector.magnitude > Mathf.Abs(0.5f)) {
      transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(_directionVector), Time.deltaTime * 10);
		}
    _animator.SetFloat("speed", Vector3.ClampMagnitude(_directionVector, 1).magnitude);
    _rigidbody.velocity = Vector3.ClampMagnitude(_directionVector, 1) * _speed;
  }
 
 public void PlayAnimaid(string AnimatiomMain)
 {
	_animator.Play(AnimatiomMain,0,0);
 }
	
}