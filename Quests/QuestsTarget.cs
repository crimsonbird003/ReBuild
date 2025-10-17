using UnityEngine;

public class QuestTarget : MonoBehaviour
{
    public string questId = "ForestQuest";

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && QuestManager.Instance.IsQuestActive(questId))
        {
            QuestManager.Instance.CompleteQuest(questId);
            questCompleted = true;

            // Optional: show feedback
            Debug.Log("Quest completed: " + questId);
            // You can trigger animations, change materials, play sounds, etc.
        }
    }

        }
    }
}