using SkySurfer.Assets.Scripts.Entities.PowerUpEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities
{
    class PowerUpStateManager
    {
        private static PowerUpStateManager _instance = new();
        private PowerUpBaseState _powerUp;
        private List<PowerUpBaseState> _powerUpStates = new List<PowerUpBaseState>
        {
            new HeavyUpState(),
            new StickyUpState(),
        };
        private float timeFromLastTransformation = 0;
        public static PowerUpStateManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new();
            }
            return _instance;
        }

        public void Clear()
        {
            _powerUp = null;
            timeFromLastTransformation = 0;
        }
        public PowerUpBaseState GetPowerUp()
        {
            return _powerUp;
        }
        public void UpdatePowerUp(float deltaTime, float velocity)
        {
            if (PlayerStateManager.GetInstance().GetStates().Peek() != PlayerStateManager.GetInstance().GetClassicState()) return;
            if (_powerUp == null)
            {
                timeFromLastTransformation -= deltaTime;
                if (timeFromLastTransformation > 0) return;
                timeFromLastTransformation = 15;
                _powerUp = _powerUpStates.ElementAt(new Random().Next(0, _powerUpStates.Count));
                _powerUp.Init();
            } else
            {
                _powerUp.Update(deltaTime, velocity);
                if (_powerUp.CheckIfOut())
                {
                    _powerUp = null;
                }
            }
        }
        public void DrawPowerUp()
        {
            if (_powerUp == null) return;
            _powerUp.Draw();
        }
    }
}
