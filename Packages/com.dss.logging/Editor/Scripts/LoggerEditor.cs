using UnityEditor;
using UnityEngine;

using static DSS.CoreUtils.EditorUtilities.GUIUtilities;

namespace DSS.Logging
{

[CustomEditor(typeof(Logger))]
public class LoggerEditor : Editor
{
    SerializedProperty container;
    SerializedProperty logTextMeshPrefab;
    SerializedProperty warningTextMeshPrefab;
    SerializedProperty errorTextMeshPrefab;

    private string text;

    void OnEnable()
    {
        container = serializedObject.FindProperty("container");
        logTextMeshPrefab = serializedObject.FindProperty("logTextMeshPrefab");
        warningTextMeshPrefab = serializedObject.FindProperty("warningTextMeshPrefab");
        errorTextMeshPrefab = serializedObject.FindProperty("errorTextMeshPrefab");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        Section(string.Empty, () =>
        {
            Title("Logger");
        });

        Section("Required References", () =>
        {
            EditorGUILayout.PropertyField(container);
        });

        Section("Required Prefabs", () =>
        {
            EditorGUILayout.PropertyField(logTextMeshPrefab, new GUIContent("Log Text"));
            EditorGUILayout.PropertyField(warningTextMeshPrefab, new GUIContent("Warning Text"));
            EditorGUILayout.PropertyField(errorTextMeshPrefab, new GUIContent("Error Text"));
        });

        if (Application.isPlaying)
        {
            Section("Runtime Testing", () =>
            {
                text = EditorGUILayout.TextField("Text", text);

                if (GUILayout.Button("Log"))
                {
                    Logger.Instance.Log(text);
                    text = "";
                }
                if (GUILayout.Button("Log Warning"))
                {
                    Logger.Instance.LogWarning(text);
                    text = "";
                }
                if (GUILayout.Button("Log Error"))
                {
                    Logger.Instance.LogError(text);
                    text = "";
                }
            });
        }

        serializedObject.ApplyModifiedProperties();
    }
}

}  // namespace DSS.Logging