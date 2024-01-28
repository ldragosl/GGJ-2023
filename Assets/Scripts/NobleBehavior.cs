using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NobleBehavior : MonoBehaviour
{
    private const float _waitMax = 25.0f;
    private const float _waitMin = 10.0f;
    private float _waitTime = 0.0f;
    private float _currentTime = 0.0f;
    [SerializeField]
    private NoblePositions _positions;
    private NavMeshAgent _agent;

    private int _seatIndex;
    private int _waitIndex;

    private enum _states
    {
        Waiting,
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
        _seatIndex = _positions.GetSeat();
        _agent.destination = _positions._tablePositions[_seatIndex].position.position;
        _waitTime = Random.Range(_waitMin, _waitMax + 1);
    }

    private void Update()
    {
        if (_currentState == _states.Seated)
        {
            if(Vector3.Distance(transform.position, _agent.destination) < 0.1)
            {
                transform.rotation = _positions._tablePositions[_seatIndex].position.rotation;
            }
            _currentTime += Time.deltaTime;
            if (_currentTime >= _waitTime)
            {
                AdvanceState();
            }
        }
    }

    public void AdvanceState()
    {
        _currentTime = 0.0f;
        _waitTime = Random.Range(_waitMin, _waitMax + 1);
        if (_currentState == _states.Waiting)
        {
            _currentState = _states.Seated;
            var temp = _positions._waitPositions[_waitIndex];
            temp.taken = false;
            _positions._waitPositions[_waitIndex] = temp;
            _seatIndex = _positions.GetSeat();
            _agent.destination = _positions._tablePositions[_seatIndex].position.position;
        }
        else
        {
            _currentState = _states.Waiting;
            OrderManager.instance.placeNewOrder(this);
            var temp = _positions._tablePositions[_seatIndex];
            temp.taken = false;
            _positions._tablePositions[_seatIndex] = temp;
            _waitIndex = _positions.GetWaitPos();
            _agent.destination = _positions._waitPositions[_waitIndex].position.position;
        }
    }

}
