﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMS.DeskTop.ViewModels.WorkPlace.Attendance.Subitem
{
    public class ShiftSettingViewModel : BindableBase
    {
        private Boolean isOpenNewShiftView = false;
        public Boolean IsOpenNewShiftView
        {
            get { return isOpenNewShiftView; }
            set { isOpenNewShiftView = value; RaisePropertyChanged(); }
        }

        public ShiftSettingViewModel()
        {
            this.OpenNewShiftView = new DelegateCommand(() =>
            {
                IsOpenNewShiftView = true;
            }); 
        }

        public DelegateCommand OpenNewShiftView { get; private set; }

    }
}