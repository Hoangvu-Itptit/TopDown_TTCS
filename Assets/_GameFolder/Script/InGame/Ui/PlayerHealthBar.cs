using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBar : BaseHealthBar
{
    public Text numberBullet;
    
    public void UpdateNumberBullet(string number)
    {
        numberBullet.text = number;
    }
}