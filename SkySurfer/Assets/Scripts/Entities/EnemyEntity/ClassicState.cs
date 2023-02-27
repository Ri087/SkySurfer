using SFML.Graphics;
using SFML.System;
using SkySurfer.Assets.Scripts.Entities.LaserEntity;
using SkySurfer.Assets.Scripts.Entities.PlayerEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.EnemyEntity
{
    internal class ClassicState : EnemyBaseState
    {
        private Enemy _enemy;

        public ClassicState()
        {
            _enemy = new();
        }
        public override bool CheckIfOut()
        {
            return _enemy.GetPositionX() < -0.25f;
        }
        
        public override void Cleanup()
        {
        }

        public override void Draw()
        {
            float windowX = SettingsManager.GetIntances().GetWindow().Size.X;
            float windowY = SettingsManager.GetIntances().GetWindow().Size.Y;

            RectangleShape enemy = new(new Vector2f(windowX * 0.08f, windowY * 0.1f));
            enemy.Position = new Vector2f(windowX * _enemy.GetPositionX(), windowY * _enemy.GetPositionY());
            enemy.FillColor = Color.Red;

            // Ajout de le hit-box de l'ennemi
            _enemy.SetEnemyBounds(enemy);

            SettingsManager.GetIntances().GetWindow().Draw(enemy);
        }

        public override void Exit()
        {
            EnemyStateManager.GetInstance().GetEnemies().Clear();   
        }

        public override void HandleInput()
        {
        }

        public override void Init()
        {
        }

        public override void Update(float deltaTime, float velocity)
        {
            _enemy.SetPositionX(_enemy.GetPositionX() - deltaTime * velocity / 5);
         }
        
        public override FloatRect GetShootHitBox()
        {
            return _enemy.GetEnemyBounds();
        }
    }
}
