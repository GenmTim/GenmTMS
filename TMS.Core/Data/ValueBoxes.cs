﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.Core.Data
{
    internal static class ValueBoxes
    {
        internal static object TrueBox = true;

        internal static object FalseBox = false;

        internal static object Double0Box = .0;

        internal static object Double01Box = .1;

        internal static object Double1Box = 1.0;

        internal static object Double10Box = 10.0;

        internal static object Double20Box = 20.0;

        internal static object Double100Box = 100.0;

        internal static object Double200Box = 200.0;

        internal static object Double300Box = 300.0;

        internal static object DoubleNeg1Box = -1.0;

        internal static object Int0Box = 0;

        internal static object Int1Box = 1;

        internal static object Int2Box = 2;

        internal static object Int5Box = 5;

        internal static object Int99Box = 99;

        internal static object BooleanBox(bool value) => value ? TrueBox : FalseBox;
    }
}
