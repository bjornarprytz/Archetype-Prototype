using System;
using Archetype.Core;
using UnityEngine;

namespace Extensions
{
    public static class ColorExtensions
    {
        public static Color ToUnityColor(this CardColor color)
        {
            return color switch
            {
                CardColor.White => Color.white,
                CardColor.Blue => Color.blue,
                CardColor.Black => Color.black,
                CardColor.Red => Color.red,
                CardColor.Green => Color.green,
                _ => throw new ArgumentOutOfRangeException(nameof(color), color, null)
            };
        }
    }
}