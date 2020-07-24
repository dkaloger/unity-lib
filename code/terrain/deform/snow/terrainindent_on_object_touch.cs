using UnityEngine;
using System.Collections;
[RequireComponent(typeof(Terrain))]
public class terrainindent_on_object_touch : MonoBehaviour
{
    // IMPORTANT terrain transform must be x0 y0 z0 (could be easyly made to work for other coordinates)

    public float fix = 1.95f;
    public float str = 0.01f;
  //  public int p1;
   // public int p2;
       Terrain terrain;
    TerrainData tData;
    public Transform player;
    int xRes;
    int yRes;
    public Vector3Int playerpos_refined;
    public Vector3Int playerpos_refined_prevframe;
    public float[,] heights;
    public float[,] start_heights;
    float[] heightsvis;
    public bool firstboot;
    public Vector3Int offset;

    void Start()
    {
        terrain = transform.GetComponent<Terrain>();
        tData = terrain.terrainData;

        xRes = tData.heightmapResolution;
        yRes = tData.heightmapResolution;

        randomizePoints(0.1f);

    }

  //  void OnGUI()
  //  {
     //   if (GUI.Button(new Rect(10, 10, 100, 25), "Wrinkle"))
      //  {
      //      randomizePoints(0.1f);
     //   }

     //   if (GUI.Button(new Rect(10, 40, 100, 25), "Reset"))
     //   {
      //      resetPoints();
     //   }
  //  }
    void OnApplicationQuit()
    {
        resetPoints();
    }
    void randomizePoints(float strength)
    {
        if(firstboot == true)
        {
            start_heights = tData.GetHeights(0, 0, xRes, yRes);
            heights = tData.GetHeights(0, 0, xRes, yRes);

            for (int y = 0; y < yRes; y++)
            {
                for (int x = 0; x < xRes; x++)
                {
                    heights[x, y] = heights[x, y] + str;
                    print("L64");
                }
            }
            start_heights = heights;
            tData.SetHeightsDelayLOD(0, 0, heights);
        }
    //    if (firstboot == false)
     //   {
        start_heights = tData.GetHeights(0, 0, xRes, yRes);
            heights = tData.GetHeights(0, 0, xRes, yRes);

         //   for (int y = 0; y < yRes; y++)
     //       {
           //     for (int x = 0; x < xRes; x++)
           //     {
           //         heights[x, y] = heights[x, y] ;
                    print("L80");
           //     }
   //  }
            start_heights = heights;
            tData.SetHeights(0, 0, heights);
            print("L85");
    //    }
    }

    void resetPoints()
    {
        var heights = tData.GetHeights(0, 0, xRes, yRes); ;
        for (int y = 0; y < yRes; y++)
        {
            for (int x = 0; x < xRes; x++)
            {
                heights[x, y] = 0;
            }
        }

        tData.SetHeightsDelayLOD(0, 0, start_heights);
    }

    // Update is called once per frame
    void Update()
    {
        print("L106");
   if (player.position.z < yRes  && player.position.z > transform.position.z && player.position.x  < xRes && player.position.x  > transform.position.x)
       {

        playerpos_refined.x = Mathf.RoundToInt((player.position.z - transform.position.z) / fix);
    playerpos_refined.y = Mathf.RoundToInt((player.position.x -transform.position.x) / fix);
        //    playerpos_refined.x = Mathf.RoundToInt(player.position.z + offset.z);
        //   playerpos_refined.y = Mathf.RoundToInt(player.position.x + offset.x);
        //  playerpos_refined.x = Mathf.RoundToInt(playerpos_refined.x / fix);
        //    playerpos_refined.z = Mathf.RoundToInt(playerpos_refined.z / fix);
       }

        //  heights = tData.GetHeights(0, 0, xRes, yRes);
        //  heightsvis = heights;

        heights[playerpos_refined.x, playerpos_refined.y] = start_heights[playerpos_refined.x, playerpos_refined.y]-str;
    
        if (playerpos_refined_prevframe != playerpos_refined)
        {
            
            tData.SetHeightsDelayLOD(0, 0, heights);

            print("update terrain");
        }
        //   tData.SetHeights(0, 0, heights);
        playerpos_refined_prevframe = playerpos_refined;
    }
}
