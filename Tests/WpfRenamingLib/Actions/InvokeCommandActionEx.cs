using System;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;

namespace Koo.Utilities.WPF.Actions
{
    public class InvokeCommandActionEx : TriggerAction<DependencyObject>
    {
        private string commandName;
        public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(InvokeCommandActionEx), null);
        public static readonly DependencyProperty CommandParameterProperty = DependencyProperty.Register("CommandParameter", typeof(object), typeof(InvokeCommandActionEx), null);

        /// <summary>
        /// 获得或设置此操作应调用的命令的名称。
        /// </summary>
        /// <value>此操作应调用的命令的名称。</value>
        /// <remarks>如果设置了此属性和 Command 属性，则此属性将被后者所取代。</remarks>
        public string CommandName
        {
            get
            {
                base.ReadPreamble();
                return this.commandName;
            }
            set
            {
                if (this.CommandName != value)
                {
                    base.WritePreamble();
                    this.commandName = value;
                    base.WritePostscript();
                }
            }
        }

        /// <summary>
        /// 获取或设置此操作应调用的命令。这是依赖属性。
        /// </summary>
        /// <value>要执行的命令。</value>
        /// <remarks>如果设置了此属性和 CommandName 属性，则此属性将优先于后者。</remarks>
        public ICommand Command
        {
            get
            {
                return (ICommand)base.GetValue(InvokeCommandActionEx.CommandProperty);
            }
            set
            {
                base.SetValue(InvokeCommandActionEx.CommandProperty, value);
            }
        }

        /// <summary>
        /// 获得或设置命令参数。这是依赖属性。
        /// </summary>
        /// <value>命令参数。</value>
        /// <remarks>这是传递给 ICommand.CanExecute 和 ICommand.Execute 的值。</remarks>
        public object CommandParameter
        {
            get
            {
                return base.GetValue(InvokeCommandActionEx.CommandParameterProperty);
            }
            set
            {
                base.SetValue(InvokeCommandActionEx.CommandParameterProperty, value);
            }
        }

        /// <summary>
        /// 调用操作。
        /// </summary>
        /// <param name="parameter">操作的参数。如果操作不需要参数，则可以将参数设置为空引用。</param>
        protected override void Invoke(object parameter)
        {
            
        }

    }
}
