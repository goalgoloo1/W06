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
    [Tooltip("�ִ�ü��")]
    [SerializeField] private float _maxHealth;
    [Tooltip("�̵��ӵ�")]
    [SerializeField] private float _moveSpeed;
    [Tooltip("���������� �ѹ��� ��� ��")]
    [SerializeField] private float _repairSpeed;
    [Tooltip("����⺻ ���ݼӵ������� ������")]
    [SerializeField] private float _attackSpeed;
    [Tooltip("�ѹ� ġ��� ġ��Ǵ� ��")]
    [SerializeField] private float _healSpeed;
    [Tooltip("�߰� ȸ����")]
    [SerializeField] private float _avoidance; 

    [Range(0,100)]
    [Tooltip("����")]
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
