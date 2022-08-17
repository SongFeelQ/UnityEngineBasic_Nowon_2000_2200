using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public enum State
    {
        Idle,
        Move,
        Attack,
        Hurt,
        Die,
    }

    private enum IdleState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }
    private enum MoveState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }
    private enum AttackState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }
    private enum HurtState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }
    private enum DieState
    {
        Idle,
        Prepare,
        Casting,
        OnAction,
        Finish,
    }

    private enum AIState
    {
        Idle,
        Think,
        Rest,
        MoveLeft,
        MoveRight,
        FollowTarget,
        AttackTarget,
    }

    [SerializeField] private State _state;
    [SerializeField] private IdleState _idleState;
    [SerializeField] private MoveState _moveState;
    [SerializeField] private AttackState _attackState;
    [SerializeField] private HurtState _hurtState;
    [SerializeField] private DieState _dieState;
    [SerializeField] private AIState _aiState;
    private Vector2 _move;

    [Header("AI")]
    [SerializeField] private bool _aiAutoFollow;
    [SerializeField] private bool _aiAttackable;
    [SerializeField] private float _aiTargetDetectRange;
    [SerializeField] private float _aiBehaviorTimeMin;
    [SerializeField] private float _aiBehaviorTimeMax;
    private float _aiBehaviorTimer;

    [Header("Movement")]
    [SerializeField] private float _moveSpeed;

    // -1 : left, +1 : right
    private int _direction;
    public int direction
    {
        get
        {
            return _direction;
        }
        set
        {
            if (value < 0)
            {
                _direction = -1;
                transform.eulerAngles = Vector3.zero;
            }
            else
            {
                _direction = 1;
                transform.eulerAngles = new Vector3(0.0f, 180.0f, 0.0f);
            }
        }
    }
    [SerializeField] private int _directionInit;

    [SerializeField] private LayerMask _aiTargetLayer;

    private Animator _animator;
    private Rigidbody2D _rb;
    private CapsuleCollider2D _col;

    private float _animationTimer;
    private float _attackTime;
    private float _hurtTime;
    private float _dieTime;

    private float h { get => Input.GetAxis("Horizontal"); }
    private float v { get => Input.GetAxis("Vertical"); }

    private bool _isMovable = true;
    private bool _isDirectionChangable = true;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _col = GetComponent<CapsuleCollider2D>();
        _animator = GetComponent<Animator>();
        _attackTime = GetAnimationTime("Attack");
        _hurtTime = GetAnimationTime("Hurt");
        _dieTime = GetAnimationTime("Die");
    }

    private void Update()
    {
        UpdateAIState();

        if (_isDirectionChangable)
        {
            if (_move.x < 0.0f)
                direction = -1;
            else if (_move.x > 0.0f)
                direction = 1;
        }

        if (_isMovable)
        {
            if (Mathf.Abs(_move.x) > 0.0f)
                ChangeState(State.Move);
            else
                ChangeState(State.Idle);
        }

        UpdateState();
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(_move.x * _moveSpeed, _move.y, 0) * Time.fixedDeltaTime;
    }

    private void UpdateState()
    {
        switch (_state)
        {
            case State.Idle:
                UpdateIdleState();
                break;
            case State.Move:
                UpdateMoveState();
                break;
            case State.Attack:
                UpdateAttackState();
                break;
            case State.Hurt:
                UpdateHurtState();
                break;
            case State.Die:
                UpdateDieState();
                break;
            default:
                break;
        }

    }
    private void ChangeState(State newState)
    {
        if (_state == newState)
            return;

        switch (_state)
        {
            case State.Idle:
                _idleState = IdleState.Idle;
                break;
            case State.Move:
                _moveState = MoveState.Idle;
                break;
            case State.Attack:
                _attackState = AttackState.Idle;
                break;
            case State.Hurt:
                _hurtState = HurtState.Idle;
                break;
            case State.Die:
                _dieState = DieState.Idle;
                break;
            default:
                break;
        }

        switch (newState)
        {
            case State.Idle:
                _idleState = IdleState.Prepare;
                break;
            case State.Move:
                _moveState = MoveState.Prepare;
                break;
            case State.Attack:
                _attackState = AttackState.Prepare;
                break;
            case State.Hurt:
                _hurtState = HurtState.Prepare;
                break;
            case State.Die:
                _dieState = DieState.Prepare;
                break;
            default:
                break;
        }
    }
    private void UpdateAIState()
    {
        if (Physics2D.OverlapCircle(_rb.position, _aiTargetDetectRange, _aiTargetLayer))
            _aiState = AIState.FollowTarget;
        else
        {
            // todo -> Check Player hit
        }

        switch (_aiState)
        {
            case AIState.Idle:
                break;
            case AIState.Think:
                _move.x = 0;
                _aiBehaviorTimer = Random.Range(_aiBehaviorTimeMin, _aiBehaviorTimeMax);
                _aiState = (AIState)Random.Range((int)AIState.Rest, (int)AIState.FollowTarget);
                break;
            case AIState.Rest:
                if (_aiBehaviorTimer < 0)
                {
                    _aiState = AIState.Think;
                }
                else
                {
                    _aiBehaviorTimer -= Time.deltaTime;
                }
                break;
            case AIState.MoveLeft:
                if (_aiBehaviorTimer < 0)
                {
                    _aiState = AIState.Think;
                }
                else
                {
                    _move.x = -1;
                    _aiBehaviorTimer -= Time.deltaTime;
                }
                break;
            case AIState.MoveRight:
                if (_aiBehaviorTimer < 0)
                {
                    _aiState = AIState.Think;
                }
                else
                {
                    _move.x = 1;
                    _aiBehaviorTimer -= Time.deltaTime;
                }
                break;
            case AIState.FollowTarget:

                Collider2D target = Physics2D.OverlapCircle(_rb.position, _aiTargetDetectRange, _aiTargetLayer);

                // Ÿ���� ������ ����ٸ�
                if (target == null)
                {
                    _aiState = AIState.Think;
                }
                // Ÿ���� ���� ���� ������
                else
                {
                    if (target.transform.position.x > _rb.position.x + _col.size.x)
                    {
                        _move.x = 1.0f;
                    }
                    else if (target.transform.position.x < _rb.position.x - _col.size.x)
                    {
                        _move.x = -1.0f;
                    }
                }
                break;
            case AIState.AttackTarget:
                break;
            default:
                break;
        }

    }
    private void UpdateIdleState()
    {
        switch (_idleState)
        {
            case IdleState.Idle:
                break;
            case IdleState.Prepare:
                break;
            case IdleState.Casting:
                break;
            case IdleState.OnAction:
                break;
            case IdleState.Finish:
                break;
            default:
                break;
        }
    }
    private void UpdateMoveState()
    {
        switch (_moveState)
        {
            case MoveState.Idle:
                break;
            case MoveState.Prepare:
                break;
            case MoveState.Casting:
                break;
            case MoveState.OnAction:
                break;
            case MoveState.Finish:
                break;
            default:
                break;
        }
    }
    private void UpdateAttackState()
    {
        switch (_attackState)
        {
            case AttackState.Idle:
                break;
            case AttackState.Prepare:
                break;
            case AttackState.Casting:
                break;
            case AttackState.OnAction:
                break;
            case AttackState.Finish:
                break;
            default:
                break;
        }
    }
    private void UpdateHurtState()
    {
        switch (_hurtState)
        {
            case HurtState.Idle:
                break;
            case HurtState.Prepare:
                break;
            case HurtState.Casting:
                break;
            case HurtState.OnAction:
                break;
            case HurtState.Finish:
                break;
            default:
                break;
        }
    }    
    private void UpdateDieState()
    {
        switch (_dieState)
        {
            case DieState.Idle:
                break;
            case DieState.Prepare:
                break;
            case DieState.Casting:
                break;
            case DieState.OnAction:
                break;
            case DieState.Finish:
                break;
            default:
                break;
        }
    }
    private float GetAnimationTime(string clipName)
    {
        RuntimeAnimatorController rac = _animator.runtimeAnimatorController;
        for (int i = 0; i < rac.animationClips.Length; i++)
        {
            if (rac.animationClips[i].name == clipName)
            {
                return rac.animationClips[i].length;
            }
        }
        Debug.LogWarning($"GetAnimationTime : {clipName} �� ã�� �� �����ϴ�.");
        return -1.0f;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _aiTargetDetectRange);
    }
}