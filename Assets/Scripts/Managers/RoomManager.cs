using UnityEngine;

public class RoomManager : MonoBehaviour
{
    public static RoomManager Instance {  get; private set; }   

    [SerializeField] SpriteRenderer selectCellEffect;
    public Cell SelectedCell { get; private set; }

    //�� ���ý� �÷��̾� ������ �� ����
    //���� �� �� �ൿ
    //�ϴ� monobehavior ���� �����ϸ� ���߿� �����丵���� ����

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
