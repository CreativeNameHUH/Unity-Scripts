using UnityEngine;

public class AttackState : MonoBehaviour, IFSMState
{
    public ParticleSystem MuzzleFlash; 
    public FSMStateType StateName => FSMStateType.Attack;

    private Transform _player;
    private Vector3 _direction;
    private EnemyGun _gun;
    public void OnEnter()
    {
        //MuzzleFlash.Play();
        _gun = GetComponent<EnemyGun>();
    }

    public void OnExit()
    {
        //MuzzleFlash.Stop();
    }

    public void DoAction()
    {
        /*_direction = (_player.position - transform.position).normalized;
        _direction.y = 0;
        transform.rotation = Quaternion.LookRotation(_direction, Vector3.up);*/
        _gun.Shoot();
    }

    public FSMStateType ShouldTransitionToState()
    {
        return FSMStateType.Attack;
    }

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

}
