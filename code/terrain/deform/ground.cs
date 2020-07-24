using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ground : MonoBehaviour
{

   public stamina st;
   public int globalmoves;
    public playercontroller pc;
    public Transform player;
   public Vector3Int player_position_global;
    public int Id_target_x;
    public int local_target; 
    public float plainsize  ;
    public Vector3Int player_position_global_relative;

   public int Reset_Id;
   public int Reset_I;
    public Vector3Int Global_moves_Relative;
    public Vector3Int[] Global_moves_Array;
    public Vector3Int[] Global_moves_Array_reversed;
    public int I_reverse;
   public Vector3[] player_goto_accurate;
   public Vector3 actual_player_pos;
   public Vector3[] player_goto_reversed_accurate;


  

    // public int x_offset;
    private void Start()
    {
        player_goto_reversed_accurate =   new Vector3[999];
        player_goto_accurate =   new Vector3[999];
        Global_moves_Array = new Vector3Int[999];
        Global_moves_Array_reversed = new Vector3Int[999];
    }
    private void Update()
    {
        if(st.fill > 0){
        actual_player_pos =player.transform.position;
        
        player_position_global = new Vector3Int(Mathf.RoundToInt(player.position.x + pc.moveHorizontal),
          0, Mathf.RoundToInt(player.position.z + pc.moveVertical) );

        Id_target_x = Mathf.RoundToInt(player.position.x/ plainsize);
        Id_target_x++;


        player_position_global_relative = player_position_global;
        player_position_global_relative.x = player_position_global.x -  (Id_target_x -1) * 10;
        }
        //   Reset_Id = -1;
        //reset 

  if (Input.GetKeyDown(KeyCode.R) == true)
        {
            st.staminaregain++;
Reset_Id = Mathf.RoundToInt((Global_moves_Array_reversed[ Reset_I].x +5) / 10) ;

            for (int i = 0; i < globalmoves; i++)
            {
                Global_moves_Array_reversed[I_reverse] = Global_moves_Array[globalmoves-1 - I_reverse];
                player_goto_reversed_accurate[I_reverse] = player_goto_accurate[globalmoves-1 - I_reverse];
                I_reverse++;
            }
            I_reverse = 0;

            Global_moves_Relative = Global_moves_Array_reversed[Reset_I];
            Global_moves_Relative.x = Global_moves_Array_reversed[Reset_I].x - Reset_Id *10;
            Global_moves_Relative.y = -100;
           Reset_Id++;
            // if(Reset_Id != 1)
            //  {
            //     Global_moves_Relative.x -= 2;
            //    }
            // Global_moves_Relative.x -= 2;

            Reset_I++;
        //    Reset_Id = Mathf.RoundToInt(  Global_moves_Array[globalmoves  - Reset_I].x /10);
   
            
            
            if(Global_moves_Relative == new Vector3Int(0,-100,0))  {


                      Reset_I = 0;

       }




            if (Reset_I - 1 != -1)
            {
//
              //  player.transform.position
               //     = new Vector3(player_goto_reversed_accurate[Reset_I - 1].x,
                //    player_goto_reversed_accurate[Reset_I - 1].z-5, 6);
            }
        }

    }
}
