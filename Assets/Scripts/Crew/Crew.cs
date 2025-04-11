using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Crew : MonoBehaviour
{
    CrewSO _crewInfo;
    public Cell currentCell;

    // 캐릭터 스탯
    [Tooltip("캐릭터 이름")][SerializeField] string _crewCode;
    float _maxHealth;
    float _currentHealthPoint;
    float _moveSpeed;
    float _repairSpeed;
    float _attackSpeed;
    float _healSpeed;
    float _avoidance;
    float _evilRate;

    // 캐릭터 추가 스탯
    float _additionalRepairSpeed;
    float _additionalAttackSpeed;
    float _additionalHealSpeed;
    float _additionalAvoidance;

    // 캐릭터 이동
    [Tooltip("캐릭터 선택 효과")][SerializeField] SpriteRenderer _glow;
    NavMeshAgent _agent;
    Coroutine _moveCo;


    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
        _agent.updatePosition = false;
    }

    void Start()
    {
        UpdateStats();
        _currentHealthPoint = _maxHealth;
        _agent.speed = _moveSpeed;
        Spawn();

    }

    void Spawn()
    {
        currentCell.transform.parent.GetComponent<RoomSystem>().AddCrew(this);
    }

    // 캐릭터 이동 시 호출 함수
    public void Move(Vector3 targetPos)
    {
        currentCell.transform.parent.GetComponent<RoomSystem>().RemoveCrew(this);
        currentCell.CrewInCell = null;
        currentCell = RoomManager.Instance.SelectedCell;
        currentCell.CrewInCell = this;
        currentCell.transform.parent.GetComponent<RoomSystem>().AddCrew(this);
        if (_moveCo != null)
        {
            StopCoroutine(_moveCo);
            _moveCo = StartCoroutine(MoveCoroutine(targetPos));
        }
        else
        {
            _moveCo = StartCoroutine(MoveCoroutine(targetPos));
        }
    }

    // Navmesh 이용 길 찾는 코루틴
    // targetPos로 길을 찾아 이동
    // targetPos에는 이동하는 셀의 위치
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
        transform.rotation = currentCell.transform.rotation;
        RoomManager.Instance.DeselectCell();
    }

    // 캐릭터 정보 업데이트
    void UpdateStats()
    {

        _crewInfo = GameManager.Data.GetCrewInfo(_crewCode);
        _maxHealth = _crewInfo.MaxHealth;
        _moveSpeed = _crewInfo.MoveSpeed;
        _attackSpeed = _crewInfo.AttackSpeed;
        _healSpeed = _crewInfo.HealSpeed;
        _avoidance = _crewInfo.Avoidance;
        _evilRate = _crewInfo.EvilRate;

    }

    public void Heal()
    {
        _currentHealthPoint += _healSpeed + _additionalHealSpeed;
        CheckFullHealth();        
    }

    public bool CheckFullHealth()
    {
        if (_currentHealthPoint >= _maxHealth)
        {
            _currentHealthPoint = _maxHealth;
            return true;
        } else
        {
            return false;
        }
    }

    public void Damage(float amount)
    {
        _currentHealthPoint -= amount;
        if (_currentHealthPoint <= 0)
        {
            _currentHealthPoint = 0;
            Debug.Log($"{_crewCode} is dead");
            GameManager.Data.crewIsAlive[_crewCode] = false;
            Destroy(gameObject);
        }
    }

    public void ToggleGlow(bool state)
    {
        _glow.enabled = state;
    }

    /// <summary>
    /// 캐릭터 능력치 증가
    /// 0: 수리속도
    /// 1: 공격 속도
    /// 2: 치료 속도
    /// 3: 회피율
    /// </summary>
    /// <param name="code"> 증가하는 능력치 코드/// </param>
    public void UpdateAdditionalStats(int code)
    {
        switch (code)
        {
            case 0:
                Debug.Log("수리 속도 증가");
                break;
            case 1:
                Debug.Log("공격 속도 레벨업");
                break;                
            case 2:
                Debug.Log("치료 속도 레벨업");
                break;
            case 3:
                Debug.Log("회피율 증가");
                break;
            default:
                Debug.LogWarning("Invalid Stat code");
                break;
        }
    }
}
