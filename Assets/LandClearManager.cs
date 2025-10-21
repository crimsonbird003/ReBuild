using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LandClearManager : MonoBehaviour
{
    [Header("Rock Settings")]
    public List<GameObject> rocks;         // Assign rock1, rock2, rock3 here
    public Collider landArea;              // Assign the land area collider

    [Header("UI Settings")]
    public GameObject landClearedText;     // Assign the Text GameObject from Canvas

    void Update()
    {
        CheckRocks();
    }

    void CheckRocks()
    {
        bool allCleared = true;

        foreach (GameObject rock in rocks)
        {
            if (rock != null && landArea.bounds.Contains(rock.transform.position))
            {
                allCleared = false;
                break;
            }
        }

        if (allCleared)
        {
            Debug.Log("Land cleared! Ready for crops.");

            if (landClearedText != null)
            {
                StartCoroutine(ShowLandClearedMessage());
            }

            enabled = false; // Stop checking after success
        }
    }

    IEnumerator ShowLandClearedMessage()
    {
        landClearedText.SetActive(true);
        yield return new WaitForSeconds(3f); // Show for 3 seconds
        landClearedText.SetActive(false);
    }
}