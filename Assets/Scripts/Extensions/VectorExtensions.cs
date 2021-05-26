using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Extensions
{
    public static class VectorExtensions
    {
        public static Vector2 Randomize(int from, int to)
        {
            return new Vector2(Random.Range(from, to), Random.Range(from, to));
        }
    }
}