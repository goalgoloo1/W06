using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CrewController : MonoBehaviour
{
    CrewSO _crewInfo;

    // 캐릭터 스탯/정보
    string _crewCode;
    float _maxHealthPoint;
    float _currentHealthPoint;
    float _moveSpeed;
    float _attackSpeed;
    float _healSpeed;
    float _missChance;
    float _allignment;

    // 캐릭터 추가 스탯
    float _additionalAttackSpeed;
    float _additionalHealSpeed;
    float _additionalMissChance;

    // 캐릭터 이동
    NavMeshAgent _agent;
    Coroutine _moveCo;


    void Start()
    {
        UpdateStats();
        _currentHealthPoint = _maxHealthPoint;
        _agent = GetComponent<NavMeshAgent>();
        _agent.updatePosition = false;
        _agent.updateUpAxis = false;
        _agent.updatePosition = false;
        _agent.speed = _moveSpeed;
    }

    void UpdateStats()
    {
        /*
         * _crewInfo = GameManager.Data.GetCrewInfo(_crewCode);
         * _maxHealthPoint = _crewInfo.healthPoint;
         * _moveSpeed = crewInfo.moveSpeed;
         * _attackSpeed = crewInfo.attackSpeed;
         * _healSpeed = crewInfo.healSpeed;
         * _missChance = crewInfo.missChance;
         * _allignment = crewInfo.allignment;
         */
    }

    public void Move(Vector3 targetPos)
    {
        if (_moveCo != null) { 
            StopCoroutine(_moveCo);
            _moveCo = StartCoroutine(MoveCoroutine(targetPos));
        }
        else
        {
            _moveCo = StartCoroutine(MoveCoroutine(targetPos));
        }
    }

    IEnumerator MoveCoroutine(Vector3 targetPos)
    {
        _agent.SetDestination(targetPos);
        Debug.Log($"{_crewCode} is moving");
        while (Vector2.Distance(transform.position, targetPos) > 0.01f)
        {
            Vector3 diff = _agent.nextPosition - transform.position;
            float angle = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.position = _agent.nextPosition;
            transform.rotation = Quaternion.Euler(0f, 0f, angle);
            yield return null;
        }
        transform.position = targetPos;
    }

    public void Heal()
    {
        _currentHealthPoint += _healSpeed + _additionalHealSpeed;
        if( _currentHealthPoint >= _maxHealthPoint)
        {
            _currentHealthPoint = _maxHealthPoint;
        }
    }

    public void Damage(float amount)
    {
        _currentHealthPoint -= amount;
        if(_currentHealthPoint <= 0)
        {
            _currentHealthPoint = 0;
            Debug.Log($"{_crewCode} is dead");
            Destroy(gameObject);
        }
    }
}
