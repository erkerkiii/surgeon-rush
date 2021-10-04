using System;
using System.Collections.Generic;

namespace RegeneratedStudios.SurgeonRush.Utility
{
    public static class CollectionHelper
    {
        private static readonly Random Random = new Random();
        
        public static T GetRandom<T>(this  IList<T> collection)
        {
            return collection[Random.Next(0, collection.Count)];
        }
    }
}