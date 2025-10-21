using UnityEngine;

public class TraderQuest : MonoBehaviour
{
    private bool playerNear = false;
    private bool shelterBuilt = false;
    private bool questGiven = false;

    void Update()
    {
        if (playerNear && Input.GetKeyDown(KeyCode.E))
        {
            if (!questGiven)
            {
                DialogueManager.Instance.ShowMessage("🪓 Trader: I’ll give you seeds, but first build a shelter by cutting trees!");
                questGiven = true;
            }
            else if (shelterBuilt)
            {
                DialogueManager.Instance.ShowMessage("🌱 Trader: Well done! Here are the seeds to start rebuilding life.");
            }
            else
            {
                DialogueManager.Instance.ShowMessage("🏚️ Trader: Come back after building your shelter!");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNear = true;
            DialogueManager.Instance.ShowMessage("Press E to talk to the Trader.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            playerNear = false;
    }

    public void MarkShelterBuilt()
    {
        shelterBuilt = true;
    }
}
