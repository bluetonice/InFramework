﻿using IF.Core.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace IF.Core.Interfaces
{
    public interface IDbDeleteCommand<in TCommand> : IDbCommand where TCommand : BaseCommand
    {
        void Execute(TCommand command);
    }
}