using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GenerateMeshUtils {

	static List<Vector3> verts;
	static List<int> tris;
	static List<Vector2> uv;

	public static Mesh ArrayToMesh(int[,,] a){
		Mesh mesh = new Mesh();
		verts = new List<Vector3>();		
		tris = new List<int>();
		uv = new List<Vector2>();
		
		WallScript[,,] wall = new WallScript[a.GetLength(0),a.GetLength(1),a.GetLength(2)];
		for(int i = 0; i<a.GetLength(0);i++){
			for(int j = 0; j<a.GetLength(1);j++){
				for(int k = 0; k<a.GetLength(2);k++){
					if(a[i,j,k]==1){
						WallScript w = new WallScript();
						wall[i,j,k] = w;
						w.SetNeighbors(
							i==0?null:wall[i-1,j,k],
							j==0?null:wall[i,j-1,k],
							k==0?null:wall[i,j,k-1]);
					}else{
						wall[i,j,k] = null;
					}
				}
			}
		}
		
		for(int i = 0; i<wall.GetLength(0);i++){
			for(int j = 0; j<wall.GetLength(1);j++){
				for(int k = 0; k<wall.GetLength(2);k++){
					if(wall[i,j,k]!=null){
						wall[i,j,k].GetNeeds();
						
					}
				}
			}
		}
		
		for(int i = 0; i<wall.GetLength(0);i++){
			for(int j = 0; j<wall.GetLength(1);j++){
				for(int k = 0; k<wall.GetLength(2);k++){
					if(wall[i,j,k]!=null){
						if(wall[i,j,k].needFront){
							Vector2 side = wall[i,j,k].GetFrontWall();
							if(side!=Vector2.zero){
								AddWall(new Vector3(i-.5f,j-.5f,k+.5f)
								        ,new Vector3(i+side.x-.5f,j-.5f,k+.5f)
								        ,new Vector3(i-.5f,j+side.y-.5f,k+.5f)
								        ,new Vector3(i+side.x-.5f,j+side.y-.5f,k+.5f),true);
							}
						}
						if(wall[i,j,k].needBack){
							Vector2 side = wall[i,j,k].GetBackWall();
							if(side!=Vector2.zero){
								AddWall(new Vector3(i-.5f,j-.5f,k-.5f)
								        ,new Vector3(i-.5f,j+side.y-.5f,k-.5f)
								        ,new Vector3(i+side.x-.5f,j-.5f,k-.5f)
								        ,new Vector3(i+side.x-.5f,j+side.y-.5f,k-.5f));
							}
						}
						
						if(wall[i,j,k].needRight){
							Vector2 side = wall[i,j,k].GetRightWall();
							if(side!=Vector2.zero){
								AddWall(new Vector3(i+.5f,j-.5f,k-.5f)
								        ,new Vector3(i+.5f,j+side.y-.5f,k-.5f)
								        ,new Vector3(i+.5f,j-.5f,k+side.x-.5f)
								        ,new Vector3(i+.5f,j+side.y-.5f,k+side.x-.5f));
								
							}
						}
						
						if(wall[i,j,k].needLeft){
							Vector2 side = wall[i,j,k].GetLeftWall();
							if(side!=Vector2.zero){
								AddWall(new Vector3(i-.5f,j-.5f,k-.5f)
								        ,new Vector3(i-.5f,j-.5f,k+side.x-.5f)
								        ,new Vector3(i-.5f,j+side.y-.5f,k-.5f)
								        ,new Vector3(i-.5f,j+side.y-.5f,k+side.x-.5f),true);
								
							}
						}
						
						if(wall[i,j,k].needUp){
							Vector2 side = wall[i,j,k].GetUpWall();
							if(side!=Vector2.zero){
								AddWall(new Vector3(i-.5f,j-.5f,k-.5f)
								        ,new Vector3(i-.5f+side.y,j-.5f,k-.5f)
								        ,new Vector3(i-.5f,j-.5f,k+side.x-.5f)
								        ,new Vector3(i-.5f+side.y,j-.5f,k+side.x-.5f));
							}
						}
						if(wall[i,j,k].needDown){
							Vector2 side = wall[i,j,k].GetDownWall();
							if(side!=Vector2.zero){
								AddWall(new Vector3(i-.5f,j+.5f,k-.5f)
								        ,new Vector3(i-.5f,j+.5f,k+side.x-.5f)
								        ,new Vector3(i-.5f+side.y,j+.5f,k-.5f)
								        ,new Vector3(i-.5f+side.y,j+.5f,k+side.x-.5f),true);
							}
						}
					}
				}
			}
		}
		
		
		Vector3[] v = new Vector3[verts.Count];
		Vector2[] u = new Vector2[uv.Count];
		int[] t = new int[tris.Count];
		verts.CopyTo(v);
		uv.CopyTo(u);
		tris.CopyTo(t);
		mesh.vertices = v;
		mesh.triangles = t;
		mesh.uv = u;
		mesh.RecalculateNormals();
		//mesh.Optimize();
		wall = null;
		return mesh;
	}
	
	static void AddWall(Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4, bool flip = false){
		int i1 = AddVert(v1);
		int i2 = AddVert(v2);
		int i3 = AddVert(v3);
		int i4 = AddVert(v4);
		tris.Add(i1);
		tris.Add(i2);
		tris.Add(i3);
		tris.Add(i2);
		tris.Add(i4);
		tris.Add(i3);
		
		Vector2 u1,u2,u3,u4;
		
		if(v1.x==v4.x){
			u1 = new Vector2(v1.z,v1.y);
			u2 = new Vector2(v1.z,v4.y);
			u3 = new Vector2(v4.z,v1.y);
			u4 = new Vector2(v4.z,v4.y);
		}else if(v1.z==v4.z){
			u1 = new Vector2(v1.x,v1.y);
			u2 = new Vector2(v1.x,v4.y);
			u3 = new Vector2(v4.x,v1.y);
			u4 = new Vector2(v4.x,v4.y);
		}else{
			u1 = new Vector2(v1.z,v1.x);
			u2 = new Vector2(v1.z,v4.x);
			u3 = new Vector2(v4.z,v1.x);
			u4 = new Vector2(v4.z,v4.x);
		}
		uv.Add(u1);
		if(!flip){
			uv.Add(u2);
			uv.Add(u3);
		}else{
			uv.Add(u3);
			uv.Add(u2);
		}
		uv.Add(u4);
	}
	
	static int AddVert(Vector3 v){
		verts.Add(v);
		return verts.Count-1;
	}
}
