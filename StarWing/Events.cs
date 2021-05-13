using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarWing.GameObjects.SceneObjects;

namespace StarWing
{
    enum eEvents
    {
        StartGame, // = StartLevel
        FinishGame, // This means that Player successfully complete the Quest
        //PausedGame, 
        //ResumedGame,
        DamageEnemy,
        DamagedPlayer,
        KillPlayer // Start level again or open UserMenu
    }

    class Events
    {
        public void StartGame()
        {
        
        }

        public void FinishGame() { }

        public void DamageEnemy(Projectile projectile, Enemy enemy) 
        {
            

        }

        public void KillEnemy()
        {
        
        }

        public void DamagedPlayer() { }

        public void KillPlayer() { }
    }
}
