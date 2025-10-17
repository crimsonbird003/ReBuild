[System.Serializable]
public class Quest
{
    public string questId;
    public string title;
    public string description;
    public bool isCompleted;
    public bool isActive;

    public Quest(string id, string title, string description)
    {
        this.questId = id;
        this.title = title;
        this.description = description;
        this.isCompleted = false;
        this.isActive = false;
    }
}