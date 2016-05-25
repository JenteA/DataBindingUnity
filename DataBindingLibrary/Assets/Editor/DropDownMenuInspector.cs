using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEditor;
using UnityEngine.EventSystems;

// attach this custom inspector to all MySpecialComponent components
[CustomEditor(typeof (DropDownMenu))]
public class DropDownMenuInspector : Editor
{
    public string[] Elements;

    private DropDownMenu _drop;

    private PropertyInfo[] _propertiesFrom;
    private PropertyInfo[] _propertiesTo;

    public void OnEnable()
    {
        _drop = (DropDownMenu) target;
    }

    public override void OnInspectorGUI()
    {
        BuildElementList();

        base.OnInspectorGUI();

        EditorGUILayout.BeginHorizontal();
        _drop.IndexElementListChangeFrom = EditorGUILayout.Popup("Element List from:",
            _drop.IndexElementListChangeFrom, Elements, EditorStyles.popup);
        EditorGUILayout.EndHorizontal();

        BuildPropertyList();

        EditorGUILayout.BeginHorizontal();
        _drop.IndexPropertyListChangeFrom = EditorGUILayout.Popup("Property List from:",
            _drop.IndexPropertyListChangeFrom, _drop.PropertiesFromString, EditorStyles.popup);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        _drop.IndexElementListChangeTo = EditorGUILayout.Popup("Element List to:",
            _drop.IndexElementListChangeTo, Elements, EditorStyles.popup);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        _drop.IndexPropertyListChangeTo = EditorGUILayout.Popup("Property List to:",
            _drop.IndexPropertyListChangeTo, _drop.PropertiesToString, EditorStyles.popup);
        EditorGUILayout.EndHorizontal();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(_drop);
        }
    }

    void BuildElementList()
    {
        int i = 0;

        _drop.Go = new ArrayList(Resources.FindObjectsOfTypeAll(typeof(UIBehaviour)));

        Elements = new string[_drop.Go.Count];
        foreach (var element in _drop.Go)
        {
            Elements.SetValue(element.ToString(), i);
            i++;
        }
    }

    void BuildPropertyList()
    {
        _drop.PropertiesFrom = _drop.Go[_drop.IndexElementListChangeFrom].GetType().GetProperties();
        _drop.PropertiesTo = _drop.Go[_drop.IndexElementListChangeTo].GetType().GetProperties();

        _drop.PropertiesFromString = new string[_drop.PropertiesFrom.Length];
        _drop.PropertiesToString = new string[_drop.PropertiesTo.Length];

        int j = 0;
        foreach (PropertyInfo propertyInfo in _drop.PropertiesFrom)
        {
            _drop.PropertiesFromString.SetValue(propertyInfo.Name, j);
            j++;
        }

        j = 0;
        foreach (PropertyInfo propertyInfo in _drop.PropertiesTo)
        {
            _drop.PropertiesToString.SetValue(propertyInfo.Name, j);
            j++;
        }
    }
}
