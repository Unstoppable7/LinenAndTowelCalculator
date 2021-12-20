using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContentFiller : MonoBehaviour
{
    [SerializeField] private RectTransform containerWidth;
    [SerializeField] private RectTransform firstPreviousContent;
    [SerializeField] private RectTransform secondPreviousContent;
    [SerializeField] private int paddingFlowLayoutGroup;

    [SerializeField] private VoidEventSO fillContentEvent;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        fillContentEvent.OnEventRaised += FillContent;
    }

    private void Update()
    {
        //FillContent();
    }

    public void FillContent()
    {
        GetComponent<LayoutElement>().preferredWidth = containerWidth.rect.width - 
        firstPreviousContent.rect.width - secondPreviousContent.rect.width - paddingFlowLayoutGroup - .5f;
        
        Debug.LogWarning("Ejecuto FillContent");
    }

    private void OnDisable()
    {
        fillContentEvent.OnEventRaised -= FillContent;
    }
}
