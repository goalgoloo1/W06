using UnityEngine;

[CreateAssetMenu(fileName = "CrewSO", menuName = "Scriptable Objects/CrewSO")]
public class CrewSO : ScriptableObject
{
    [SerializeField] private int _crewId;

    [Header("유닛 설정")]
    [SerializeField] private string _name;
    [SerializeField] private CrewRank _rank;
    [SerializeField] private string _description;

    [Header("초기 스탯")]
    [Tooltip("최대체력")]
    [SerializeField] private float _maxHealth;
    [Tooltip("이동속도")]
    [SerializeField] private float _moveSpeed;
    [Tooltip("수리게이지 한번에 깍는 양")]
    [SerializeField] private float _repairSpeed;
    [Tooltip("무기기본 공격속도에서의 감소율")]
    [SerializeField] private float _attackSpeed;
    [Tooltip("한번 치료시 치료되는 양")]
    [SerializeField] private float _healSpeed;
    [Tooltip("추가 회피율")]
    [SerializeField] private float _avoidance; 

    [Range(0,100)]
    [Tooltip("성향")]
    [SerializeField] private float _evilRate;

    public int CrewId => _crewId;
    public string Name => _name;
    public CrewRank Rank => _rank;
    public float MaxHealth => _maxHealth;
    public float MoveSpeed => _moveSpeed;
    public float RepairSpeed => _repairSpeed;
    public float AttackSpeed => _attackSpeed;
    public float HealSpeed => _healSpeed;
    public float Avoidance => _avoidance;
    public float EvilRate => _evilRate;
}
