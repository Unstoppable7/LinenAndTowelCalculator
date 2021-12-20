using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    [SerializeField] private FunctionOneManager _functionOneManager; 
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator InitOneFunction()
    {
        _functionOneManager.gameObject.SetActive(true);
        
        yield return new WaitForEndOfFrame();
        
        _functionOneManager.RaiseContentFillerEvent();
    }

    public void StartInitOneFunction()
    {
        StartCoroutine(InitOneFunction());
    }
    
}
