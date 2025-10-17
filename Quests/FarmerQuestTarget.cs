    using UnityEngine;

public class FarmerQuestTarget : MonoBehaviour, IInteractable
{
    public string questId = "find_farmer";
    private bool questCompleted = false;

    public void Interact()
    {
        if (!questCompleted && QuestManager.Instance.IsQuestActive(questId))
        {
            QuestManager.Instance.CompleteQuest(questId);
            questCompleted = true;

            // Optional: trigger dialogue, animation, or reward
            Debug.Log("You spoke with the farmer. Quest complete!");
        }
    }
}