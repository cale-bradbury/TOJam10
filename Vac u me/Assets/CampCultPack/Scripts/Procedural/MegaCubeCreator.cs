using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MegaCubeCreator : MonoBehaviour {

	public GameObject prefab;
	public int size = 64;

	public int rooms = 10;
	public int roomMinSize = 5;
	public int roomMaxSize = 20;
	public int roomBorder = 2;
	public int tunnels = 40;
	public int tunnelSize = 2;

	private int[,,] maze;
	private GameObject holder;

	Mesh mesh;
	List<Vector3>verts;

	// Use this for initialization
	void Start () {
		GenerateMaze();
		//GenerateMesh();
		mesh = GenerateMeshUtils.ArrayToMesh(maze);
		GetComponent<MeshFilter>().mesh = mesh;
		GetComponent<MeshCollider>().sharedMesh = mesh;
	}

	void Update(){
		if(Input.GetKey(KeyCode.R)){
			Start();
		}
	}
	/*
	void GenerateMesh(){
		holder = new GameObject();
		mesh = new Mesh();
		verts = new List<Vector3>();
		WallScript[,,] wall = new WallScript[size,size,size];
		for(int i = 0; i<maze.GetLength(0);i++){
			for(int j = 0; j<maze.GetLength(1);j++){
				for(int k = 0; k<maze.GetLength(2);k++){
					if(maze[i,j,k]==1){
						GameObject g = (GameObject) Instantiate(prefab);
						g.transform.parent = holder.transform;
						g.transform.localPosition = new Vector3(i,j,k);
						WallScript w = (WallScript)g.GetComponent<WallScript>();
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
							if(side!=null){
								AddWall(new Vector3(i-.5f,j-.5f,k+.5f)
								        ,new Vector3(i+side.x-.5f,j-.5f,k+.5f)
								        ,new Vector3(i-.5f,j+side.y-.5f,k+.5f)
								        ,new Vector3(i+side.x-.5f,j+side.y-.5f,k+.5f));
							}
						}
						if(wall[i,j,k].needBack){
							Vector2 side = wall[i,j,k].GetBackWall();
							if(side!=null){
								AddWall(new Vector3(i-.5f,j-.5f,k-.5f)
								        ,new Vector3(i-.5f,j+side.y-.5f,k-.5f)
								        ,new Vector3(i+side.x-.5f,j-.5f,k-.5f)
								        ,new Vector3(i+side.x-.5f,j+side.y-.5f,k-.5f));
							}
						}
						
						if(wall[i,j,k].needRight){
							Vector2 side = wall[i,j,k].GetRightWall();
							if(side!=null){
								AddWall(new Vector3(i+.5f,j-.5f,k-.5f)
								        ,new Vector3(i+.5f,j+side.y-.5f,k-.5f)
								    ,new Vector3(i+.5f,j-.5f,k+side.x-.5f)
								        ,new Vector3(i+.5f,j+side.y-.5f,k+side.x-.5f));
							}
						}
						
						if(wall[i,j,k].needLeft){
							Vector2 side = wall[i,j,k].GetLeftWall();
							if(side!=null){
								AddWall(new Vector3(i-.5f,j-.5f,k-.5f)
								        ,new Vector3(i-.5f,j-.5f,k+side.x-.5f)
								        ,new Vector3(i-.5f,j+side.y-.5f,k-.5f)
								        ,new Vector3(i-.5f,j+side.y-.5f,k+side.x-.5f));
							}
						}
						
						if(wall[i,j,k].needUp){
							Vector2 side = wall[i,j,k].GetUpWall();
							if(side!=null){
								AddWall(new Vector3(i-.5f,j-.5f,k-.5f)
								          ,new Vector3(i-.5f+side.y,j-.5f,k-.5f)
								          ,new Vector3(i-.5f,j-.5f,k+side.x-.5f)
							        ,new Vector3(i-.5f+side.y,j-.5f,k+side.x-.5f));
							}
						}
						if(wall[i,j,k].needDown){
							Vector2 side = wall[i,j,k].GetDownWall();
							if(side!=null){
								AddWall(new Vector3(i-.5f,j+.5f,k-.5f)
								    ,new Vector3(i-.5f,j+.5f,k+side.x-.5f)
								        ,new Vector3(i-.5f+side.y,j+.5f,k-.5f)
								        ,new Vector3(i-.5f+side.y,j+.5f,k+side.x-.5f));
							}
						}
					}
				}
			}
		}

		int[] tris = new int[Mathf.FloorToInt(verts.Count*1.5f)];
		int t = 0;
		Vector2[] uv = new Vector2[verts.Count];
		for(int i = 0; i<verts.Count;i+=4){
			tris[t] = i;
			tris[t+1] = i+1;
			tris[t+2] = i+2;
			tris[t+3] = i+1;
			tris[t+4] = i+3;
			tris[t+5] = i+2;
			t+=6;
			uv[i] = Vector2.zero;
			uv[i+1] = Vector2.right;
			uv[i+2] = Vector2.up;
			uv[i+3] = Vector2.one;
		}
		Vector3[] v = new Vector3[verts.Count];
		verts.CopyTo(v);
		mesh.vertices = v;
		mesh.triangles = tris;
		mesh.uv = uv;
		mesh.RecalculateNormals();
		//mesh.Optimize();
		GetComponent<MeshFilter>().mesh = mesh;
		GetComponent<MeshCollider>().sharedMesh = mesh;
		Destroy(holder);
		wall = null;
	}
	*/
	void DebugWall(Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4){
		Debug.DrawLine(v1,v2,new Color(1,1,1),100f);
		Debug.DrawLine(v2,v3,new Color(1,1,1),100f);
		Debug.DrawLine(v3,v4,new Color(1,1,1),100f);
		Debug.DrawLine(v4,v1,new Color(1,1,1),100f);
		AddWall(v1,v2,v3,v4);
	}

	void AddWall(Vector3 v1, Vector3 v2, Vector3 v3, Vector3 v4){
		verts.Add(v1);
		verts.Add(v2);
		verts.Add(v3);
		verts.Add(v4);
	}

	void GenerateMaze(){
		maze = ArrayUtils.Create3D(1,size,size,size);
		for(int i = 0; i<rooms;i++){
			int[,,] room = CreateRoom();
			maze = ArrayUtils.Merge3D(maze,room,
			                          Random.Range(0,size-room.GetLength(0)+1),
			                          Random.Range(0,size-room.GetLength(1)+1),
			                          Random.Range(0,size-room.GetLength(2)+1));
		}
		for(int i = 0; i<tunnels;i++){
			AddHall();
		}
	}

	void AddHall(){
		Vector3 p = new Vector3(Random.Range(0,size),Random.Range(0,size),Random.Range(0,size));
		if(maze[(int)p.x,(int)p.y,(int)p.z]==1){
			AddHall();
			return;
		}
		Vector3 start = p;
		int dir = Random.Range(0,5);
		Vector3 add;
		if(dir==0)add = Vector3.forward;
		else if(dir==1)add = Vector3.back;
		else if(dir==2)add = Vector3.left;
		else if(dir==3)add = Vector3.right;
		else if(dir==4)add = Vector3.up;
		else add = Vector3.down;

		bool hitWall = false;
		bool safe = false;
		while(p.x>=0&&p.y>=0&&p.z>=0&&p.x<size&&p.y<size&&p.z<size){
			if(!hitWall && maze[(int)p.x,(int)p.y,(int)p.z]==1)
				hitWall = true;
			else if(hitWall && maze[(int)p.x,(int)p.y,(int)p.z]==0){
				safe = true;
				break;
			}
			p+=add;
		}
		p-=add;
		//if(!safe)return;
		if(dir==0||dir==1){
			ArrayUtils.Merge3D(maze,
			                   ArrayUtils.Create3D(0,tunnelSize,tunnelSize,(int)Mathf.Abs(p.z-start.z)+1),
			                   (int)Mathf.Min(start.x,size-tunnelSize),
			                   (int)Mathf.Min(start.y,size-tunnelSize),
			                   (int)Mathf.Min(p.z,start.z));
		}else if(dir==2||dir==3){
			ArrayUtils.Merge3D(maze,
			                   ArrayUtils.Create3D(0,(int)Mathf.Abs(p.x-start.x)+1,tunnelSize, tunnelSize),
			                   (int)Mathf.Min(p.x,start.x),
			                   (int)Mathf.Min(start.y,size-tunnelSize),
			                   (int)Mathf.Min(start.z,size-tunnelSize));
		}else{
			ArrayUtils.Merge3D(maze,
			                   ArrayUtils.Create3D(0,tunnelSize,(int)Mathf.Abs(p.y-start.y)+1, tunnelSize),
			                   (int)Mathf.Min(start.x,size-tunnelSize),
			                   (int)Mathf.Min(p.y,start.y),
			                   (int)Mathf.Min(start.z,size-tunnelSize));
		}
	}

	int[,,] CreateRoom(){
		int w = Random.Range(roomMinSize,roomMaxSize);
		int d = Random.Range(roomMinSize,roomMaxSize);
		int h = Random.Range(roomMinSize,roomMaxSize);
		int[,,] r = ArrayUtils.Create3D(1,w + roomBorder*2,h+roomBorder*2,d+roomBorder*2);
		return ArrayUtils.Merge3D(r,ArrayUtils.Create3D(0,w,h,d), roomBorder,roomBorder,roomBorder);
	}
}
