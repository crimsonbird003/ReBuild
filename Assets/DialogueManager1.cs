
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public TextMeshProUGUI dialogueText;

    void Awake()
    {
        Instance = this;
    }

    public void ShowMessage(string message)
    {
        dialogueText.text = message;
        CancelInvoke("ClearMessage");
        Invoke("ClearMessage", 5f);
    }

    void ClearMessage()
    {
        dialogueText.text = "";
    }
}
