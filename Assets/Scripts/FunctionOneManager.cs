using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FunctionOneManager : MonoBehaviour
{
    // #region constant strings
    //
    // private const string NAME_HAB = "Habitaciones: ";
    // private const string NAME_FIRST_CONTENT = "K";
    // private const string NAME_SECOND_CONTENT = "Q";
    // private const string NAME_THIRD_CONTENT = "G";
    // private const string NAME_FOURTH_CONTENT = "M";
    // private const string NAME_FIFTH_CONTENT = "P";
    // private const string NAME_SIXTH_CONTENT = "Pie";
    //
    // #endregion
    
    [SerializeField] private InputField _inputField;

    [SerializeField] private GameObject[] _UIObjectsBlock1;
    [SerializeField] private GameObject[] _UIObjectsBlock2;
    [SerializeField] private GameObject[] _UIObjectsBlock3;
    [SerializeField] private GameObject[] _UIObjectsBlock4;
    
    private GameObject[][] _UIObjectsBlocksList = new GameObject[4][];
    
    #region variables for text lost when canceling keyboard

    private string _oldEditText;
    private string _editText;
    
    #endregion

    [SerializeField] private VoidEventSO contentFillerEvent;

    // Start is called before the first frame update
    void Start()
    {
        LoadUIObjectList();
        if (Application.isMobilePlatform)
        {

            _inputField.onEndEdit.AddListener(EndEdit);
            _inputField.onValueChanged.AddListener(Editing);
        }
        
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android) {
        
            // Volver a atras con el boton o el gesto de Android
            if (Input.GetKeyDown(KeyCode.Escape)){
                
                gameObject.SetActive(false);
            }
        }
    }

    public void RaiseContentFillerEvent()
    {
        contentFillerEvent.RaiseEvent();
    }
    
    private void Editing(string currentText)
    {
        _oldEditText = _editText;
        _editText = currentText;
    }
    private void EndEdit(string currentText)
    {
        if (_inputField.touchScreenKeyboard.status == TouchScreenKeyboard.Status.Canceled && 
            !string.IsNullOrEmpty(_oldEditText))
        {
            _editText = _oldEditText;
            _inputField.text = _oldEditText;
        }
        
        if (_inputField.touchScreenKeyboard.status == TouchScreenKeyboard.Status.Done)
        {
            ShowCalculationResult();
            _inputField.text = "";
        }

    }


    private void LoadUIObjectList()
    {
        // for (int i = 0; i < _UIObjectsBlocksList.Length; i++)
        // {
        //     _UIObjectsBlocksList[i] = GameObject.FindGameObjectsWithTag("Bloque" + (i + 1));
        // }
        //Toco hacerlo asi porque con los tags perdia el orden que tienen en unity
        _UIObjectsBlocksList[0] = _UIObjectsBlock1;
        _UIObjectsBlocksList[1] = _UIObjectsBlock2;
        _UIObjectsBlocksList[2] = _UIObjectsBlock3;
        _UIObjectsBlocksList[3] = _UIObjectsBlock4;
    }

    private IEnumerator InitContentFillerEvent()
    {
        yield return new WaitForEndOfFrame();
        contentFillerEvent.RaiseEvent();

    }
    
    public void ShowCalculationResult()
    {
        int nroHab = 0;
        try
        {
            nroHab = Int32.Parse(_inputField.text);
        }
        catch (FormatException)
        {
            Console.WriteLine($"Unable to parse '{_inputField.text}'");
        }

        OrganizeBlocks();
        FillFirstBlock(Calculator.ForNroHab(nroHab), nroHab);

        StartCoroutine(InitContentFillerEvent());
    }

    private void FillFirstBlock(int[] rsp, int nroHab)
    {
        _UIObjectsBlocksList[0][0].GetComponent<Text>().text = nroHab.ToString();
        for (int i = 1; i < _UIObjectsBlocksList[0].Length; i++)
        {
            _UIObjectsBlocksList[0][i].GetComponent<Text>().text = rsp[i - 1].ToString();
        }
        
        //TODO crear variable independiente para cada bloque del historial
        //prueba
        //print(LocalizationEditorSettings.GetStringTableCollection("UI strings").);
        // var op = LocalizationSettings.StringDatabase.GetLocalizedStringAsync("UI strings", 
        //     "sabanas");
        // if (op.IsDone)
        //     Debug.Log("1ro: " + op.Result);
        // else
        //     op.Completed += (op) => Debug.Log("2do: " + op.Result);
    }
    private void OrganizeBlocks()
    {
        for (int i = _UIObjectsBlocksList.Length - 1 ; i > 0 ; i--)
        {
            for (int j = 0; j < _UIObjectsBlocksList[i].Length ; j++)
            {
                _UIObjectsBlocksList[i][j].GetComponent<Text>().text = _UIObjectsBlocksList[i - 1][j].GetComponent<Text>().text;
            }
        }
    }

    public void ClearHistory()
    {
        for (int i = 0 ; i < _UIObjectsBlocksList.Length ; i++)
        {
            for (int j = 0; j < _UIObjectsBlocksList[i].Length ; j++)
            {
                _UIObjectsBlocksList[i][j].GetComponent<Text>().text = "0";
            }
        }
        StartCoroutine(InitContentFillerEvent());

    }
    
    // private int CheckBlockAvailable()
    // {
    //     for (int i = 0; i < 4; i++)
    //     {
    //         if (BlockIsEmpty(i))
    //         {
    //             return i + 1;
    //         }
    //     }
    //
    //     return -1;
    // }
    //
    // private bool BlockIsEmpty(int i)
    // {
    //     return _UIObjectsBlocksList[i][0].GetComponent<Text>().text == "-1";
    // }
    public string GETValueInputField()
    {
        return _inputField.text;
    } 
}
