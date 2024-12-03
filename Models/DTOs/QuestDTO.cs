namespace Heroes.Models.DTOs;
public class QuestForHeroesDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Complete { get; set; }

}


public class AllQuestsDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public bool Complete { get; set; }
    public List<AllHeroesDTO> Heroes { get; set; }

}
public class SimpleQuestDTO
{
    public int Id {get; set;}
    public string Name { get; set; }
    public bool Complete { get; set; }
    
}

public class PostQuestDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}
