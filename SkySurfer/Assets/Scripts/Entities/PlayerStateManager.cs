using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SkySurfer.Assets.Scripts.Entities.PlayerEntity;
using SkySurfer.Assets.Scripts.Menu;

namespace SkySurfer.Assets.Scripts.Entities
{
    public class PlayerStateManager
    {
        private static PlayerStateManager _instance = new();
        private Player _player = new();
        private ClassicState _classicState = new();
        private HeavyState _heavyState = new();
        private StickyState _stickyState = new();
        private Stack<PlayerBaseState> _states = new();
        public PlayerStateManager()
        {
            _states.Push(_classicState);
            _states.Peek().Init(_player); // A mettre dans event du menu
        }

        public static PlayerStateManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new();
            }
            return _instance;
        }

        public Player GetPlayer()
        {
            return _player;
        }
        public PlayerBaseState GetClassicState()
        {
            return _classicState;
        }

        public PlayerBaseState GetHeavyState()
        {
            return _heavyState;
        }

        public PlayerBaseState GetStickyState()
        {
            return _stickyState;
        }

        public Stack<PlayerBaseState> GetStates()
        {
            return _states;
        }
        public void SwitchState(PlayerBaseState state)
        {
            _states.Pop();
            _states.Push(state);
            _states.Peek().Init(_player);
        }
    }
}
