using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using TMS.Core.Data;

namespace TMS.DeskTop.UserControls.Views.ChatBubbleCustom
{
    public class AuthLookPersonnelFile : ContentControl
    {
        public AuthLookPersonnelFileEntity Info
        {
            get { return (AuthLookPersonnelFileEntity)GetValue(InfoProperty); }
            set { SetValue(InfoProperty, value); }
        }

        public static readonly DependencyProperty InfoProperty =
            DependencyProperty.Register("InfoProperty", typeof(AuthLookPersonnelFileEntity), typeof(AuthLookPersonnelFile), new PropertyMetadata(default(AuthLookPersonnelFileEntity)));


        private void ChangeTemplate()
        {
            //this.SetResourceReference(this.Template, "");
        }

        //public AuthLookFilePersonnelStatus Status
        //{
        //    get { return (AuthLookFilePersonnelStatus)GetValue(StatusProperty); }
        //    set { SetValue(StatusProperty, value); }
        //}

        //public static readonly DependencyProperty StatusProperty =
        //    DependencyProperty.Register("Status", typeof(AuthLookFilePersonnelStatus), typeof(AuthLookPersonnelFile), new PropertyMetadata(default(AuthLookFilePersonnelStatus)));


        //public long RequesterId
        //{
        //    get { return (long)GetValue(RequesterIdProperty); }
        //    set { SetValue(RequesterIdProperty, value); }
        //}

        //public static readonly DependencyProperty RequesterIdProperty =
        //    DependencyProperty.Register("RequesterId", typeof(long), typeof(AuthLookPersonnelFile), new PropertyMetadata(default(long)));

        //public long ProcessorId
        //{
        //    get { return (long)GetValue(ProcessorIdProperty); }
        //    set { SetValue(ProcessorIdProperty, value); }
        //}

        //public static readonly DependencyProperty ProcessorIdProperty =
        //    DependencyProperty.Register("ProcessorId", typeof(long), typeof(AuthLookPersonnelFile), new PropertyMetadata(default(long)));








    }
}
