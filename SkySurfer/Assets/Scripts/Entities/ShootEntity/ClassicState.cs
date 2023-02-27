using SFML.Graphics;
using SFML.System;
using SkySurfer.Assets.Scripts.Entities.EnemyEntity;
using SkySurfer.Assets.Scripts.Entities.LaserEntity;
using SkySurfer.Assets.Scripts.Entities.PlayerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.ShootEntity
{
    internal class ClassicState : ShootBaseState
    {
        private Shoot _shoot;

        public ClassicState()
        {
            _shoot = new();
        }
   

        public override bool CheckIfOut()
        {
            return _shoot.GetPositionX() > 1.25f;
        }
        
        public override void Cleanup()
        {
            throw new NotImplementedException();
        }

        public override void Draw()
        {
            float windowX = SettingsManager.GetIntances().GetWindow().Size.X;
            float windowY = SettingsManager.GetIntances().GetWindow().Size.Y;

            RectangleShape shoot = new(new Vector2f(windowX * _shoot.length, windowY * _shoot.height));

            shoot.Position = new Vector2f(windowX * _shoot.GetPositionX(), windowY * _shoot.GetPositiony());
            shoot.FillColor = Color.Blue;

            _shoot.SetShootBounds(shoot);

            SettingsManager.GetIntances().GetWindow().Draw(shoot);
        }

        public override void Exit()
        {
            
        }

        public override void HandleInput()
        {
            throw new NotImplementedException();
        }

        public override void Init(float y)
        {
            _shoot.SetPositionY(y);
        }

        public override void Update(float deltaTime, float velocity)
        {
            _shoot.SetPositionX(_shoot.GetPositionX() + deltaTime * velocity);
        }
        public override bool CheckColision()
        {
            // detection collision entre shoot et enemy
            foreach(EnemyBaseState enemy in EnemyStateManager.GetInstance().GetEnemies())
            {
                return _shoot.GetShootBounds().Intersects(enemy.GetShootHitBox());
            }
            return false;
        }

     
    }
}
