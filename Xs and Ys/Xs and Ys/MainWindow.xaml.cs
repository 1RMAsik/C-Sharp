using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Xs_and_Ys
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private bool _isXTurn = true;
#pragma warning disable CS0414
        private int _xWins;
#pragma warning restore CS0414
#pragma warning disable CS0414
        private int _oWins;
#pragma warning restore CS0414
        
        
        public MainWindow()
        {
            InitializeComponent();
            
        }
        private void CheckForWinner()
{
    // Проверяем горизонтали
    if (Btn00.Content == Btn01.Content && Btn01.Content == Btn02.Content && Btn00.Content != null)
    {
        UpdateStats((string)Btn00.Content);
        MessageBox.Show($"{Btn00.Content} победил!");
        ResetGame();
        return;
    }
    if (Btn10.Content == Btn11.Content && Btn11.Content == Btn12.Content && Btn10.Content != null)
    {
        UpdateStats((string)Btn10.Content);
        MessageBox.Show($"{Btn10.Content} победил!");
        ResetGame();
        return;
    }
    if (Btn20.Content == Btn21.Content && Btn21.Content == Btn22.Content && Btn20.Content != null)
    {
        UpdateStats((string)Btn20.Content);
        MessageBox.Show($"{Btn20.Content} победил!");
        ResetGame();
        return;
    }

    // Проверяем вертикали
    if (Btn00.Content == Btn10.Content && Btn10.Content == Btn20.Content && Btn00.Content != null)
    {
        UpdateStats((string)Btn00.Content);
        MessageBox.Show($"{Btn00.Content} победил!");
        ResetGame();
        return;
    }
    if (Btn01.Content == Btn11.Content && Btn11.Content == Btn21.Content && Btn01.Content != null)
    {
        UpdateStats((string)Btn01.Content);
        MessageBox.Show($"{Btn01.Content} победил!");
        ResetGame();
        return;
    }
    if (Btn02.Content == Btn12.Content && Btn12.Content == Btn22.Content && Btn02.Content != null)
    {
        UpdateStats((string)Btn02.Content);
        MessageBox.Show($"{Btn02.Content} победил!");
        ResetGame();
        return;
    }

    // Проверяем диагонали
    if (Btn00.Content == Btn11.Content && Btn11.Content == Btn22.Content && Btn00.Content != null)
    {
        UpdateStats((string)Btn00.Content);
        MessageBox.Show($"{Btn00.Content} победил!");
        ResetGame();
        return;
    }
    if (Btn02.Content == Btn11.Content && Btn11.Content == Btn20.Content && Btn02.Content != null)
    {
        UpdateStats((string)Btn02.Content);
        MessageBox.Show($"{Btn02.Content} победил!");
        ResetGame();
        return;
    }

    // Проверяем на ничью
    if (Btn00.Content != null && Btn01.Content != null && Btn02.Content != null &&
        Btn10.Content != null && Btn11.Content != null && Btn12.Content != null &&
        Btn20.Content != null && Btn21.Content != null && Btn22.Content != null)
    {
        MessageBox.Show("Ничья!");
        ResetGame();
    }
}


        private void BtnMinimize_OnClick(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void BtnClose_OnClick_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
            
        }

        private void MainWindow_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }


        // ReSharper disable once UnusedMember.Local
        private void CreateButtonsMatrix()
        {
            var uniformGrid = new UniformGrid()
            {
                Rows = 3,
                Columns = 3
            };
            

            for (int i = 1; i <= 9; i++)
            {
                var button = new Button()
                {
                    Content = $"{i}"
                };
                uniformGrid.Children.Add(button);
                
            }
            Grid.SetRow(uniformGrid, 2);    
            Content = uniformGrid;
            
        }

        private void BtnMaximize_OnClick(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }
            else if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            } 
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Content == null)
            {
                btn.Content = _isXTurn ? "X" : "O";
                _isXTurn = !_isXTurn;
                CheckForWinner();
            }
        }
        private void ResetGame()
        {
            Btn00.Content = null;
            Btn01.Content = null;
            Btn02.Content = null;
            Btn10.Content = null;
            Btn11.Content = null;
            Btn12.Content = null;
            Btn20.Content = null;
            Btn21.Content = null;
            Btn22.Content = null;
        }
        
        private void UpdateStats(string winner)
        {
            string path = @"stats.json";
            Dictionary<string, int>? stats;


            try
            {
                string json = File.ReadAllText(path);
                stats = JsonSerializer.Deserialize<Dictionary<string, int>>(json);
            }
            catch (FileNotFoundException)
            {
            
                stats = new Dictionary<string, int>();
            }


            if (winner == "X")
            {
                if (stats!.ContainsKey("X"))
                {
                    stats["X"]++;
                }
                else
                {
                    stats.Add("X", 1);
                }
            }
            else if (winner == "O")
            {
                if (stats!.ContainsKey("O"))
                {
                    stats["O"]++;
                }
                else
                {
                    stats.Add("O", 1);
                }
            }
            if (winner == "X")
            {
                _xWins++;
            }
            else if (winner == "O")
            {
                _oWins++;
            }
            WinStats.Content = $"Выигрыши: X {_xWins} - O {_oWins}";


            string jsonOutput = JsonSerializer.Serialize(stats);
            File.WriteAllText(path, jsonOutput);

        }

        private void ExportStats_Click(object sender, RoutedEventArgs e)
        {
            string path = @"stats.json";
            string json;

            // Пытаемся прочитать данные из файла
            try
            {
                json = File.ReadAllText(path);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Файл со статистикой не найден.");
                return;
            }

            // Отображаем данные в диалоговом окне
            MessageBox.Show(json, "Статистика побед", MessageBoxButton.OK, MessageBoxImage.Information);
            }


            
            
        }
    }
