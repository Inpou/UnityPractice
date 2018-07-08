using UnityEngine;
using UnityEngine.AI;

public class ghostController : MonoBehaviour
{
    private Transform Target;
    
    private Vector3 _movement;
    private PlayerHP _playerHp;
    private EnemyHP _thisHp;
    private Animator _animator;
    private NavMeshAgent _navMesh;

    private void Awake()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;
        _navMesh = GetComponent<NavMeshAgent>();
        _playerHp = Target.GetComponent<PlayerHP>();
        _thisHp = GetComponent<EnemyHP>();
        _animator = GetComponent<Animator>();
    }


    private void Update()
    {
        Move();
    }

    private void Move()
    {

        if (_thisHp.CurrentHealth > 0 && _playerHp.CurrentHealth > 0)
        {
            _navMesh.SetDestination(Target.position);
            _animator.SetBool("walk", true);
        }
        else
        {
            _animator.SetBool("walk",false);
            _navMesh.enabled = false;
            Destroy(gameObject,2f);
        }
    }
}