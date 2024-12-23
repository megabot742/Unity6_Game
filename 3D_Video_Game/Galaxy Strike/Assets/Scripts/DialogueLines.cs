using TMPro;
using UnityEngine;

public class DialogueLines : MonoBehaviour
{
    [SerializeField] string[] timelineTextLines;
    [SerializeField] TMP_Text dialogueText;
    int currentLine = 0;
    public void NextDiaglogueLine()
    {
        dialogueText.text = timelineTextLines[currentLine].ToString();
        currentLine++;
    }
}
