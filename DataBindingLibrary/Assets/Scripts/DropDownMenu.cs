using System;
using UnityEngine;
using System.Collections;
using System.Reflection;
using System.Threading;
using UnityEngine.UI;

public class DropDownMenu : MonoBehaviour
{
    [HideInInspector] public int IndexElementListChangeFrom;
    [HideInInspector] public int IndexPropertyListChangeFrom;
    [HideInInspector] public int IndexElementListChangeTo;
    [HideInInspector] public int IndexPropertyListChangeTo;

    public ArrayList Go;

    private string _curVal;
    private string _prevVal;

    [HideInInspector] public string[] PropertiesFromString;
    [HideInInspector] public string[] PropertiesToString;
    [HideInInspector] public PropertyInfo[] PropertiesFrom;
    [HideInInspector] public PropertyInfo[] PropertiesTo;

    void Update()
    {
        PropertiesTo[IndexPropertyListChangeTo].SetValue(Go[IndexElementListChangeTo], Convert.ChangeType(PropertiesFrom[IndexPropertyListChangeFrom].GetValue(Go[IndexElementListChangeFrom], null),
            PropertiesTo[IndexPropertyListChangeTo].PropertyType),null);
        print(PropertiesTo[IndexPropertyListChangeTo].GetValue(Go[IndexElementListChangeTo],null));
    }
}
