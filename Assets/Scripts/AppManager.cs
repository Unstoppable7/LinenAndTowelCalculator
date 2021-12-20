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
        if (Application.platform == RuntimePlatform.Android) {
        
            // Check if Back was pressed this frame
            if (Input.GetKeyDown(KeyCode.Escape) && !_functionOneManager.gameObject.activeSelf) {
                
                // Quit the application
                Application.Quit();
            }
        }
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
