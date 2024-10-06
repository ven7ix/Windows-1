using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    internal class CustomCell
    {
        private string _data;
        private bool _isOpen = false;
        private List<CustomCell> _dependentCells = new List<CustomCell>();
        private CustomCell _parent;
        private bool _isShown = false;
        private Enum _whatInfoStored;

        //я не знаю правильно ли это, но оно работает
        private static readonly List<CustomCell> displayedCells = new List<CustomCell>();

        public CustomCell(string data, CustomCell parent)
        {
            _data = data;
            _parent = parent;
        }

        public static void AddNewCellOnTop(DataGridView dataGridView, string data, Enum whatInfoStored)
        {
            CustomCell cell = new CustomCell(data, null);
            displayedCells.Add(cell);
            dataGridView.Rows.Add("+", cell._data);
            cell._isShown = true;
            cell._whatInfoStored = whatInfoStored;
            MakeCellReadOnly(dataGridView.Rows[dataGridView.Rows.Count - 1].Cells[1], whatInfoStored);
        }

        public static void NewDependenceHandler(string data, Enum whatInfoStored, CustomCell cell)
        {
            CustomCell newCell = new CustomCell(data, cell);
            cell._dependentCells.Add(newCell);
            newCell._whatInfoStored = whatInfoStored;
        }

        //для добавления новой пустой зависимости
        public static void NewDependence(DataGridView dataGridView, Enum whatInfoStored)
        {
            int selected = dataGridView.CurrentCell.RowIndex;
            CustomCell cell = displayedCells[selected];
            NewDependenceHandler("-----", whatInfoStored, cell);
            dataGridView.Rows[selected].Cells[0].Value = "+";
        }

        //для добавления зависимости при создании нового человека
        public static void NewDependence(string data, Enum whatInfoStored)
        {
            CustomCell cell = displayedCells.Last();
            NewDependenceHandler(data, whatInfoStored, cell);
        }

        //только на первого потомка можно повесить зависимость (на потомка потомка и тд нельзя)
        //вызвывается только при создании нового person и нужен для первичной зависимости у birth от age
        public static void NewDependence(int dependentCellIndex, string data, Enum whatInfoStored)
        {
            CustomCell cell = displayedCells.Last()._dependentCells[dependentCellIndex];
            NewDependenceHandler(data, whatInfoStored, cell);
        }

        public static int IndexOfSelectedInPeopleArray(int selected)
        {
            CustomCell cell = displayedCells[selected];
            while (cell._parent != null)
            {
                cell = cell._parent;
            }

            int indexInPeopleArray = 0;
            foreach (CustomCell c in displayedCells)
            {
                if (c._parent == null)
                {
                    if (c == cell) break;
                    indexInPeopleArray++;
                }
            }

            return indexInPeopleArray;
        }

        public static void EditDependentCellData(int selected, string data, Enum whatInfoStored)
        {
            CustomCell cell = displayedCells[selected];

            Queue<CustomCell> queue = new Queue<CustomCell>();
            queue.Enqueue(cell);

            while (queue.Count > 0)
            {
                CustomCell current = queue.Dequeue();

                //body
                if (current._whatInfoStored.Equals(whatInfoStored))
                {
                    current._data = data;
                    break;
                }
                //end

                if (current._dependentCells == null) continue;
                foreach (CustomCell c in current._dependentCells) queue.Enqueue(c);
            }
        }

        public static int IndexOfSelectedRootCell(int selected)
        {
            CustomCell cell = displayedCells[selected];
            while (cell._parent != null)
            {
                cell = cell._parent;
            }

            int indexOfRoot = 0;
            foreach (CustomCell c in displayedCells)
            {
                if (c == cell) break;
                indexOfRoot++;
            }

            return indexOfRoot;
        }

        public static void DeleteDependence(int selected, DataGridView dataGridView)
        {
            CustomCell cell = displayedCells[selected];

            Queue<CustomCell> queue = new Queue<CustomCell>();
            queue.Enqueue(cell);

            while (queue.Count > 0)
            {
                CustomCell current = queue.Dequeue();

                //body
                if (current._isShown && displayedCells.IndexOf(current) != selected)
                {
                    dataGridView.Rows.RemoveAt(selected + 1);
                    displayedCells.RemoveAt(selected + 1);
                    current._isShown = false;
                }
                //end

                if (current._dependentCells == null) continue;
                foreach (CustomCell c in current._dependentCells) queue.Enqueue(c);
            }

            dataGridView.Rows.RemoveAt(selected);
            displayedCells.RemoveAt(selected);
            cell._parent?._dependentCells.Remove(cell);
        }

        //можно вынести в Form1
        //или избавиться от "enum_name" и "enum_other"
        public static void MakeCellReadOnly(DataGridViewCell cell, Enum whatInfoStored)
        {
            if (whatInfoStored.ToString() == "enum_name" || whatInfoStored.ToString() == "enum_other") cell.ReadOnly = false;
            else cell.ReadOnly = true;
        }

        public static void OpenCell(int selected, DataGridView dataGridView)
        {
            //есть dataGridViewPeople.Rows[i].Visible = false; мб когда-нибудь добавлю

            CustomCell cell = displayedCells[selected];
            if (cell._dependentCells.Count == 0) return;

            //открытие и закрытие ячейки (попеременно)
            if (!cell._isOpen)
            {
                foreach (CustomCell c in cell._dependentCells)
                {
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dataGridView);

                    if (c._dependentCells.Count > 0) newRow.Cells[0].Value = "+";

                    //для показа на каком уровне находится ячейка через пробелы; не работает \t
                    for (int i = 0; i < CountParents(c); i++) newRow.Cells[1].Value += "    ";

                    newRow.Cells[1].Value += c._data;
                    dataGridView.Rows.Insert(selected + 1, newRow);
                    displayedCells.Insert(selected + 1, c);
                    c._isShown = true;

                    MakeCellReadOnly(newRow.Cells[1], c._whatInfoStored);
                }
                dataGridView.Rows[selected].Cells[0].Value = "-";
                cell._isOpen = true;
            }
            else
            {
                //обход в ширину по всем зависимым ячейкам, которые есть у той, что мы закрыли
                Queue<CustomCell> queue = new Queue<CustomCell>();
                queue.Enqueue(cell);
                while (queue.Count > 0)
                {
                    CustomCell current = queue.Dequeue();

                    //закрытие ячейки
                    if (current._isShown && displayedCells.IndexOf(current) != selected)
                    {
                        dataGridView.Rows.RemoveAt(selected + 1);
                        displayedCells.RemoveAt(selected + 1);
                        current._isShown = false;
                        current._isOpen = false;
                    }
                    //end

                    if (current._dependentCells == null) continue;
                    foreach (CustomCell c in current._dependentCells) queue.Enqueue(c);
                }
                dataGridView.Rows[selected].Cells[0].Value = "+";
                cell._isOpen = false;
            }
        }

        public static void EnterEditCell(DataGridView dataGridView)
        {
            dataGridView.CurrentCell.Value = displayedCells[dataGridView.CurrentCell.RowIndex]._data;
        }

        private static int CountParents(CustomCell cell)
        {
            int countParents = 0;
            while (cell._parent != null)
            {
                cell = cell._parent;
                countParents++;
            }
            return countParents;
        }

        public static void ExitEditCell(DataGridView dataGridView)
        {
            string data = "";
            int selected = dataGridView.CurrentCell.RowIndex;
            CustomCell cell = displayedCells[selected];

            //добавление пробелов относительно уровня ячейки; не работает \t
            for (int i = 0; i < CountParents(cell); i++) data += "    ";

            SaveCellData(dataGridView);
            dataGridView.CurrentCell.Value = data + cell._data;
        }

        public static void SaveCellData(DataGridView dataGridView)
        {
            int selected = dataGridView.CurrentCell.RowIndex;
            CustomCell cell = displayedCells[selected];

            if (dataGridView.CurrentCell.Value == null)
            {
                MessageBox.Show("String cannot be 0 caracters long");
                return;
            }

            if (cell._parent != null)
            {
                int cellIndex = cell._parent._dependentCells.IndexOf(cell);
                cell._parent._dependentCells[cellIndex]._data = dataGridView.CurrentCell.Value.ToString();
            }
            else cell._data = dataGridView.CurrentCell.Value.ToString();
        }

        public static string CellValue(int selected)
        {
            return displayedCells[selected]._data;
        }

        public static Enum CellWhatInfoStored(int selected)
        {
            return displayedCells[selected]._whatInfoStored;
        }
    }
}