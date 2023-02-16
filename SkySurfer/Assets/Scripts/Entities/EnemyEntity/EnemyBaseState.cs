using SkySurfer.Assets.Scripts.Entities.PlayerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.EnemyEntity
{
    public abstract class EnemyBaseState
    {
        public abstract void Init();
        public abstract void Exit();
        public abstract void Cleanup();
        public abstract void Update(float deltaTime);
        public abstract void Draw();
        public abstract void HandleInput();
    }
}
