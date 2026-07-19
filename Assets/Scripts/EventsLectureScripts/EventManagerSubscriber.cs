using System;
using UnityEngine;

public class EventManagerSubscriber : MonoBehaviour
{

    [SerializeField] private Transform panel;

    void Start()
    {
        EventManagerPublisher.Instance.onButtonClick += onButtonClicked;
        EventManagerPublisher.Instance.offButtonClick += offButtonClicked;
    }

    private void offButtonClicked()
    {
        if(panel.gameObject.activeSelf == false) return;

        panel.gameObject.SetActive(false);
        Debug.Log("OffButtonEvent is working ");
    }

    private void onButtonClicked()
    {
        if(panel.gameObject.activeSelf == true) return;

        panel.gameObject.SetActive(true);
        Debug.Log("OnButtonEvent is working ");
    }

    void OnDisable()
    {
        EventManagerPublisher.Instance.onButtonClick -= onButtonClicked;
        EventManagerPublisher.Instance.offButtonClick -= offButtonClicked;
    }

}
