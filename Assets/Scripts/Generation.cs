using UnityEngine;
using System.Collections;
using System;
using System.Text;
using System.IO;

public class Generation : MonoBehaviour {
	//GENERATE WORLD
	public GameObject[] blocks;
	public GameObject player;
	private int level_down = 2;
	private bool genDown = false;
	
	//LOAD WORLD
	private string data_chunk;
	private string[] data_block;
	private string[] data_co;
	private int[] data_co_int = {0,0,0,0};
	
	//SAVE WORLD
	private string save_data_chunk;
	private GameObject[] cubes_0;
	private GameObject[] cubes_1;
	private GameObject[] cubes_2;
	private GameObject[] cubes_3;
	private string temp_pos;
	private string temp_co;
	private string temp_co_f;

	//PLAYER
	public GameObject spawn;
	
	
	void Start () {
		GenerateTerrain();
		player = GameObject.FindGameObjectWithTag("Player");
		data_chunk = "";
	}
	void Update () {
		if(genDown == true) {
			DrawChunkDown();
		}
		
		if(Input.GetKeyDown(KeyCode.G)) {
			genDown = !genDown;
		}
		
	}
	
	
	void GenerateTerrain() {
		int i1;
		int i2;
		int i3;
		for(i2=0;i2<=16;i2++) {
			for(i3=0;i3<=16;i3++) {
				Instantiate(blocks[1], new Vector3(i2, -1, i3), Quaternion.identity);
			}
		}
	}
	void DrawChunkDown() {
		if(level_down <= 16) {
			if(player.transform.position.y <= -(level_down - 2)) {
				int i1;
				int i2;
				for(i1=0;i1<=16;i1++) {
					for(i2=0;i2<=16;i2++) {
						Instantiate(blocks[1], new Vector3(i1, -level_down, i2), Quaternion.identity);
					}
				}
				level_down += 1;
			}
		}
	}
}