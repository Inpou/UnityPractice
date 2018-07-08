using UnityEngine;

public class getDoubleDamageBuff : MonoBehaviour
{
    private PlayerShooting _playerShootingRg;
    private PlayerShooting _playerShootingLg;
    private GameObject _rightGun;
    private GameObject _leftGun;
    private GameObject _player;
    private bool _playerInRange;
    private bool _buffCaptured;
    private float _timer;


    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rightGun = GameObject.Find("Right_Gun");
        _leftGun = GameObject.Find("Left_Gun");
        _playerShootingRg = _rightGun.GetComponent<PlayerShooting>();
        _playerShootingLg = _leftGun.GetComponent<PlayerShooting>();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != _player || _buffCaptured) return;
        _playerShootingRg.Buff_2XDamage = true;
        _playerShootingLg.Buff_2XDamage = true;
        _buffCaptured = true;
    }
}