using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHP : MonoBehaviour
{
	public int StartingHealth = 100;                            
	public int CurrentHealth;                                   
	public int PointForKill;
   
	private bool _enemyDie;                                                
	private ParticleSystem _hitParticles;
	private ParticleSystem _prefab;
	private Animator _enemyAnimation;

	

	private void Awake ()
	{
		CurrentHealth = StartingHealth;
		_hitParticles = GetComponent<ParticleSystem>();
		_enemyAnimation = GetComponent<Animator>();
		}

	private void Update()
	{
		_enemyAnimation.SetBool("damaged", false);
	}
	public void TakeDamage (int amount)
	{
		if(_enemyDie)
			return;
		CurrentHealth -= amount;
		_hitParticles.transform.position = transform.position;
		_hitParticles.Play();
		_enemyAnimation.SetBool("damaged", true);
		if(CurrentHealth <= 0)
			Death ();
	}
	private void Death ()
	{
		_enemyDie = true;
		_enemyAnimation.SetTrigger("die");
		PointsManager.Score += PointForKill;
		PointsManager.Combo++;

	}       
}