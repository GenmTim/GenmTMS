﻿using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Windows;
using TMS.Core.Data;
using TMS.DeskTop.Tools.Base;
using TMS.DeskTop.ViewModels;
using TMS.DeskTop.Views.Contacts;

namespace TMS.DeskTop.Views
{
    /// <summary>
    /// ContactsView.xaml 的交互逻辑
    /// </summary>
    public partial class ContactsView : RegionManagerControl
    {
        public ContactsView(IRegionManager regionManager) : base(regionManager, nameof(ContactsView))
        {
            InitializeComponent();
            RegisterDefaultRegionView(RegionToken.ContactsContent, nameof(OrganizationalStructrureView));
        }
    }
}
