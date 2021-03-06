﻿using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace DashAgil.Enums
{
    public static class EnumExtensions
    {
        public static string GetDisplayName(this Enum value)
        {
            return
                value
                    .GetType()
                    .GetMember(value.ToString())
                    .FirstOrDefault()
                    ?.GetCustomAttribute<DescriptionAttribute>()
                    ?.Description
                    ?? value.ToString();
        }
    }
}
