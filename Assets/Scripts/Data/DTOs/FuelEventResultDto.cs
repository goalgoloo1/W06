using UnityEngine;

public class FuelEventResultDto
{
    // DTO�� ������ ��ݰ�ü�̱� ������, ���ͼ��� ���� public������ ����մϴ�.
    public int fuel;
    public string description;

    public FuelEventResultDto()
    {
        fuel = 0;
        description = string.Empty;
    }

    public FuelEventResultDto(int fuel, string description)
    {
        this.fuel = fuel;
        this.description = description;
    }
}
