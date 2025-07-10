using System.Windows;
using System.Windows.Controls;

namespace Example_03
{
    public class MyButton : Button
    {
        public static RoutedEvent MyButtonClickEvent;

        static MyButton()
        {
            MyButtonClickEvent = EventManager.RegisterRoutedEvent("MyButtonClick",
                RoutingStrategy.Direct,
                typeof(RoutedEventHandler),
                typeof(MyButton));
        }

        public event RoutedEventHandler MyButtonClick
        {
            add { AddHandler(MyButtonClickEvent, value); }
            remove { RemoveHandler(MyButtonClickEvent, value); }
        }

        protected override void OnClick()
        {
            base.OnClick();
            // Аргумент, который будет передан обработчику события.
            RoutedEventArgs args = new RoutedEventArgs(MyButton.MyButtonClickEvent, this);
            // Вызов события. Событие, которое должно быть вызвано, определяется по параметрам объекта типа RoutedEventArgs
            RaiseEvent(args);
        }
    }
}
