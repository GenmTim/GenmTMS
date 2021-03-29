using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Genm.Controls
{
    public class SimpleRelayCommand : ICommand
    {
        private Action _action;

        public SimpleRelayCommand(Action action)
        {
            _action = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }

    public class CheckTreeView : TreeView, INotifyPropertyChanged
    {
        public CheckTreeView()
        {
            ClickCommand = new SimpleRelayCommand(new Action(OnClick));
        }

        public Action<CheckTreeView> StateChange;

        private void OnClick()
        {
            UpdateChildStatus();
            UpdateParentStatus();
        }

        private ICommand _ClickCommand;
        public ICommand ClickCommand
        {
            get
            {
                return _ClickCommand;
            }
            set
            {
                _ClickCommand = value;
            }
        }

        private long _id = 0;
        private bool? _IsChecked = false;
        private FrameworkElement _Content = null;
        public object ContentData { get; set; } = null;
        private CheckTreeView _Parent = null;
        private ObservableCollection<CheckTreeView> _Children = null;

        public bool? IsChecked
        {
            get => _IsChecked;
            set 
            { 
                _IsChecked = value; 
                OnPropertyChanged("IsChecked");
                StateChange?.Invoke(this);
            }
        }

        public long Id
        {
            get => _id;
            set { _id = value; OnPropertyChanged("_id"); }
        }


        public FrameworkElement Content
        {
            get => _Content;
            set { _Content = value; OnPropertyChanged("Content"); }
        }

        public new CheckTreeView Parent
        {
            get => _Parent;
            set { _Parent = value; OnPropertyChanged("Parent"); }
        }

        public ObservableCollection<CheckTreeView> Children
        {
            get => _Children;
            set { _Children = value; OnPropertyChanged("Childen"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string name)
        {
            if (null == PropertyChanged)
            {
                return;
            }

            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public void Add(CheckTreeView child)
        {
            if (null == Children)
            {
                Children = new ObservableCollection<CheckTreeView>();
            }

            child.Parent = this;
            Children.Add(child);
        }

        public void UpdateParentStatus()
        {
            if (null != Parent)
            {
                int isCheckedNull = 0;
                int isCheckedOn = 0;
                int isCheckedOff = 0;
                if (null != Parent.Children)
                {
                    foreach (CheckTreeView item in Parent.Children)
                    {
                        if (null == item.IsChecked)
                        {
                            isCheckedNull += 1;
                        }

                        if (true == item.IsChecked)
                        {
                            isCheckedOn += 1;
                        }

                        if (false == item.IsChecked)
                        {
                            isCheckedOff += 1;
                        }
                    }
                }
                if ((0 < isCheckedNull) || (0 < isCheckedOn) || (0 < isCheckedOff))
                {
                    if (0 < isCheckedNull)
                    {
                        Parent.IsChecked = null;
                    }
                    else if ((0 < isCheckedOn) && (0 < isCheckedOff))
                    {
                        Parent.IsChecked = null;
                    }
                    else if (0 < isCheckedOn)
                    {
                        Parent.IsChecked = true;
                    }
                    else
                    {
                        Parent.IsChecked = false;
                    }
                }
                Parent.UpdateParentStatus();
            }
        }

        public void UpdateChildStatus()
        {
            if (null != IsChecked)
            {
                if (null != Children)
                {
                    foreach (CheckTreeView item in Children)
                    {
                        item.IsChecked = IsChecked;
                        item.UpdateChildStatus();
                    }
                }
            }
        }
    }
}
