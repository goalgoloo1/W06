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
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _repairSpeed;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _healSpeed;
    [SerializeField] private float _avoidance;  //회피율

    [Range(0,100)]
    [SerializeField] private float _evilRate;   //성향

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
