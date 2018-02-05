using UnityEngine;
using System.Collections;

public class PlayerManager : MonoBehaviour {
	
	
	//GENERAL
	public Texture2D[] blockTex;
	public int blockChoosen;
	public int totalBlocks = 3;
	public GameObject spawn;
	private bool menu;
	
	//DAMAGE
	private float weaponDamage = 1;
	private float range = 6.0f;
	public GameObject mycamera;
	
	//BLOCK-DESTRUCT
	public GameObject[] blocks;
	private Vector3 blockTemp;
	private Vector3 blockCreateTemp;
	private Vector3 blockNormalTemp;
	private Vector3 ppTemp;
	private Vector3 allTemp;
	private Vector3 finalTemp;
	
	void Start () {
		transform.position = spawn.transform.position;
		Screen.lockCursor = true;
	}
	void Update () {
		Die();
		ButtonsPressed();
		Shoot1();
	}
	void ButtonsPressed () {
		if(Input.GetKeyDown(KeyCode.R) && menu == false) {
			Spawn();
		}
		if(menu == false && Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)) {
			Screen.lockCursor = true;
		}
		if(Input.GetKeyDown(KeyCode.Q) && menu == false) {
			if(blockChoosen > 0) {
				blockChoosen -= 1;
			} else {
				blockChoosen = totalBlocks - 1;
			}
		}
		if(Input.GetKeyDown(KeyCode.E) && menu == false) {
			if(blockChoosen < (totalBlocks - 1)) {
				blockChoosen += 1;
			} else {
				blockChoosen = 0;
			}
		}
	}
	void Shoot1 () {
	    RaycastHit hit = new RaycastHit();
	    Ray ray = new Ray();        
	    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	
	    if (Input.GetMouseButtonDown(1) && menu == false) {
	        if (Physics.Raycast (ray, out hit)) {
	            if (hit.collider.gameObject.tag == "Block_1" || hit.collider.gameObject.tag == "Block_2" || hit.collider.gameObject.tag == "Block_3" && Vector3.Distance(hit.transform.position , transform.position) < 5 && Vector3.Distance(hit.transform.position , transform.position) > 1) {
					blockTemp = hit.collider.transform.position;
					ppTemp = new Vector3(0, 1, 0);
					blockNormalTemp = hit.normal.normalized;
					allTemp = blockTemp + blockNormalTemp + ppTemp;
					finalTemp = allTemp - new Vector3(0,1,0);
	                Instantiate(blocks[blockChoosen], finalTemp, Quaternion.identity);
	            }
	        }
	    }
		
		if (Input.GetMouseButtonDown(0) && menu == false) {
	        if (Physics.Raycast (ray, out hit)) {
	            if (hit.collider.gameObject.tag == "Block_1" || hit.collider.gameObject.tag == "Block_2" || hit.collider.gameObject.tag == "Block_3" && Vector3.Distance(hit.transform.position , transform.position) < 5 && Vector3.Distance(hit.transform.position , transform.position) > 0) {
					Destroy(hit.collider.gameObject);
	            }
	        }
	    }
	}
	void Spawn() {
		transform.position = spawn.transform.position;
	}
	void Die() {
		if(transform.position.y <= -16.0f) {
			Spawn();
		}
	}
	void MenuOn() {
		menu = true;
	}
	void MenuOff() {
		menu = false;
	}
	void OnGUI() {
		GUI.DrawTexture(new Rect(5, 5, 64, 64), blockTex[blockChoosen], ScaleMode.ScaleToFit, true, 0.0F);
	}
}