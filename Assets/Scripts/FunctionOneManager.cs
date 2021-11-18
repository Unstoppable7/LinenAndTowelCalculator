using System;
using UnityEditor.UIElements;
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

    // [SerializeField] private GameObject[] _UIObjectsBlock1 = new GameObject[14];
    // [SerializeField] private GameObject[] _UIObjectsBlock2 = new GameObject[14];
    // [SerializeField] private GameObject[] _UIObjectsBlock3 = new GameObject[14];
    // [SerializeField] private GameObject[] _UIObjectsBlock4 = new GameObject[14];
    
    private GameObject[][] _UIObjectsBlocksList = new GameObject[4][];

    [SerializeField] private string[] namesOfContents;
    
    // Start is called before the first frame update
    void Start()
    {
        LoadUIObjectList();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void LoadUIObjectList()
    {
        for (int i = 0; i < _UIObjectsBlocksList.Length; i++)
        {
            _UIObjectsBlocksList[i] = GameObject.FindGameObjectsWithTag("Bloque" + (i + 1));
        }
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
        
    }

    private void FillFirstBlock(int[] rsp, int nroHab)
    {
        _UIObjectsBlocksList[0][0].GetComponent<Text>().text = namesOfContents[0] + nroHab;
        for (int i = 1; i < namesOfContents.Length; i++)
        {
            _UIObjectsBlocksList[0][i].GetComponent<Text>().text = namesOfContents[i] + rsp[i - 1];
        }
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
                _UIObjectsBlocksList[i][j].GetComponent<Text>().text = namesOfContents[j] + 0;
            }
        }
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
