using System.Collections;
using TMPro;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    [SerializeField] private TMP_Text dialogueText;
    [SerializeField] private string[] words;
    [SerializeField] private float speedOfWriting;
    [SerializeField] private float waitONewfWord;

    private int index;

    void Start()
    {
        DialogTriggerManager.Instance.DialogueSetActive += setActive;
        DialogTriggerManager.Instance.DialogueDeactive += Deactive;   
    }

    private void Deactive()
    {
        StopAllCoroutines();
        dialogueText.text = "";
        index = 0;
    }

    private void setActive()
    {
        StartCoroutine(Writing());
    }

    IEnumerator Writing()
    {
        foreach (char word in words[index].ToCharArray())
        {

            dialogueText.text += word;
            yield return new WaitForSeconds(speedOfWriting);
        }

        if (index < words.Length - 1)
        {
            yield return new WaitForSeconds(waitONewfWord);
            dialogueText.text = "";
            index++;

            StartCoroutine(Writing());
        }
    }

    void OnDisable()
    {
        DialogTriggerManager.Instance.DialogueSetActive -= setActive;
        DialogTriggerManager.Instance.DialogueDeactive -= Deactive;
    }
}
