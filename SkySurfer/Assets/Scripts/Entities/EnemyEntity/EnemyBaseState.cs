using SFML.Graphics;
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
        public abstract void Update(float deltaTime, float velocity);
        public abstract void Draw();
        public abstract bool CheckIfOut();
        public abstract FloatRect GetShootHitBox();



    }
}
