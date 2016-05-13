using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor;

// attach this custom inspector to all MySpecialComponent components
[CustomEditor(typeof (DropDownMenu))]
public class DropDownMenuInspector : Editor
{
    public string[] Elements;
    public string[] Properties;
    public List<GameObject> go;
    private DropDownMenu Drop;

    public void OnEnable()
    {
        Drop = (DropDownMenu) target;
    }

    public override void OnInspectorGUI()
    {

        int i = 0;
        go = new List<GameObject>(GameObject.FindGameObjectsWithTag("UI"));
        Elements = new string[go.Count];

        foreach (var element in go)
        {
            Elements.SetValue(element.name, i);
            i++;
        }

        base.OnInspectorGUI();

        Rect r = EditorGUILayout.BeginHorizontal();
        Drop.IndexElementList = EditorGUILayout.Popup("Element List:",
            Drop.IndexElementList, Elements, EditorStyles.popup);
        EditorGUILayout.EndHorizontal();
        var element1 = go[Drop.IndexElementList].GetType();
        PropertyInfo[] properties = element1.GetProperties();
        Properties = new string[properties.Length];
        int j = 0;
        foreach (PropertyInfo propertyInfo in properties)
        {
            Properties.SetValue(propertyInfo.Name, j);
            j++;
        }
        r = EditorGUILayout.BeginHorizontal();
        Drop.IndexPropertyList = EditorGUILayout.Popup("Element List:",
            Drop.IndexPropertyList, Properties, EditorStyles.popup);
        EditorGUILayout.EndHorizontal();

        if (GUI.changed)
        {
            EditorUtility.SetDirty(Drop);
        }
    }
}
