using System;
using UnityEngine;

public class DialogTriggerManager : MonoBehaviour
{

    public static DialogTriggerManager Instance { get; private set; }

    public Action DialogueSetActive;
    public Action DialogueDeactive;
    [SerializeField] private GameObject dialogueCloud;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DialogueSetActive?.Invoke();

            if (!dialogueCloud.activeSelf)
            {
                dialogueCloud.SetActive(true);
            }
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            DialogueDeactive?.Invoke();

            if (dialogueCloud.activeSelf)
            {
                dialogueCloud.SetActive(false);
            }
        }
    }

}
