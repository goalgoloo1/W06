using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    public static SoundManager Sound { get { return Instance._sound; } }
    public static MapManager Map { get { return Instance._map; } }
    public static DataManager Data { get { return Instance._data; } }
    public static UIManager UI { get { return Instance._ui; } }
    public static TruckManager Truck { get { return Instance._truck; } }
    public static PoolManager Pool { get { return Instance._pool; } }
    public static CrewManager CrewManager { get { return Instance._crew; } }
    public static InputManager Input { get { return Instance._input; } }
    
    private SoundManager _sound = new SoundManager();
    private MapManager _map = new MapManager();
    private DataManager _data = new DataManager();
    private UIManager _ui = new UIManager();
    private TruckManager _truck = new TruckManager();
    private PoolManager _pool = new PoolManager();
    private CrewManager _crew = new CrewManager();
    private InputManager _input = new InputManager();

    private State _currentState = State.Idle;
    public State CurrentState => _currentState;

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            Init();
        }
    }

    private void Init()
    {
        // �׼� ���� ������ ���� Init ���� �Դϴ�. ���� �׼� �߰��Ҷ� Init ���� �������ּ���.
        Input.Init();
        Sound.Init();
        Map.Init();
        Data.Init();
        Truck.Init();
        Pool.Init();
        CrewManager.Init();
        UI.Init();
    }

    public void ChangeState(State currentState)
    {
        _currentState = currentState;
    }
}
