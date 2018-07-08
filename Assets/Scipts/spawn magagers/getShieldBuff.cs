using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getShieldBuff : MonoBehaviour {

	private PlayerHP _playerHealth;                  
	private GameObject _player;    
	private bool _playerInRange;
	private bool _buffCaptured = false;
	
	private void Awake()
	{
		_player = GameObject.FindGameObjectWithTag ("Player");
		_playerHealth = _player.GetComponent<PlayerHP>();
	}
	private void OnTriggerEnter (Collider other)
	{
		if (other.gameObject != _player || _buffCaptured) return;
		_playerHealth.PickUpBuffShieldP();
		_buffCaptured = true;
	}
}
