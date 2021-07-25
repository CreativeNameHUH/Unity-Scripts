using UnityEngine;
using UnityEngine.AI;

public class ChaseState : MonoBehaviour, IFSMState
{
    public FSMStateType StateName => FSMStateType.Chase;
    public float MinChaseDistance = 2f;

    private Transform _player;
    private NavMeshAgent _agent;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player").GetComponent<Transform>();
        _agent = GetComponent<NavMeshAgent>();
    }
    public void OnEnter()
    {
        _agent.isStopped = false;
    }

    public void OnExit()
    {
        _agent.isStopped = true;
    }

    public void DoAction()
    {
        _agent.SetDestination(_player.position);
    }

    public FSMStateType ShouldTransitionToState()
    {
        float distanceToDestination = Vector3.Distance(transform.position, _player.position);
        
        return distanceToDestination <= MinChaseDistance ? FSMStateType.Attack : FSMStateType.Chase;
    }
}
