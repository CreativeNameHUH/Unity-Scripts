using UnityEngine;

public class AttackState : MonoBehaviour, IFSMState
{ 
    public FSMStateType StateName => FSMStateType.Attack;


    private Transform _player;
    private EnemyGun _gun;
    public void OnEnter()
    {
        _gun = GetComponent<EnemyGun>();
    }

    public void OnExit()
    {
    }

    public void DoAction()
    {
        _gun.Shoot();
    }

    public FSMStateType ShouldTransitionToState()
    {
        return FSMStateType.Chase;
    }

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

}
