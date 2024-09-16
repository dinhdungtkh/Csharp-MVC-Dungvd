using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DynamicWheel))]
public class DynamicWheelEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        DynamicWheel wheel = (DynamicWheel)target;

        if (GUILayout.Button("Tạo Prefab"))
        {
            wheel.GeneratePrefab();
        }
    }
}