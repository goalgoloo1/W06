using TMPro;
using UnityEngine;

public class FuelEventUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _description;

    // UI 디자인이 나오기전엔 모르므로 예시일 뿐입니다.
    public void GetUIInfomation(FuelEventResultDto dto)
    {
        _description.text = dto.description;
    }
}
