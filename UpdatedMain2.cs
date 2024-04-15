using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CarRepair
{
    public partial class MainForm : Form
    {
        private List<Car> cars = new List<Car>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string make = makeTextBox.Text;
            string model = modelTextBox.Text;
            int year = int.Parse(yearTextBox.Text);

            Car newCar = new Car(make, model, year);
            cars.Add(newCar);

            UpdateListBox();
            ClearTextBoxes();
        }

        private void addRepairButton_Click(object sender, EventArgs e)
        {
            if (carListBox.SelectedIndex != -1)
            {
                Car selectedCar = cars[carListBox.SelectedIndex];
                string description = repairDescriptionTextBox.Text;
                decimal amount = decimal.Parse(repairAmountTextBox.Text);

                Repair newRepair = new Repair(description, amount);
                selectedCar.AddRepair(newRepair);

                DisplayCarDetails(selectedCar);
                ClearRepairTextBoxes();

                UpdateStatistics();
            }
        }

        private void UpdateListBox()
        {
            carListBox.Items.Clear();
            foreach (Car car in cars)
            {
                carListBox.Items.Add(car);
            }
        }

        private void ClearTextBoxes()
        {
            makeTextBox.Text = "";
            modelTextBox.Text = "";
            yearTextBox.Text = "";
        }

        private void ClearRepairTextBoxes()
        {
            repairDescriptionTextBox.Text = "";
            repairAmountTextBox.Text = "";
        }

        private void carListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (carListBox.SelectedIndex != -1)
            {
                Car selectedCar = cars[carListBox.SelectedIndex];
                DisplayCarDetails(selectedCar);
            }
        }

        private void DisplayCarDetails(Car car)
        {
            makeLabel.Text = "Make: " + car.Make;
            modelLabel.Text = "Model: " + car.Model;
            yearLabel.Text = "Year: " + car.Year;

            repairsListBox.Items.Clear();
            foreach (Repair repair in car.Repairs)
            {
                repairsListBox.Items.Add(repair);
            }

            totalCostLabel.Text = "Total Cost: $" + car.GetTotalRepairCost();
        }

        private void UpdateStatistics()
        {
            decimal totalCostAllCars = cars.Sum(car => car.GetTotalRepairCost());
            int totalCars = cars.Count;
            decimal averageRepairAmount = totalCostAllCars / totalCars;

            totalCostAllCarsLabel.Text = "Total Cost for All Cars: $" + totalCostAllCars;
            totalCarsLabel.Text = "Total Cars: " + totalCars;
            averageRepairAmountLabel.Text = "Average Repair Amount: $" + averageRepairAmount;
            averagePerCarLabel.Text = "Average Per Car: $" + (totalCostAllCars / totalCars);
        }
    }
}
