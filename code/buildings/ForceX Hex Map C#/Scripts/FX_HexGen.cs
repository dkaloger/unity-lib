/*
 * This script is responsible for generating the HEX mesh.
 * 
 * Input values: 
 * 		1. offset : Determines the amount of "Y" rotation the mesh will have during creation. 0 = Hex with flat top 30 = Hex with point top
 * 		2. scale : Determines the Hex size. 0.5f will make a Hex with a 1 unit width
 * */

using UnityEngine;
using System.Collections;

public class FX_HexGen : MonoBehaviour {
	public Material material;
public GameObject tile;
    public GameObject MakeHex (int offset, float scale ) {

		Mesh mesh = new Mesh();

		Vector3[] vertices = new Vector3[7];

		//Center
		vertices[0] = Vector3.zero;
		vertices[1] = GetVertexPos(0 + offset) * scale;
		vertices[2] = GetVertexPos(60 + offset) * scale;
		vertices[3] = GetVertexPos(120 + offset) * scale;
		vertices[4] =  GetVertexPos(180 + offset) * scale;
		vertices[5] = GetVertexPos(240 + offset) * scale;
		vertices[6] = GetVertexPos(300 + offset) * scale;

		//***********************************************************
		//										Build Triangles
		//***********************************************************
		int[] triangles = new int[18];
		
		//Top
		triangles[0] = 0;
		triangles[1] = 2; 
		triangles[2] = 1;
		
		//Bottom
		triangles[3] = 0; 
		triangles[4] = 3; 
		triangles[5] = 2;
		
		//Bottom Left
		triangles[6] = 0; 
		triangles[7] = 4; 
		triangles[8] = 3;
		
		//Bottom Right
		triangles[9] = 0; 
		triangles[10] = 5; 
		triangles[11] = 4;
		
		//Top Right
		triangles[12] = 0; 
		triangles[13] = 6; 
		triangles[14] = 5;
		
		//Top Left
		triangles[15] = 0; 
		triangles[16] = 1; 
		triangles[17] = 6;

		//***********************************************************
		//										Set UV's
		//***********************************************************
		Vector2[] uv = new Vector2[7];
		
		// Center
		uv[0] = new Vector2(.5f, .5f); 
		uv[1] = new Vector2(1f, .5f); // Top Left
		uv[2] = new Vector2(.75f, .935f); // Top Right
		uv[3] = new Vector2(.25f, 0.935f); // Bottom Right
		uv[4] = new Vector2(0, 0.5f); // Bottom Left
		uv[5] = new Vector2(.25f, .065f);  // Center Bottom Left
		uv[6] = new Vector2(.75f, .065f); // Bottom Left

		mesh.vertices = vertices;
		mesh.triangles = triangles;
		mesh.uv = uv;
		mesh.RecalculateNormals();
		
		GameObject o = new GameObject("New Hex");

		o.AddComponent<MeshRenderer>();
		o.AddComponent<MeshFilter>();
		o.GetComponent<MeshFilter>().mesh = mesh;
		mesh.RecalculateNormals();
		mesh.RecalculateBounds();

		o.AddComponent<MeshCollider>();

		o.GetComponent<Renderer>().material = material;

		o.AddComponent<FX_HexInfo>();

        return o;
	}

	Vector3 GetVertexPos(float angle){
		float rad = angle * Mathf.Deg2Rad;
		Vector3 newPos = new Vector3(Mathf.Cos(rad), 0, Mathf.Sin(rad));
		return newPos;
	}
}
