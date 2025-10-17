using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    private Dictionary<string, Quest> activeQuests = new();
    private Dictionary<string, Quest> completedQuests = new();

    void Awake()
    {
        // Singleton pattern for global access
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Optional: persist across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddQuest(Quest quest)
    {
        if (!activeQuests.ContainsKey(quest.questId))
        {
            quest.isActive = true;
            activeQuests.Add(quest.questId, quest);
            Debug.Log($"Quest added: {quest.title}");
        }
    }

    public void CompleteQuest(string questId)
    {
        if (activeQuests.TryGetValue(questId, out Quest quest))
        {
            quest.isCompleted = true;
            quest.isActive = false;
            activeQuests.Remove(questId);
            completedQuests.Add(questId, quest);
            Debug.Log($"Quest completed: {quest.title}");
        }
    }

    public bool IsQuestActive(string questId)
    {
        return activeQuests.ContainsKey(questId);
    }

    public bool IsQuestCompleted(string questId)
    {
        return completedQuests.ContainsKey(questId);
    }

    public IEnumerable<Quest> GetActiveQuests()
    {
        return activeQuests.Values;
    }

    public IEnumerable<Quest> GetCompletedQuests()
    {
        return completedQuests.Values;
    }
}