using UnityEngine;

public class HireEventResultDto
{
    public CrewSO crew;
    public string description;

    public HireEventResultDto()
    {
        crew = null;
        description = string.Empty;
    }

    public HireEventResultDto(CrewSO crew, string description)
    {
        this.crew = crew;
        this.description = description;
    }
}
