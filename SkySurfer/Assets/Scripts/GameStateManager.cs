using SFML.Graphics;
using SkySurfer.Assets.Scripts.Menu;
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
        private MainMenuGameState _mainMenuGameState = new();
        private PlayGameState _playGameState = new();
        private SettingsGameState _SettingsGameState = new();
        private CreditsGameState _CreditsGameState = new();
        private LooseMenuGameState _LoosMenuGameState = new();
        private PauseMenuGameState _PauseMenuGameState = new();
        private Stack<GameBaseState> _states = new();


        public GameStateManager()
        {
            _states.Push(_mainMenuGameState);
        }
        public GameBaseState GetPauseMenuGameState()
        {
            return _PauseMenuGameState;
        }
        public static GameStateManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new();
            }
            return _instance;
        }

        public GameBaseState GetMainMenuGameState()
        {
            return _mainMenuGameState;
        }

        public GameBaseState GetPlayGameBaseState()
        {
            return _playGameState;
        }
        public GameBaseState GetLooseMenuGameState()
        {
            return _LoosMenuGameState;
        }
        public GameBaseState GetSettingsGameState()
        {
            return _SettingsGameState;
        }
        public GameBaseState GetCreditsGameState() 
        {
            return _CreditsGameState;
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
