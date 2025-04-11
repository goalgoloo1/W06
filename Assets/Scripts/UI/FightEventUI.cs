using TMPro;
using UnityEngine;

public class FightEventUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _description;

    // UI �������� ���������� �𸣹Ƿ� ������ ���Դϴ�.
    public void GetUIInfomation(FightEventResultDto dto)
    {
        _description.text = dto.description;
    }
}
