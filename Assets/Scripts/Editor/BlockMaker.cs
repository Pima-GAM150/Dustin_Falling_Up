using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BlockMaker : EditorWindow
{
	#region Variables

	private int MaxScale;

	private bool Both;

	private string FolderName;

	#endregion

	#region Unity Functions

	private void OnGUI()
	{
		EditorGUILayout.BeginVertical();

			EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField("Max Scale");
				MaxScale = EditorGUILayout.IntSlider(MaxScale, 0, 10);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField("Both X and Y");
				Both = EditorGUILayout.Toggle(Both);
			EditorGUILayout.EndHorizontal();

			EditorGUILayout.BeginHorizontal();
				EditorGUILayout.LabelField("Folder Name");
				FolderName = EditorGUILayout.TextField(FolderName);
			EditorGUILayout.EndHorizontal();

		if (GUILayout.Button("Make Prefabs"))
			{
				MakeThemPrefabs();
			}
		EditorGUILayout.EndVertical();
		Repaint();
	}

	#endregion

	#region My Functions

	public static void InstantiateWindow()
	{
		GetWindow<BlockMaker>();
	}

	private void MakeThemPrefabs()
	{ 

		for (int i = 1; i <= MaxScale; i++) 
		{
			for (int j = 1; j <= MaxScale; j++) 
			{
				var newObj = new GameObject("Block " + i + "x" + j);

				newObj.AddComponent<MeshFilter>();

				newObj.AddComponent<MeshRenderer>();

				newObj.AddComponent<BoxCollider>();

				newObj.transform.localScale = new Vector3(i, j, 1);
				
				var localPath = "Assets/prefabs/" + FolderName + "/" + newObj.name + ".prefab";
				
				PrefabUtility.SaveAsPrefabAsset(newObj,localPath);
			}
		}
	}

	#endregion
}
