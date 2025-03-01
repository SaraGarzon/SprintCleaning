using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class CustomButton : CustomUIComponent
{
    public ThemeSO _theme;
    public Style _style;

    private Button _button;
    private TextMeshProUGUI _buttonText;

    private EndingMenu _endingMenu;
    public override void Setup()
    {
        _button = GetComponentInChildren<Button>();
        _buttonText = GetComponentInChildren<TextMeshProUGUI>();
    }
    public override void Configure()
    {
        ColorBlock colorBlock = _button.colors;
        colorBlock.normalColor = _theme._buttonGeneric_bg;
        _button.colors = colorBlock;

        _buttonText.color = _theme._buttonGeneric_txt;
    }
}
