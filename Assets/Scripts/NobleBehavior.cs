using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NobleBehavior : MonoBehaviour
{
    private const float _waitMax = 10.0f;
    private const float _waitMin = 5.0f;
    private float _waitTime = 0.0f;
    private float _currentTime = 0.0f;
    [SerializeField]
    private NoblePositions _positions;
    private NavMeshAgent _agent;

    private enum _states
    {
        Waiting,
        Eating,
        Seated
    }

    private _states _currentState;
    private void Awake()
    {
        _currentState = _states.Seated;
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        _agent.destination = _positions.GetSeat().position;
        _waitTime = Random.Range(_waitMin, _waitMax + 1);
    }

    private void Update()
    {
        _currentTime += Time.deltaTime;
        if(_currentTime >= _waitTime)
        {
            AdvanceState();
        }
        
    }

    private void AdvanceState()
    {
        _waitTime = Random.Range(_waitMin, _waitMax + 1);
        if (_currentState == _states.Waiting)
        {
            _currentState = _states.Seated;
            _positions.FreeSeat("seat", _agent.destination);
            _agent.destination = _agent.destination = _positions.GetWaitPos().position;
        }
        else
        {
            _currentState = _states.Waiting;
            _agent.destination = new Vector3(0, 0, 0);
        }
    }
}
