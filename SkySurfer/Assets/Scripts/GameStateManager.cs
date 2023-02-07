using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts
{
    public class GameStateManager
    {
        private static GameStateManager _instance = new();
        private GameBaseState _currentState = null;
        private MainMenuGameState _mainMenuGameState = new();
        private PlayGameState _playGameState = new();
        private Stack<GameBaseState> _states = new();

        public GameStateManager()
        {
            _states.Push(_mainMenuGameState);
        }
        public static GameStateManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new GameStateManager();
            }
            return _instance;
        }

        public GameBaseState GetCurrentState()
        {
            return _currentState;
        }

        public GameBaseState GetMainMenuGameState()
        {
            return _mainMenuGameState;
        }

        public GameBaseState GetPlayGameBaseState()
        {
            return _playGameState;
        }

        public Stack<GameBaseState> GetStates()
        {
            return _states;
        }

        public void SwitchState(GameBaseState state)
        {
            _states.Pop();
            _states.Push(state);
            _states.Peek().Init();
        }
    }
}
