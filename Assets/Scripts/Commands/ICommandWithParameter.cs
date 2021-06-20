using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Commands
{
    public interface ICommandWithParameter
    {
        public void Execute(CommandParameter parameter);
    }

    public class CommandParameter
    {
    }
}
