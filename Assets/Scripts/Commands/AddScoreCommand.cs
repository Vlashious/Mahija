using System.Collections;
using System.Collections.Generic;
using Components;
using Data;
using UnityEngine;
using Zenject;

namespace Commands
{
    public class AddScoreCommand : ICommandWithParameter
    {
        [Inject] PlayerData _data;

        public void Execute(CommandParameter parameter)
        {
            var addScoreParameter = (AddScoreParameter)parameter;
            _data.PlayerScore += addScoreParameter.ScoreToAdd;
        }

        public class AddScoreParameter : CommandParameter
        {
            public int ScoreToAdd { get; set; }
        }
    }
}