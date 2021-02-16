using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameInput;
using Terraria.ModLoader;

namespace DashBind
{
    class DashPlayer : ModPlayer
    {
        int leftTimer = 0;
        bool dashingLeft = false;
        int rightTimer = 0;
        bool dashingRight = false;
        public override void ProcessTriggers(TriggersSet triggersSet)
        {
            if(dashingLeft)
            {
                dashingRight = false;
                rightTimer = 0;
                leftTimer++;
                if(leftTimer == 1)
                {
                    player.controlLeft = true;
                    player.releaseLeft = true;
                }
                else if(leftTimer >= 2)
                {
                    player.controlLeft = true;
                    player.releaseLeft = true;
                    leftTimer = 0;
                    dashingLeft = false;
                }
            }
            else if (dashingRight)
            {
                dashingLeft = false;
                leftTimer = 0;
                rightTimer++;
                if(rightTimer == 1)
                {
                    player.controlRight = true;
                    player.releaseRight = true;
                }
                if (rightTimer >= 2)
                {
                    player.controlRight = true;
                    player.releaseRight = true;
                    rightTimer = 0;
                    dashingRight = false;
                }
            }

            if (DashBind.DashKey.JustPressed)
            {
                if (player.direction == -1)
                {
                    player.controlLeft = true;
                    player.releaseLeft = true;
                    player.controlLeft = false;
                    player.releaseLeft = false;
                    dashingLeft = true;
                    
                }
                else if (player.direction == 1)
                {
                    player.controlRight = true;
                    player.releaseRight = true;
                    player.controlRight = false;
                    player.releaseRight = false;
                    dashingRight = true;
                }
            }
        }
    }
}
