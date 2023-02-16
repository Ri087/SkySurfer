using SkySurfer.Assets.Scripts.Entities.EnemyEntity;
using SkySurfer.Assets.Scripts.Entities.PlayerEntity;
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
        private List<Enemy> ListEnemy = new();
        private ClassicState _classicState = new();
        private Stack<> _states = new();


    }
}
