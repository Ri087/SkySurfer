using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.PlayerEntity
{
    public abstract class PlayerBaseState
    {
        public abstract void Init();
        public abstract void Exit();
        public abstract void Cleanup();
        public abstract void Update(float deltaTime, float velocity);
        public abstract void Draw();
        public abstract void HandleInput();
        
        public abstract bool CheckCollision();
    }
}
