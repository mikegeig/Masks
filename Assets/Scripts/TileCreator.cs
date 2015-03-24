using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class TileCreator : MonoBehaviour {

	public GameObject obj;
	
	void Start () {

		for(int x = 0; x < 16; x++)
			for(int y = 0; y < 10; y++)
				Instantiate(obj, new Vector3(-7.5f + x, -4.5f + y, 0f), Quaternion.identity); 
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}