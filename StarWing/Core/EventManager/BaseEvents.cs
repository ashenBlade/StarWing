using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWing.GameObjects.SceneObjects;
using StarWing.Framework;

namespace StarWing.Core.EventManager
{
    class BaseEvents
    {
        public void StartGame() { } // Start level of game

        public void FinishGame() { } // Successfully finished level (Complete the task)

        public void DamageEnemy(Projectile projectile, Enemy enemy) // Enemy get damage
        {
            if (projectile.Damage < enemy.Health)
            {
                enemy.Health -= projectile.Damage;
            }
            else
            {
                KillEnemy(enemy);
            }
        }

        public void KillEnemy(Enemy enemy) // Enemy was destroyed
        {

        }

        public void DamagedPlayer(Projectile projectile, Ship player) // Ship get damage
        {
            if (projectile.Damage < player.Health)
            {
                player.Health -= projectile.Damage;
            }
            else
            {
                KillPlayer();
            }
        } 

        public void KillPlayer() { } // Ship was destroyed (Unseccessfully finish level) : Start level again or go to Menu
    }
}
