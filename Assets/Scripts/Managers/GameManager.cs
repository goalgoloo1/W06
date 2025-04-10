using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private static SoundManager Sound { get { return Instance._sound; } }
    private static MapManager Map { get { return Instance._map; } }
    private static DataManager Data { get { return Instance._data; } }
    private static UIManager UI { get { return Instance._ui; } }
    private static TruckManager Truck { get { return Instance._truck; } }
    private static PoolManager Pool { get { return Instance._pool; } }
    private static CrewManager CrewManager { get { return Instance._crew; } }
    private static InputManager Input { get { return Instance._input; } }

    private SoundManager _sound = new SoundManager();
    private MapManager _map = new MapManager();
    private DataManager _data = new DataManager();
    private UIManager _ui = new UIManager();
    private TruckManager _truck = new TruckManager();
    private PoolManager _pool = new PoolManager();
    private CrewManager _crew = new CrewManager();
    private InputManager _input = new InputManager();

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
        // 액션 순서 관리를 위한 Init 순서 입니다. 따라서 액션 추가할때 Init 순서 변경해주세요.
        Input.Init();
        Sound.Init();
        Map.Init();
        Data.Init();
        Truck.Init();
        Pool.Init();
        CrewManager.Init();
        UI.Init();
    }
}
