﻿using System.Windows.Controls;
using System.Windows.Media;

namespace TMS.Core.Data.Entity
{
    public class ActivityCardEntity
    {
        public ActivityCardEntity()
        {
            OuterRectSize = 25;
            InnerRectSize = 8;
            CardWidth = 400;
            DateTime = "Default Time";
            LineSize = 2;
            OuterRectColor = new SolidColorBrush(Color.FromRgb(243, 246, 249));
            InnerRectColor = new SolidColorBrush(Color.FromRgb(88, 176, 237));
            LineColor = new SolidColorBrush(Color.FromRgb(243, 246, 249));
        }

        public int OuterRectSize { get; set; }

        public int InnerRectSize { get; set; }

        public int CardWidth { get; set; }

        public int CardHeight { get; set; }

        public UserControl CardContent { get; set; }

        public string DateTime { get; set; }

        public int LineSize { get; set; }

        public Brush LineColor { get; set; }

        public Brush OuterRectColor { get; set; }

        public Brush InnerRectColor { get; set; }


    }
}
