using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class BaseItemSelectButton : MonoBehaviour
{
    public int index;
    public Image baseImg;
    public TMP_Text baseName;
    

    public void ChangeUI(Sprite sprite, string txtName)
    {
        baseImg.sprite = sprite;
        baseName.text = txtName;
    }

    public abstract void BtnListener_Select();
}