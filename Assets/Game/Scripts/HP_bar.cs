using System.Collections;
using System.Collections.Generic;
using System.Net.WebSockets;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HP_bar : MonoBehaviour
{
	[SerializeField] private Slider[] _healthBars;
	[SerializeField] private float _health;
	[SerializeField] private float _fillSpeed;
	[SerializeField] private TMP_Text TextHP;
	private float _healthPersents;
  
	private void Start() 
	{
		_healthPersents = _health/100;
	}
	public void MakeDamage(float damage)
	{
		if (_health >0)
		{
			_health -= damage;
		}
		else
		{
			_health = 0;
		}

		_healthPersents = _health/100;

		TextHP.text = _health.ToString() + " %";

	}

	private void Update() {
	foreach (Slider healthBar in _healthBars)
        {
            healthBar.value = Mathf.Lerp(healthBar.value, _healthPersents, Time.deltaTime * _fillSpeed);
        }
}

}
