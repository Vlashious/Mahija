using System.Collections;
using System.Collections.Generic;
using Components;
using UnityEngine;
using Zenject;

namespace Commands
{
    public class AddScoreCommand : ICommandWithParameter
    {
        [Inject] ScoreCounter _scoreCounter;

        public void Execute(CommandParameter parameter)
        {
            var addScoreParameter = (AddScoreParameter)parameter;
            _scoreCounter.Score += addScoreParameter.ScoreToAdd;
        }

        public class AddScoreParameter : CommandParameter
        {
            public int ScoreToAdd { get; set; }
        }
    }
}