using System.Collections;
using System.Collections.Generic;
using TMPro;

public class Notify : BasePopup
{
    public TMP_Text txtTitle;

    public TMP_Text txtContent;

    public void UpdateNotify(string title, string content)
    {
        txtTitle.text = title;
        txtContent.text = content;
    }

    public void UpdateTitle(string title)
    {
        txtTitle.text = title;
    }

    public void UpdateContent(string content)
    {
        txtContent.text = content;
    }
}