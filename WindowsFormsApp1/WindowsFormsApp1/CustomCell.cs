using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

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

        //я не знаю правильно ли это но оно работает
        private static List<CustomCell> displayedCells = new List<CustomCell>();

        public CustomCell(string data, CustomCell parent)
        {
            _data = data;
            _parent = parent;
        }

        public static void AddNewCellOnTop(DataGridView dataGridView, string data, Enum whatInfoStored)
        {
            CustomCell cell = new CustomCell(data, null);
            displayedCells.Add(cell);
            dataGridView.Rows.Add(cell._data);
            cell._isShown = true;
            cell._whatInfoStored = whatInfoStored;
        }

        public static void NewDependenceHandler(string data, Enum whatInfoStored, CustomCell cell)
        {
            CustomCell newCell = new CustomCell(data, cell);
            cell._dependentCells.Add(newCell);
            newCell._whatInfoStored = whatInfoStored;
        }

        //надо как-нибудь исправить эту дичь с перегрузками

        //для добавления новой пустой зависимости
        public static void NewDependence(int selected, Enum whatInfoStored)
        {
            CustomCell cell = displayedCells[selected];
            NewDependenceHandler("-----", whatInfoStored, cell);
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

        public static void OpenCell(int selected, DataGridView dataGridView)
        {
            CustomCell cell = displayedCells[selected];
            if (cell._dependentCells.Count == 0) return;

            //открытие и закрытие ячейки (попеременно)
            if (!cell._isOpen)
            {
                foreach (CustomCell c in cell._dependentCells)
                {
                    DataGridViewRow newRow = new DataGridViewRow();
                    newRow.CreateCells(dataGridView);

                    //для показа на каком уровне находится ячейка через пробелы; не работает \t
                    for (int i = 0; i < CountParents(c); i++) newRow.Cells[0].Value += "    ";

                    newRow.Cells[0].Value += c._data;
                    dataGridView.Rows.Insert(selected + 1, newRow);
                    displayedCells.Insert(selected + 1, c);
                    c._isShown = true;

                    //запрет на редактирование ячеек name, card, birth, age
                    if (c._whatInfoStored.ToString() == "enum_name" || c._whatInfoStored.ToString() == "enum_other") newRow.ReadOnly = false;
                    else newRow.ReadOnly = true;
                }
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
                    }
                    //end

                    if (current._dependentCells == null) continue;
                    foreach (CustomCell c in current._dependentCells) queue.Enqueue(c);
                }
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
    }
}