using UnityEngine;
using System.Collections;
using UnityEditor;

[ExecuteInEditMode]
public class GenerateHeightmapMesh : EditorWindow {
	
	
	public Texture2D map;
	public float unitSize = 3;
	public int maxHeight = 32;
	public Material material;
	public string path = "Assets/";
	public string name = "heightmap";


	
	[MenuItem("Generate/Height Map")]
	static void Init () 
	{
		GenerateHeightmapMesh window = (GenerateHeightmapMesh)EditorWindow.GetWindow (typeof (GenerateHeightmapMesh));
	}
	
	void Gen(){
		int[,,] a = ArrayUtils.Create3D(0,map.width,maxHeight+1,map.height);
		for(int i = 0; i< map.width;i++){
			for( int j = 0; j< map.height;j++){
				int h = Mathf.FloorToInt(map.GetPixel(i,j).r*maxHeight*.99f);
				for(int k = 0; k<h;k++){
					a[i,k,j] = 1;
				}
			}
		}
		Mesh m = GenerateMeshUtils.ArrayToMesh(a);
		GameObject g = new GameObject(name);
		MeshFilter mf = g.AddComponent<MeshFilter>();
		mf.mesh = m;
		MeshRenderer mr = g.AddComponent<MeshRenderer>();
		mr.material = material;
		AssetDatabase.CreateAsset(m,path+""+ name + ".asset");
		PrefabUtility.CreatePrefab(path+""+name+".prefab",g);
	}
	
	void OnGUI()
	{
		map = EditorGUILayout.ObjectField("height map", map,typeof(Texture2D), false) as Texture2D;
		unitSize = EditorGUILayout.FloatField("unit size", unitSize);
		maxHeight = EditorGUILayout.IntField("max height", maxHeight);
		material = EditorGUILayout.ObjectField("material",material, typeof(Material),false) as Material;
		path = EditorGUILayout.TextField("path",path);
		name = EditorGUILayout.TextField("name",name);
		if(GUILayout.Button("Generate"))
		{
			Gen();
		}
	}


}

