using System;
using UnityEngine;
using UnityEngine.UI;

public class EventManagerPublisher : MonoBehaviour
{

    public static EventManagerPublisher Instance { get; private set; }
    public event Action onButtonClick;
    public event Action offButtonClick;


    [SerializeField] private Button onButton;
    [SerializeField] private Button offButton;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

    }

    void Start()
    {

        onButton.onClick.AddListener(OnButtonclicked);
        offButton.onClick.AddListener(OffButtonclicked);

    }

    private void OffButtonclicked()
    {
        offButtonClick?.Invoke();
    }

    private void OnButtonclicked()
    {
        onButtonClick?.Invoke();
    }

}
