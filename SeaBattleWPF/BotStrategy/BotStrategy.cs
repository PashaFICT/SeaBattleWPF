﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SeaBattleWPF
{
    public abstract class BotStrategy
    {
        public abstract Location Shot(Location prevLoc);
    }
}
