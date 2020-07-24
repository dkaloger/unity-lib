using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cut : MonoBehaviour
{
  public int ID;

    public ground g;

  public  Mesh mesh1;
  public  MeshCollider collider;
   public int j = 0;
    public Vector3[] blah_local;
    Vector3 truepos;
   public Vector3Int[] blahi_local ;
    int cp_local;

    public Vector3Int[] moves_local;
    public Vector3Int[] revmoves;
    public int completedmoves = 0;
    int i;
    int revc;


  public  bool is_hide;

   //new

   public int reset_count;
   public int[] reset_positions_of_local_blahi;

   int reset_positions_of_local_blahi_count;
 //public   Vector3 adjustment;


    void Start()
    {
        mesh1 = transform.GetComponent<MeshFilter>().mesh;

        blah_local = mesh1.vertices;
      blah_local[0].y = -100;
   blah_local[1].y = -100;
  blah_local[2].y = -100;
   blah_local[3].y = -100;
       blah_local[4].y = -100;
      blah_local[5].y = -100;
      blah_local[6].y = -100;
   blah_local[7].y = -100;
  blah_local[8].y = -100;
    blah_local[9].y = -100;
      blah_local[10].y = -100;
        mesh1.vertices = blah_local ;
    
      blahi_local =   new Vector3Int[999];
        moves_local = new Vector3Int[999];
        revmoves = new Vector3Int[999];
    
      reset_positions_of_local_blahi =   new int[999];
        collider = transform.GetComponent<MeshCollider>();

       
    }
 
    // Update is called once per frame
    void Update()
    {
      //// if (g.Id_target_x == ID && g.pc.cutenabled == true)
   ////     {
            print(ID + "id");
            cp_local = System.Array.IndexOf(blahi_local, g.player_position_global_relative);
            if (cp_local != -1 && cp_local != 121)
            {
//              Debug.Log (cp_local);
                blah_local[cp_local].y = -100;
                blahi_local[cp_local].y = -100;

                //// new 
reset_positions_of_local_blahi[reset_positions_of_local_blahi_count] = cp_local;
reset_positions_of_local_blahi_count++;

                //reset
                moves_local[completedmoves] = blahi_local[cp_local];
                moves_local[completedmoves].y = -100;


                g.Global_moves_Array[g.globalmoves] = g.player_position_global;
                 g.player_goto_accurate[g.globalmoves] = g.actual_player_pos;
                g.globalmoves++;

                completedmoves++;
           
             //   moves_local[completedmoves].y = -100;

      
    }
            ////    }
        //reset
Debug.Log(System.Array.IndexOf(blahi_local, g.Global_moves_Relative));

        if (Input.GetKeyDown(KeyCode.R) == true && g.Reset_Id == ID && System.Array.IndexOf(blahi_local, g.Global_moves_Relative) != -1 && is_hide == false)
        {
            //      if (g.Id_target_x == ID) ;
            ////blah_local[System.Array.IndexOf(blahi_local, g.Global_moves_Relative)].y = 0;
////new

        }

        //// new
    if (Input.GetKeyDown(KeyCode.R) == true){
     
blahi_local[ System.Array.IndexOf(blahi_local,new Vector3 (-5,-100,-5))].y= 0;
        }

 
    ///  if(Input.GetKeyDown(KeyCode.R) == true  && System.Array.IndexOf(blahi_local, moves_local[i]) != -1 && completedmoves != 0)
      ///      {
     ///
      ///   blah_local[System.Array.IndexOf(blahi_local, moves_local[i])].y = 0;
      ///          i++;

       ///     completedmoves--;
      ///      g.globalmoves--;
       ///     }
    /// if(completedmoves == 0)
    ///    {

        ///    i = 0;
     ///   }
     ///   for (int i = 0; i < completedmoves+1; i++)
     ///   {
     //       revmoves[revc] = moves_local[completedmoves - revc];
///revc++;
    ///    }
     ///   revc = 0;
        //notreset
        

        blahi_local[j] = new Vector3Int(Mathf.RoundToInt(mesh1.vertices[j].x), Mathf.RoundToInt(mesh1.vertices[j].y), Mathf.RoundToInt(mesh1.vertices[j].z));
        Destroy(collider);
        collider = gameObject.AddComponent(typeof(MeshCollider)) as MeshCollider;

     
      

       
        //     if (blahi_local[cp_local] == g.player_position_global)
        //      {
        //truepos = blah[j];

      



        mesh1.vertices = blah_local;
       
      
        j++;
    
        if (j > blah_local.Length - 1)
        {
            j = 0;
        }

     



    }
}

