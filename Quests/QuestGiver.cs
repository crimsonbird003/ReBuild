using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public string questId = "ForestQuest";

    private bool questGiven = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !questGiven)
        {
            Quest quest = new Quest(questId, "Signs of Life", "Find a Forest and a Farmer in this war struck land");
            QuestManager.Instance.AddQuest(quest);
            questGiven = true;
        }
    }
}