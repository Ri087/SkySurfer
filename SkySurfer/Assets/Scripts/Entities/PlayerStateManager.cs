using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkySurfer.Assets.Scripts.Entities.PlayerEntity;

namespace SkySurfer.Assets.Scripts.Entities
{
    class PlayerStateManager
    {
        private Player _player = new();
        private ClassicState _classicState = new();
        private HeavyState _heavyState = new();
        private FallState _fallState = new();
        private StickyState _stickyState = new();
        private Stack<PlayerBaseState> _states = new();
        public PlayerStateManager()
        {
            _states.Push(_classicState);
        }

        public Player GetPlayer()
        {
            return _player;
        }
        public ClassicState GetClassicState()
        {
            return _classicState;
        }

        public HeavyState GetHeavyState()
        {
            return _heavyState;
        }

        public FallState GetFallState()
        {
            return _fallState;
        }

        public StickyState GetStickyState()
        {
            return _stickyState;
        }

        public Stack<PlayerBaseState> GetStates()
        {
            return _states;
        }
    }
}
