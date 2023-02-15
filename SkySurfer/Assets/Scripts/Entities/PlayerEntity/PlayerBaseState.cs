﻿using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkySurfer.Assets.Scripts.Entities.PlayerEntity
{
    public abstract class PlayerBaseState
    {
        public abstract void Init(Player player);
        public abstract void Exit();
        public abstract void Cleanup();
        public abstract void Update(float deltaTime, float velocity);
        public abstract void Draw(RenderWindow window);
        public abstract void HandleInput();
    }
}
