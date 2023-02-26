using SkySurfer.Assets.Scripts.Entities.ShootEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities
{
    internal class ShootStateManager
    {
        private static ShootStateManager _instance = new();
        private List<ShootBaseState> _shoot = new List<ShootBaseState>();
      

        public static ShootStateManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new();
            }
            return _instance;
        }

        public List<ShootBaseState> GetShoot()
        {
            return _shoot;
        }

        public void DrawShoot()
        {
            foreach (ShootBaseState shoot in _shoot)
            {
                shoot.Draw();
            }
        }

        public void UpdateShoot(float deltaTime, float velocity)
        {
            foreach (ShootBaseState shoot in _shoot)
            {
                shoot.Update(deltaTime, velocity);
            }

            // Check if the most recent laser is already past to supress it
            if (_shoot.Count != 0)
            {
                if (_shoot.First().CheckIfOut())
                {
                    _shoot.Remove(_shoot.First());
                }
                foreach (ShootBaseState shoot in _shoot)
                {
                    if (shoot.CheckColision())
                    {
                        EnemyStateManager.GetInstance().GetEnemies().RemoveAt(0);
                        _shoot.Remove(_shoot.Last());
                        return;
                    }
                }
            }
        }
        public void SpawnShoot(float y)
        {

            _shoot.Add(new ClassicState());
           GetInstance().GetShoot().Last().Init(y);
          
            
        }
    }
}
