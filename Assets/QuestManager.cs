using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public static QuestManager Instance;

    public enum QuestState
    {
        NotStarted,
        ReachedForest,
        TalkedToFarmer,
        LandCleared,
        TalkedToTrader,
        Completed
    }

    public QuestState currentState = QuestState.NotStarted;

    void Awake()
    {
        // Singleton pattern so other scripts can access this easily
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void UpdateQuest(QuestState newState)
    {
        currentState = newState;
        Debug.Log("Quest updated to: " + currentState);
        // You can add UI updates here later
    }
}
