using UnityEditor;
using UnityEditor.TerrainTools;
using UnityEngine;

[CustomEditor(typeof(LevelGenerator))]
public class GenerateLabirynthButton : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        LevelGenerator generator = (LevelGenerator)target;

        if (GUILayout.Button("Generate Labirynth"))
        {
            generator.GenerateLabirynth();
        }
    }
}
