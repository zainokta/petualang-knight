using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour {
    public Button[] buttons;
    public Dialogue dialogue;
    bool triggered = false;

    public void Trigger()
    {
        if (triggered)
        {
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            ShowButton();
        }
    }
    void ShowButton()
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
    }
    public void HideButton()
    {
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggered = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            triggered = false;
            FindObjectOfType<DialogueManager>().EndDialogue();
        }
    }
}
