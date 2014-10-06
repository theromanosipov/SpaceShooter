using UnityEngine;
using System.Collections;
using System;

public class DockGrid : MonoBehaviour {

	private int[,] grid = new int[8,8];
	private int selfX;
	private int selfY;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				grid[i,j] = 0;
			}
		}
	}

	void SetSelf (int playerNum){
		grid[0,0] = playerNum;
		selfX = 0;
		selfY = 0;
	}

	void DockTo (int x, int y){
		if(x == -1){

		}
	}

	int[,] ShiftedGrid (int x, int y){
		if(x == 0 && y == 0) return grid;
		int[,] newGrid = new int[8, 8];

		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				newGrid[i,j] = 0;
			}
		}

		for (int i = Math.Max(0, x); i < Math.Min(8, 8 + x); i++) {
			for (int j = Math.Max (0, y); j < Math.Min (8, 8 + y); j++) {
				newGrid[i, j] = grid[i - x, j - y];
			}
		}
		return newGrid;
	}

	// Update is called once per frame
	void Update () {
	
	}
}

public class Grid{
	public int[,] cells;
	public int width;
	public int height;

	public Grid(int x, int y){
		width = x;
		height = y;
		cells = new int[width, height];
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				cells[i,j] = -1;
			}
		}
	}

	int Get(int x, int y){
		if(x < 0 || x >= width || y < 0 || y >= height) return -1;
		else return cells[x,y];
	}

	bool SingleDock(int x, int y){
		if (Get (x, y) != -1) return false;
		if (Get(x-1,y) == -1 && Get(x,y-1) == -1 && Get(x+1,y) == -1 && Get(x,y+1) == -1) return false;
		return true;
	}

	void Merge(Grid from, int ofX, int ofY){
		for (int i = 0; i < width; i++) {
			for (int j = 0; j < height; j++) {
				cells[i,j] = from.Get(i-ofX, j-ofY);
			}
		}

	}

	bool GridDock(Grid G, int ofX, int ofY){
		for (int i = 0; i < G.width; i++) {
			for (int j = 0; j < G.height; j++) {
				if(G.cells[i,j] != -1){
					if(Get(i + ofX, j + ofY) != -1) return false;
				}
			}
		}
	}

//	public Grid CombineDock(Grid other){
//		Grid dock = new Grid (width + other.width + 1, height + other.height + 1);
//
//		for (int i = 0; i < width; i++) {
//			for (int j = 0; j < height; j++) {
//				if(cells[i, j] > 0){
//
//
//
//				}
//			}
//		}
//	}

}
