using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForestTrigger : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && QuestManager.Instance.currentState == QuestManager.QuestState.NotStarted)
        {
            QuestManager.Instance.UpdateQuest(QuestManager.QuestState.ReachedForest);
        }
    }
}

