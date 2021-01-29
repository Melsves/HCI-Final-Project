using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
public class btnHandler : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public Button btn;

    public void SetText()
    {

            string unsorted = "prisoners = [42074, 42083, 42066, 42087, 42072, 42065, 42076, 42067, 42068, 42073, 42069, 42082, 42070, 42084, 42071, 42078, 42088, 42075, 42079, 42077, 42080, 42085, 42090, 42081, 42086, 42089] ";
            string sorted = "prisoners = [42065, 42066, 42067, 42068, 42069, 42070, 42071, 42072, 42073, 42074, 42075, 42076, 42077, 42078, 42079, 42080, 42081, 42082, 42083, 42084, 42085, 42086, 42087, 42088, 42089, 42090]";

            if (txt.text.Contains("42074, 42083,"))
            {
                txt.text = sorted;
            }
            else if (txt.text.Contains("42065, 42066"))
            {
                txt.text = unsorted;
            }
        
        
        
    }
}
