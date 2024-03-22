using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ItemMission : MonoBehaviour
{
    [SerializeField] protected TMP_Text _txtTitle, _txtProgress;
    
    public void SetData(string title, string progress)
    {
        _txtTitle.text = title;
        _txtProgress.text = progress;
    }
}
