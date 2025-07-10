using System.Windows;
using System.Windows.Controls;

namespace Example_02
{
    public class CounterButton : Button
    {
        // 1. Регистрируем DependencyProperty
        public static readonly DependencyProperty ClickCountProperty =
            DependencyProperty.Register(
                "ClickCount",
                typeof(int),
                typeof(CounterButton),
                new FrameworkPropertyMetadata(
                    0,
                    FrameworkPropertyMetadataOptions.None,
                    OnClickCountChanged));

        // 2. Обертка для удобного доступа
        public int ClickCount
        {
            get { return (int)GetValue(ClickCountProperty); }
            set { SetValue(ClickCountProperty, value); }
        }

        // 3. Колбэк при изменении счетчика
        private static void OnClickCountChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var button = (CounterButton)d;
            int newValue = (int)e.NewValue;
        
            // Обновляем текст кнопки
            button.Content = newValue == 0 
                ? "Кликните меня" 
                : $"Кликов: {newValue}";
        }

        // 4. Конструктор
        public CounterButton()
        {
            // Инициализация
            Content = "Кликните меня";
        
            // Обработчик клика
            Click += (sender, e) => ClickCount++;
        }
    }
}
