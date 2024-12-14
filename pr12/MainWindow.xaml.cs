
using liba12;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace pr12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void InputDataChanged(object sender, TextChangedEventArgs e)
        {
            ClearResults(); // Очистка поля результата при изменении входных данных
        }

        private void CalculateParallelepiped(object sender, RoutedEventArgs e)
        {
            CalculateAndDisplay(1);
        }

        private void CalculateDigits(object sender, RoutedEventArgs e)
        {
            CalculateAndDisplay(2);
        }

        private void CalculateAndDisplay(int taskNumber)
        {
            if (taskNumber == 1)
            {
                if (!ValidateParallelepipedInput()) return;
                double a = double.Parse(txtA.Text);
                double b = double.Parse(txtB.Text);
                double c = double.Parse(txtC.Text);
                double volume = Calculations.CalculateVolume(a, b, c);
                double surfaceArea = Calculations.CalculateSurfaceArea(a, b, c);
                txtVolume.Text = volume.ToString();
                txtSurfaceArea.Text = surfaceArea.ToString();
            }
            else
            {
                if (!ValidateDigitsInput()) return;
                int number = int.Parse(txtNumber.Text);
                int sum = Calculations.CalculateSumOfDigits(number);
                int product = Calculations.CalculateProductOfDigits(number);
                txtSum.Text = sum.ToString();
                txtProduct.Text = product.ToString();
            }
        }

        // ... (Другие функции: обработка меню, контекстных меню, "О программе" и т.д.) ...
        private bool ValidateParallelepipedInput()
        {
            // Проверка ввода: a, b, c должны быть числами больше 0
            return true; // Замените на реальную проверку
        }

        private bool ValidateDigitsInput()
        {
            // Проверка ввода: число должно быть двузначным
            return true; // Замените на реальную проверку
        }


        private void ClearResults()
        {
            txtVolume.Text = "";
            txtSurfaceArea.Text = "";
            txtSum.Text = "";
            txtProduct.Text = "";
        }
        DispatcherTimer timer;
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            // Добавляем таймер
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 0, 1, 0);
            timer.IsEnabled = true;
        }
        // Создаем вручную событие таймера

        private void Timer_Tick(object sender, EventArgs e)
        {

            DateTime d = DateTime.Now; //COздание обьекта
            time.Text = d.ToString("HH:mm"); //Bрeмя
            data.Text = d.ToString("dd. MM. yyyy"); //Дaта
        }


    }

}
