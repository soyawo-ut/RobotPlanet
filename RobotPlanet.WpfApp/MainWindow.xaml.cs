using RobotPlanet.Core;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace RobotPlanet.WpfApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Robot> Robots { get; }
            = new ObservableCollection<Robot>();

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private Robot? SelectedRobot
        {
            get
            {
                return RobotList.SelectedItem as Robot;
            }
        }

        private void AddRobot_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Enter robot name.");
                return;
            }

            if (TypeComboBox.SelectedItem is not ComboBoxItem selectedItem)
                return;

            string type = selectedItem.Content.ToString() ?? "";

            Robot robot;

            try
            {
                robot = type switch
                {
                    "CleanerBot" => new CleanerBot(name, 100),
                    "ExplorerBot" => new ExplorerBot(name, 100),
                    "RepairBot" => new RepairBot(name, 100),
                    "GuardBot" => new GuardBot(name, 100),  
                    _ => throw new Exception("Unknown robot type.")
                };

                Robots.Add(robot);
                LogList.Items.Add($"{robot.Name} joined Robot Planet.");
                NameTextBox.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RemoveRobot_Click(object sender, RoutedEventArgs e)
        {
            Robot? robot = SelectedRobot;

            if (robot == null)
            {
                MessageBox.Show("Select a robot first.");
                return;
            }

            Robots.Remove(robot);
            LogList.Items.Add($"{robot.Name} was removed from Robot Planet.");

            UpdateDetails();
        }

        private void Work_Click(object sender, RoutedEventArgs e)
        {
            Robot? robot = SelectedRobot;

            if (robot == null)
            {
                MessageBox.Show("Select a robot first.");
                return;
            }

            LogList.Items.Add(robot.Work());
            UpdateDetails();
        }

        private void CrazyAction_Click(object sender, RoutedEventArgs e)
        {
            Robot? robot = SelectedRobot;

            if (robot == null)
            {
                MessageBox.Show("Select a robot first.");
                return;
            }

            LogList.Items.Add(robot.CrazyAction());
            UpdateDetails();
        }

        private void Charge_Click(object sender, RoutedEventArgs e)
        {
            Robot? robot = SelectedRobot;

            if (robot == null)
            {
                MessageBox.Show("Select a robot first.");
                return;
            }

            if (robot is IChargeable chargeable)
            {
                LogList.Items.Add(chargeable.Charge(20));
            }
            else
            {
                LogList.Items.Add($"{robot.Name} cannot be charged.");
            }

            UpdateDetails();
        }

        private void Repair_Click(object sender, RoutedEventArgs e)
        {
            Robot? robot = SelectedRobot;

            if (robot == null)
            {
                MessageBox.Show("Select a robot first.");
                return;
            }

            if (robot is IRepair repairable)
            {
                LogList.Items.Add(repairable.Repair());
            }
            else
            {
                LogList.Items.Add($"{robot.Name} cannot perform repairs.");
            }

            UpdateDetails();
        }

        private void RobotList_SelectionChanged(
            object sender,
            SelectionChangedEventArgs e)
        {
            UpdateDetails();
        }

        private void UpdateDetails()
        {
            Robot? robot = SelectedRobot;

            if (robot == null)
            {
                SelectedRobotText.Text = "No robot selected";
                EnergyProgressBar.Value = 0;
                return;
            }

            SelectedRobotText.Text =
                $"{robot.GetType().Name}: {robot.Name}";

            EnergyProgressBar.Value = robot.Energy;
        }
    }
}