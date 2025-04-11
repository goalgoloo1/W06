using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance {  get; private set; }   

    [SerializeField] SpriteRenderer selectCellEffect;
    public Cell SelectedCell { get; private set; }

    public List<IRoomAction> Rooms { get; private set; }

    // 캐릭터 능력치 증가
    bool _canLevelUp = true;
    Coroutine _levelUpCo;
    [SerializeField] float _levelUpSpeed;

    //셀 선택시 플레이어 움직일 셀 관리
    //전투 시 방 행동
    //일단 monobehavior 지만 가능하면 나중에 리팩토링으로 변경

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        Rooms = new List<IRoomAction>();
    }
    void Start()
    {
        GameManager.Input.selectCellAction += SelectCell;
        GameManager.Input.deselectCellAction += DeselectCell;
    }

    private void Update()
    {
        foreach (IRoomAction room in Rooms)
        {
            room.RoomAction();
            if(_canLevelUp)
            {
                _canLevelUp = false;
                room.crewLevelUp();
                _levelUpCo = StartCoroutine(crewLevelUpCoroutine());
            }
        }
    }
    void SelectCell(GameObject cellToMove)
    {
        SelectedCell = cellToMove.GetComponent<Cell>();
        selectCellEffect.transform.position = cellToMove.transform.position;
        selectCellEffect.enabled = true;
        CrewController.Instance.SelectedCrew.Move(SelectedCell.transform.position);
        CrewController.Instance.SelectedCrew.currentCell = SelectedCell;
        CrewController.Instance.SelectedCrew.currentCell.CrewInCell = CrewController.Instance.SelectedCrew;
        CrewController.Instance.SelectedCrew.currentCell.transform.parent.GetComponent<RoomSystem>().AddCrew(CrewController.Instance.SelectedCrew);
        CrewController.Instance.Deselect();
    }

    public void DeselectCell()
    {
        SelectedCell = null;
        selectCellEffect.enabled = false;
    }

    IEnumerator crewLevelUpCoroutine()
    {
        yield return new WaitForSeconds(_levelUpSpeed);
        _canLevelUp = true;
    }
}
