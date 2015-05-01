using UnityEngine;
using System.Collections;

public class WallScript {

	WallScript up;
	WallScript down;
	WallScript left;
	WallScript right;
	WallScript front;
	WallScript back;

	[HideInInspector]
	public bool needUp,needDown,needLeft,needRight,needBack,needFront = false;

	public void SetNeighbors( WallScript left, WallScript up,WallScript back){
		this.back = back;
		if(back!=null)back.front = this;
		this.left =left;
		if(left!=null)left.right = this;
		this.up = up;
		if(up!=null)up.down = this;
	}

	public void GetNeeds(){
		if(back==null)needBack = true;
		if(front==null)needFront = true;
		if(left==null)needLeft = true;
		if(right==null)needRight = true;
		if(up==null)needUp = true;
		if(down==null)needDown = true;
	}
	
	public Vector2 GetFrontWall(){
		int w = 1;
		int h = 1;
		WallScript r = right;
		while(r!=null&&r.needFront){
			w++;
			r.needFront = false;
			r = r.right;
		}
		WallScript d = down;
		while(d!=null&&d.needFront){
			r = d;
			bool rowSafe = true;
			for(int i = 0; i<w;i++){
				if(r==null||!r.needFront){
					rowSafe=false;
					break;
				}
				r = r.right;
			}
			if(rowSafe){
				h++;
				r = d;
				for(int i = 0; i<w;i++){
					r.needFront = false;
					r = r.right;
				}
				d = d.down;
			}else{
				break;
			}
		}
		return new Vector2(w,h);
	}
	
	public Vector2 GetBackWall(){
		int w = 1;
		int h = 1;
		WallScript r = right;
		while(r!=null&&r.needBack){
			w++;
			r.needBack = false;
			r = r.right;
		}
		WallScript d = down;
		while(d!=null&&d.needBack){
			r = d;
			bool rowSafe = true;
			for(int i = 0; i<w;i++){
				if(r==null||!r.needBack){
					rowSafe=false;
					break;
				}
				r = r.right;
			}
			if(rowSafe){
				h++;
				r = d;
				for(int i = 0; i<w;i++){
					r.needBack = false;
					r = r.right;
				}
				d = d.down;
			}else{
				break;
			}
		}
		return new Vector2(w,h);
	}

	public Vector2 GetRightWall(){
		int w = 1;
		int h = 1;
		WallScript r = front;
		while(r!=null&&r.needRight){
			w++;
			r.needRight = false;
			r = r.front;
		}
		WallScript d = down;
		while(d!=null&&d.needRight){
			r = d;
			bool rowSafe = true;
			for(int i = 0; i<w;i++){
				if(r==null||!r.needRight){
					rowSafe=false;
					break;
				}
				r = r.front;
			}
			if(rowSafe){
				h++;
				r = d;
				for(int i = 0; i<w;i++){
					r.needRight = false;
					r = r.front;
				}
				d = d.down;
			}else{
				break;
			}
		}
		return new Vector2(w,h);
	}
	
	public Vector2 GetLeftWall(){
		int w = 1;
		int h = 1;
		WallScript r = front;
		while(r!=null&&r.needLeft){
			w++;
			r.needLeft = false;
			r = r.front;
		}
		WallScript d = down;
		while(d!=null&&d.needLeft){
			r = d;
			bool rowSafe = true;
			for(int i = 0; i<w;i++){
				if(r==null||!r.needLeft){
					rowSafe=false;
					break;
				}
				r = r.front;
			}
			if(rowSafe){
				h++;
				r = d;
				for(int i = 0; i<w;i++){
					r.needLeft = false;
					r = r.front;
				}
				d = d.down;
			}else{
				break;
			}
		}
		return new Vector2(w,h);
	}
	
	public Vector2 GetUpWall(){
		int w = 1;
		int h = 1;
		WallScript r = front;
		while(r!=null&&r.needUp){
			w++;
			r.needUp = false;
			r = r.front;
		}
		WallScript d = right;
		while(d!=null&&d.needUp){
			r = d;
			bool rowSafe = true;
			for(int i = 0; i<w;i++){
				if(r==null||!r.needUp){
					rowSafe=false;
					break;
				}
				r = r.front;
			}
			if(rowSafe){
				h++;
				r = d;
				for(int i = 0; i<w;i++){
					r.needUp = false;
					r = r.front;
				}
				d = d.right;
			}else{
				break;
			}
		}
		return new Vector2(w,h);
	}
	
	public Vector2 GetDownWall(){
		int w = 1;
		int h = 1;
		WallScript r = front;
		while(r!=null&&r.needDown){
			w++;
			r.needDown = false;
			r = r.front;
		}
		WallScript d = right;
		while(d!=null&&d.needDown){
			r = d;
			bool rowSafe = true;
			for(int i = 0; i<w;i++){
				if(r==null||!r.needDown){
					rowSafe=false;
					break;
				}
				r = r.front;
			}
			if(rowSafe){
				h++;
				r = d;
				for(int i = 0; i<w;i++){
					r.needDown = false;
					r = r.front;
				}
				d = d.right;
			}else{
				break;
			}
		}
		return new Vector2(w,h);
	}
}
