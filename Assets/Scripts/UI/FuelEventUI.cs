using TMPro;
using UnityEngine;

public class FuelEventUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _description;

    // UI �������� ���������� �𸣹Ƿ� ������ ���Դϴ�.
    public void GetUIInfomation(FuelEventResultDto dto)
    {
        _description.text = dto.description;
    }
}
