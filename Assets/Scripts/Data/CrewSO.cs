using UnityEngine;

[CreateAssetMenu(fileName = "CrewSO", menuName = "Scriptable Objects/CrewSO")]
public class CrewSO : ScriptableObject
{
    [SerializeField] private int _crewId;

    [Header("���� ����")]
    [SerializeField] private string _name;
    [SerializeField] private CrewRank _rank;
    [SerializeField] private string _description;

    [Header("�ʱ� ����")]
    [SerializeField] private float _maxHealth;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _repairSpeed;
    [SerializeField] private float _attackSpeed;
    [SerializeField] private float _healSpeed;
    [SerializeField] private float _avoidance;  //ȸ����

    [Range(0,100)]
    [SerializeField] private float _evilRate;   //����

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
