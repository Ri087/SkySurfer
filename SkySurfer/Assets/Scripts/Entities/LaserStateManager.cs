using SkySurfer.Assets.Scripts.Entities.LaserEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities
{
    class LaserStateManager
    {
        private static LaserStateManager _instance = new();
        private List<LaserBaseState> _lasers = new List<LaserBaseState>();
        private float _timeFromLastLaser = 2.5f;
        private float _timeBetweenLaser = 3.5f;

        public static LaserStateManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new();
            }
            return _instance;
        }

        public List<LaserBaseState> GetLasers()
        {
            return _lasers;
        }

        public void DrawLasers()
        {
            foreach (LaserBaseState laser in _lasers)
            {
                laser.Draw();
            }
        }

        public void UpdateLasers(float deltaTime, float velocity)
        {
            SpawnNewLaser(deltaTime, velocity);

            foreach (LaserBaseState laser in _lasers)
            {
                laser.Update(deltaTime, velocity);
            }

            // Check if the most recent laser is already past to supress it
            if (_lasers.Count != 0)
            {
                if (_lasers.First().CheckIfOut())
                {
                    _lasers.Remove(_lasers.First());
                }
            }
        }

        public void SpawnNewLaser(float deltaTime, float velocity)
        {
            _timeFromLastLaser += deltaTime + (velocity / 2.35f) * deltaTime;
            if (_timeFromLastLaser < _timeBetweenLaser) return;
            _timeFromLastLaser = 0;
            _lasers.Add(new ClassicState());
        }
    }
}
