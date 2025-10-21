using System.Collections;
using UnityEngine;
using TMPro;

public class ShelterBuilder : MonoBehaviour
{
    [Header("Shelter Settings")]
    public int treesNeeded = 3;
    public GameObject hutPrefab;
    public Transform buildSpot;

    [Header("UI Settings")]
    public TextMeshProUGUI questMessageText; // Assign the TMP component directly in Inspector

    private int treesCut = 0;
    private bool shelterBuilt = false;

    void Update()
    {
        // Left click to cut tree
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 5f))
            {
                if (hit.collider.CompareTag("Tree") && !shelterBuilt)
                {
                    Destroy(hit.collider.gameObject);
                    treesCut++;

                    ShowTempMessage($"🌲 Tree chopped: {treesCut}/{treesNeeded}");

                    if (treesCut >= treesNeeded)
                        BuildShelter();
                }
            }
        }
    }

    void BuildShelter()
    {
        if (hutPrefab != null && buildSpot != null)
        {
            Instantiate(hutPrefab, buildSpot.position, buildSpot.rotation);
            shelterBuilt = true;
            ShowTempMessage("🏠 Shelter built! Return to the Trader.");

            // Notify Trader
            TraderQuest trader = FindObjectOfType<TraderQuest>();
            if (trader != null)
                trader.MarkShelterBuilt();
        }
        else
        {
            Debug.LogError("ShelterBuilder: Assign Hut Prefab and BuildSpot in Inspector!");
        }
    }

    void ShowTempMessage(string message)
    {
        if (questMessageText != null)
            StartCoroutine(ShowMessageCoroutine(message));
        else
            Debug.LogWarning("ShelterBuilder: questMessageText not assigned!");
    }

    IEnumerator ShowMessageCoroutine(string message)
    {
        if (questMessageText == null)
        {
            Debug.LogError("ShelterBuilder: questMessageText not assigned!");
            yield break;
        }

        questMessageText.gameObject.SetActive(true);
        questMessageText.text = message;

        yield return new WaitForSeconds(3f);

        questMessageText.gameObject.SetActive(false);
    }
}
