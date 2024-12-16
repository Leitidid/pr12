
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
        private DispatcherTimer timer;
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1); // Обновление каждую секунду
            timer.Tick += Timer_Tick;
            timer.Start();
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
            if (taskNumber == 1) // Вычисление объёма и площади поверхности параллелепипеда
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
            else// Вычисление суммы и произведения цифр числа
            {
                if (!ValidateDigitsInput()) return;
                int number = int.Parse(txtNumber.Text);
                int sum = Calculations.CalculateSumOfDigits(number);
                int product = Calculations.CalculateProductOfDigits(number);
                txtSum.Text = sum.ToString();
                txtProduct.Text = product.ToString();
            }
        }


        private bool ValidateParallelepipedInput()
        {
            if (!double.TryParse(txtA.Text, out double a) ||
                !double.TryParse(txtB.Text, out double b) ||
                !double.TryParse(txtC.Text, out double c) ||
                a <= 0 || b <= 0 || c <= 0)
            {
                MessageBox.Show("Стороны параллелепипеда должны быть положительными числами.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }

    

        private bool ValidateDigitsInput()
        {
            // Проверка ввода: число должно быть положительным двухзначным целым числом
            if (!int.TryParse(txtNumber.Text, out int number) || number <= 9 || number >= 100)
            {
                MessageBox.Show("Введите положительное двухзначное целое число.", "Ошибка ввода", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
            return true;
        }
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            string developer = "Дудина Екатерина";
            int job = 11;
            string task = "Дана целочисленная матрица размера M * N. Найти номер первого из ее столбцов, \r\nсодержащих только нечетные числа. Если таких столбцов нет, то вывести 0.\r\n";
            MessageBox.Show($"Разработчик: {developer}\nНомер работы: {job}\nЗадание: {task}", "О программе");
        }

        // "Выход"
        private void MenuItem_Exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ClearResults()
        {
            txtVolume.Text = "";
            txtSurfaceArea.Text = "";
            txtSum.Text = "";
            txtProduct.Text = "";
        }
        
       
        
        // Создаем вручную событие таймера

        private void Timer_Tick(object sender, EventArgs e)
        {
            time.Text = DateTime.Now.ToString("HH:mm:ss"); // Текущее время
            data.Text = DateTime.Now.ToString("dd.MM.yyyy"); // Текущая дата
        }


    }

}
