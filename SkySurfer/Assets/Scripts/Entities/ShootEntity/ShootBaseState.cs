using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.ShootEntity
{
    public abstract class ShootBaseState
    {
        public abstract void Init(float y);
        public abstract void Update(float deltaTime, float velocity);
        public abstract void Draw();
        public abstract bool CheckIfOut();
        public abstract bool CheckColision();
    }
}
