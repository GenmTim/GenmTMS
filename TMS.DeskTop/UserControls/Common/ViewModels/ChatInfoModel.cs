﻿using Genm.Data.Enums;

namespace TMS.DeskTop.UserControls.Common.ViewModels
{
    public struct ChatInfoModel
    {
        public object Message { get; set; }

        public string SenderId { get; set; }

        public ChatRoleType Role { get; set; }

        public ChatMessageType Type { get; set; }

        public object Enclosure { get; set; }
    }
}
