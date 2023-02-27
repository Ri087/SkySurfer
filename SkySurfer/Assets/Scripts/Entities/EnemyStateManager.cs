using SkySurfer.Assets.Scripts.Entities.EnemyEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities
{
    internal class EnemyStateManager
    {
        private static EnemyStateManager _instance = new();
        private List<EnemyBaseState> _enemies = new List<EnemyBaseState>();
        private float _timeFromLastEnemy = 1;
        private float _timeBetweenEnemy = 2f;
        public static EnemyStateManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new();
            }
            return _instance;
        }
        public void Clear()
        {
            _enemies.Clear();
            _timeFromLastEnemy = 1;
        }
        public List<EnemyBaseState> GetEnemies()
        {
            return _enemies;
        }

        public void DrawEnemies()
        {
            foreach (EnemyBaseState enemy in _enemies)
            {
                enemy.Draw();
            }
        }
        public void UpdateEnemies(float deltaTime, float velocity)
        {
            if (PlayerStateManager.GetInstance().GetStates().Peek() != PlayerStateManager.GetInstance().GetClassicState()) return;
            SpawnNewEnemy(deltaTime, velocity);

            foreach (EnemyBaseState enemy in _enemies)
            {
                enemy.Update(deltaTime, velocity);
            }

            // Check if the most recent laser is already past to supress it
            if (_enemies.Count != 0)
            {
                if (_enemies.First().CheckIfOut())
                {
                    _enemies.Remove(_enemies.First());
                }  
            }
        }

        public void SpawnNewEnemy(float deltaTime, float velocity)
        {
            _timeFromLastEnemy += deltaTime + (velocity / 5) * deltaTime;
            if (_timeFromLastEnemy < _timeBetweenEnemy) return;
            _timeFromLastEnemy = 0;
            _enemies.Add(new ClassicState());
        }
    }
}

