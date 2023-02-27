using SFML.Graphics;
using SkySurfer.Assets.Scripts.Entities.PlayerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.PowerUpEntity
{
    abstract class PowerUpBaseState
    {
        public abstract void Init();
        public abstract void Update(float deltaTime, float velocity);
        public abstract void Draw();
        public abstract PowerUp GetPowerUp();
        public abstract bool CheckIfOut();
        public abstract void CheckPowerUpCollision();

    }
}
