using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Skill))]
public class MySkillEditor : Editor
{

    // SerializedProperty 선언
    private SerializedProperty data;
    private SerializedProperty description;
    private SerializedProperty stars;
    private SerializedProperty count;
    private SerializedProperty isSustainChanneling;
    private SerializedProperty startTime;
    private SerializedProperty endTime;
    private SerializedProperty coolTime;
    private SerializedProperty duration;
    private SerializedProperty SkillObj;
    private SerializedProperty BuffStatRateList;
    private SerializedProperty Motion;
    private void OnEnable()
    {
        // SerializedObject에서 SerializedProperty를 가져옴
        data = serializedObject.FindProperty("Data");
        description = serializedObject.FindProperty("Description");
        stars = serializedObject.FindProperty("Stars");
        count = serializedObject.FindProperty("Count");
        
        isSustainChanneling = serializedObject.FindProperty("IsSustainChanneling");
        startTime = serializedObject.FindProperty("StartTime");
        endTime = serializedObject.FindProperty("EndTime");
        coolTime = serializedObject.FindProperty("coolTime");
        duration = serializedObject.FindProperty("duration");
        SkillObj = serializedObject.FindProperty("SkillObj");
        BuffStatRateList = serializedObject.FindProperty("BuffStatRateList");
        Motion = serializedObject.FindProperty("Motion");
    }

    public override void OnInspectorGUI()
    {
        // SerializedObject 업데이트
        serializedObject.Update();

        // 기본 인스펙터를 수동으로 그리기
        EditorGUILayout.PropertyField(data);
        EditorGUILayout.PropertyField(description);
        EditorGUILayout.PropertyField(stars);
        EditorGUILayout.PropertyField(count);
        EditorGUILayout.PropertyField(coolTime);
        EditorGUILayout.PropertyField(duration);
        EditorGUILayout.PropertyField(SkillObj);
        EditorGUILayout.PropertyField(BuffStatRateList);
        EditorGUILayout.PropertyField(Motion);

        // Custom GUI drawing
        GUILayout.BeginVertical("box");
        EditorGUILayout.PropertyField(isSustainChanneling, new GUIContent("Set Anim Time On Channeling"));
        GUILayout.EndVertical();

        // Exclude other fields from default drawing
        if (isSustainChanneling.boolValue)
        {
            EditorGUI.indentLevel++;
            EditorGUILayout.PropertyField(startTime, new GUIContent("Animation Start Time On Sustain"));
            EditorGUILayout.PropertyField(endTime, new GUIContent("Animation End Time On Sustain"));
            EditorGUI.indentLevel--;
        }

        // Apply the modified properties to the serializedObject
        serializedObject.ApplyModifiedProperties();
    }
}