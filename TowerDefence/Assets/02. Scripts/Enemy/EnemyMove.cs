using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.AI;

public class EnemyMove : MonoBehaviour
{
    private Transform _tr;
    private Enemy _enemy;
    public float speed = 1f;
    [SerializeField] private Vector3 _offset;

    private Pathfinder _pathfinder;
    [SerializeField] private Transform _start;
    [SerializeField] private Transform _end;
    private List<Transform> _wayPoints;
    private int _wayPointIndex = 0;
    private Transform _nextWayPoint;
    private float _originY;

    private Vector3 _targetPos;
    private Vector3 _dir;
    private float _posTolerance = 0.05f;

    public void SetStartEnd(Transform start, Transform end)
    {
        _start = start;
        _end = end;
    }
 
    private void Awake()
    {
        _tr = GetComponent<Transform>();
        _enemy = GetComponent<Enemy>();
        _pathfinder = GetComponent<Pathfinder>();       
    }

    private void Start()
    {
        if (_pathfinder.TryFindOptimizedPath(_start, _end, out _wayPoints) == false)
        {
            throw new System.Exception("EnemyMove : ��ã�� ���� !");
        }

        _nextWayPoint = _wayPoints[0];
        _originY = _tr.position.y;
    }


    private void FixedUpdate()
    {
        _targetPos = new Vector3(_nextWayPoint.position.x,
                                 _originY,
                                 _nextWayPoint.position.z);
        _dir = (_targetPos - _tr.position).normalized;

        if (Vector3.Distance(_targetPos, _tr.position) < _posTolerance)
        {
            if (TryGetNextPoint(_wayPointIndex, out _nextWayPoint))
            {
                _wayPointIndex++;
            }
            else
            {
                OnReachedToEnd();
            }
        }

        _tr.LookAt(_targetPos);
        _tr.Translate(_dir * speed * Time.fixedDeltaTime, Space.World);
    }

    private void OnReachedToEnd()
    {
        Player.instance.life -= 1;
        _enemy.Die();
    }

    public bool TryGetNextPoint(int currentPointIndex, out Transform nextPoint)
    {
        nextPoint = null;

        if (currentPointIndex < _wayPoints.Count - 1)
        {
            nextPoint = _wayPoints[currentPointIndex + 1];
        }

        return nextPoint;
    }
}
