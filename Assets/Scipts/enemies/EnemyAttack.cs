using UnityEngine;
public class EnemyAttack : MonoBehaviour
{
	public float TimeBetweenAttacks = 0.5f;     
	public int AttackDamage = 10;   
	
	private Animator _anim;                              
	private GameObject _player;                          
	private PlayerHP _playerHealth;                  
	private EnemyHP _enemyHealth;                    
	private bool _playerInRange;                         
	private float _timer;  
	
	private void Awake()
	{
		_player = GameObject.FindGameObjectWithTag ("Player");
		_playerHealth = _player.GetComponent<PlayerHP>();
		_enemyHealth = GetComponent<EnemyHP>();
		_anim = GetComponent<Animator>();
	}
	private void OnTriggerEnter (Collider other)
	{
		if(other.gameObject == _player)
			_playerInRange = true;
	}
	private void OnTriggerExit (Collider other)
	{
		if(other.gameObject == _player)
			_playerInRange = false;
	}
	private void Update ()
	{
		_anim.SetBool("attack",false);
		_timer += Time.deltaTime;
		if(_timer >= TimeBetweenAttacks && _playerInRange && _enemyHealth.CurrentHealth >= 0)
			Attack ();
	}
	private void Attack ()
	{
		_timer = 0f;
		if (_playerHealth.CurrentHealth <= 0) return;
		_anim.SetBool("attack",true);
		_playerHealth.TakeDamage (AttackDamage);
	}
}