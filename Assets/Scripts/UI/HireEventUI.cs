using TMPro;
using UnityEngine;

public class HireEventUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _description;

    // UI �������� ���������� �𸣹Ƿ� ������ ���Դϴ�.
    public void GetUIInfomation(HireEventResultDto dto)
    {
        _description.text = dto.description;
    }
}
