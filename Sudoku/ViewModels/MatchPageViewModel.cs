using Sudoku.Command;
using Sudoku.Resources;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Sudoku.ViewModels
{
    public class MatchPageViewModel : Notifier
    {
        #region Properties
        #region SudokuTableView
        public DataView SudokuTableView
        {
            get
            {
                return sudokuTableView;
            }
            set
            {
                sudokuTableView = value;
                OnPropertyChanged("SudokuTableView");
            }
        }

        private DataView sudokuTableView;
        #endregion

        #region SelectedCell
        public DataGridCellInfo SelectedCell
        {
            get
            {
                return selectedCell;
            }
            set
            {
                selectedCell = value;
                OnPropertyChanged("SelectedCell");
            }
        }

        private DataGridCellInfo selectedCell;

        #endregion

        #region MoveOutputMessage
        private Message moveOutputMessage;

        public Message MoveOutputMessage
        {
            get
            {
                return moveOutputMessage;
            }
            set
            {
                moveOutputMessage = value;
                OnPropertyChanged("MoveOutputMessage");
            }
        }
        #endregion

        #endregion

        #region Commands

        public ICommand DataGrid_CellEditEndingCommand
        {
            get
            {
                return new DelegateCommand(ConfirmEdit);
            }
        }

        #endregion
        public MatchPageViewModel()
        {
            int[][] mat =
            {
                new int [] {5,3,4,6,7,8,9,1,2},
                new int [] {6,7,2,1,9,5,3,4,8},
                new int [] {1,9,8,3,4,2,5,6,7},
                new int [] {8,5,9,7,6,1,4,2,3},
                new int [] {4,2,6,8,5,3,7,9,1},
                new int [] {7,1,3,9,2,4,8,5,6},
                new int [] {9,6,1,5,3,7,2,8,4},
                new int [] {2,8,7,4,1,9,6,3,5},
                new int [] {3,4,5,2,8,6,1,7,9}
            };

            SudokuTableView = ConvertMatToDataTable(mat, 9, 9).AsDataView();

            //Debug.WriteLine("Esito matrice:" + Rules.IsSudokuValid(mat, 9, 9));
        }

        private DataTable ConvertMatToDataTable(int[][] mat, int rows, int columns)
        {
            DataTable sudokuTable = new DataTable();
            //add columns
            for (int i = 0; i < columns; i++)
                sudokuTable.Columns.Add(new DataColumn(i.ToString()));

            for (int i = 0; i < rows; i++)
            {
                var newRow = sudokuTable.NewRow();
                for (int j = 0; j < columns; j++)
                    newRow[j.ToString()] = mat[i][j];
                sudokuTable.Rows.Add(newRow);
            }

            return sudokuTable;
        }

        private int[][] ConvertDataTableToMat(DataTable dt)
        {

            return null;
        }

        //everytime the cell edit has ended, check if it's correct
        private void ConfirmEdit()
        {
            int columnIndex = SelectedCell.Column.DisplayIndex;
            DataRow row = (SelectedCell.Item as DataRowView).Row;
            int rowIndex = SudokuTableView.Table.Rows.IndexOf(row);
            string element = (string)row.ItemArray.ElementAt(columnIndex);
            //check that it's a number
            bool isNumeric = int.TryParse(element, out int value);
            if (!isNumeric || value < 1 || value > 9)
            {
                MoveOutputMessage = new Message("Inserito un valore non valido", "Red");
                //put back the old value
                row[columnIndex] = " ";
            }
        }
    }
}
