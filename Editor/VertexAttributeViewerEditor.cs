//=======================================================
//简介:方便观察选中模型对象的额顶点颜色（可视化）
//作者:GoHann
//创建时间:2022/10/12 2:26:45
//版本:v1.00
//=======================================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MeshFilter))]
public class VertexAttributeViewerEditor : Editor
{
    private Shader newShader;
    private MeshRenderer rend;
    private Shader oldShader;

    private const int buttonWidth = 100;
    private void OnEnable()
    {
        newShader = AssetDatabase.LoadAssetAtPath<Shader>("Assets/工具/wuhanLibrary/VertexAttributeViewer/VertexAttributeViewer.shader");
        GameObject go = Selection.activeGameObject;
        rend = go.GetComponent<MeshRenderer>();
        oldShader = rend.sharedMaterial.shader;

    }

    private void OnDisable()
    {
        rend.sharedMaterial.shader = oldShader;
    }
    private void OnSceneGUI()
    {
        Handles.BeginGUI();
        {
            EditorGUILayout.LabelField("顶点属性:");
            if (GUILayout.Button("Defualt", GUILayout.Width(buttonWidth)))
            {

                rend.sharedMaterial.shader = oldShader;
            }

            if (GUILayout.Button("PositionOS", GUILayout.Width(buttonWidth)))
            {
                rend.sharedMaterial.shader = newShader;
                rend.sharedMaterial.SetFloat("_ShowID", 0);
            }

            if (GUILayout.Button("PositionWS", GUILayout.Width(buttonWidth)))
            {
                rend.sharedMaterial.shader = newShader;
                rend.sharedMaterial.SetFloat("_ShowID", 1);

            }

            if (GUILayout.Button("NormalOS", GUILayout.Width(buttonWidth)))
            {
                rend.sharedMaterial.shader = newShader;
                rend.sharedMaterial.SetFloat("_ShowID", 2);

            }

            if (GUILayout.Button("NormalWS", GUILayout.Width(buttonWidth)))
            {
                rend.sharedMaterial.shader = newShader;
                rend.sharedMaterial.SetFloat("_ShowID", 3);

            }

            if (GUILayout.Button("Color", GUILayout.Width(buttonWidth)))
            {
                rend.sharedMaterial.shader = newShader;
                rend.sharedMaterial.SetFloat("_ShowID", 4);

            }

            if (GUILayout.Button("TangentWS", GUILayout.Width(buttonWidth)))
            {
                rend.sharedMaterial.shader = newShader;
                rend.sharedMaterial.SetFloat("_ShowID", 5);

            }
            if (GUILayout.Button("BiTangentWS", GUILayout.Width(buttonWidth)))
            {
                rend.sharedMaterial.shader = newShader;
                rend.sharedMaterial.SetFloat("_ShowID", 6);

            }

            EditorGUILayout.BeginHorizontal(GUILayout.Width(buttonWidth));
            {
                if (GUILayout.Button("UV1.x"))
                {
                    rend.sharedMaterial.shader = newShader;
                    rend.sharedMaterial.SetFloat("_ShowID", 7);

                }
                if (GUILayout.Button("UV1.y"))
                {
                    rend.sharedMaterial.shader = newShader;
                    rend.sharedMaterial.SetFloat("_ShowID", 8);

                }
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal(GUILayout.Width(buttonWidth));
            {
                if (GUILayout.Button("UV2.x"))
                {
                    rend.sharedMaterial.shader = newShader;
                    rend.sharedMaterial.SetFloat("_ShowID", 9);

                }
                if (GUILayout.Button("UV2.y"))
                {
                    rend.sharedMaterial.shader = newShader;
                    rend.sharedMaterial.SetFloat("_ShowID", 10);

                }
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal(GUILayout.Width(buttonWidth));
            {
                if (GUILayout.Button("UV3.x"))
                {
                    rend.sharedMaterial.shader = newShader;
                    rend.sharedMaterial.SetFloat("_ShowID", 11);

                }
                if (GUILayout.Button("UV3.y"))
                {
                    rend.sharedMaterial.shader = newShader;
                    rend.sharedMaterial.SetFloat("_ShowID", 12);

                }
            }
            EditorGUILayout.EndHorizontal();


        }
        Handles.EndGUI();

    }

}