using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance {  get; private set; }   

    [SerializeField] SpriteRenderer selectCellEffect;
    public Cell SelectedCell { get; private set; }

    //셀 선택시 플레이어 움직일 셀 관리
    //전투 시 방 행동
    //일단 monobehavior 지만 가능하면 나중에 리팩토링으로 변경

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        GameManager.Input.selectCellAction += SelectCell;
        GameManager.Input.deselectCellAction += DeselectCell;
    }

    void SelectCell(GameObject cellToMove)
    {
        SelectedCell = cellToMove.GetComponent<Cell>();
        selectCellEffect.transform.position = cellToMove.transform.position;
        selectCellEffect.enabled = true;
        CrewController.Instance.SelectedCrew.currentCell = SelectedCell;
        CrewController.Instance.SelectedCrew.currentCell.CrewInCell = CrewController.Instance.SelectedCrew;
        CrewController.Instance.SelectedCrew.Move(SelectedCell.transform.position);
        CrewController.Instance.Deselect();
    }

    public void DeselectCell()
    {
        SelectedCell = null;
        selectCellEffect.enabled = false;
    }
}
