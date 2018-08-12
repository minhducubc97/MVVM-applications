using GalaSoft.MvvmLight;
using AccessDTBCommunication.Model;
using System.Data;
using System.Data.OleDb;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;
using System.Windows.Input;
using System;
using System.Collections.Generic;

namespace AccessDTBCommunication.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IDataService dataService)
        {
            InitializeVariable();
            InitializeConnection();
        }

        private void InitializeVariable()
        {
            StudentTable = new DataGrid
            {
                AutoGenerateColumns = true,
                SelectionMode = DataGridSelectionMode.Single,
                FontSize = 13,
                Padding = new Thickness(5),
                Background = Brushes.White,
                Width = 310
            };
            AddRow = new RelayCommand(AddRowMethod);
            EditRow = new RelayCommand(EditRowMethod);
            DeleteRow = new RelayCommand(DeleteRowMethod);
            ClearInfo = new RelayCommand(ClearInfoMethod);
            IsIDEnabled = true;
            StudentGenderIndex = -1;
            AddButtonContent = "Add";
        }

        /// <summary>
        /// Add row into the StudentTable
        /// </summary>
        /// <param name="sender"></param>
        private void AddRowMethod(object sender)
        {
            // command that control the connection and table, needed to be initialize every time developer uses command
            OleDbCommand cmd = new OleDbCommand();
            if (theConnection.State != ConnectionState.Open)
            {
                theConnection.Open();
            }
            cmd.Connection = theConnection;

            if (!StudentID.Equals(""))
            {
                if (!StudentGenderOption.Equals(""))
                {
                    if (IsIDEnabled)
                    {
                        cmd.CommandText = "INSERT INTO " + TABLENAME + " (ID, StudentName, Gender, Contact, Address) values (" + StudentID + ",'" + StudentName + "','" + StudentGenderOption + "','" + StudentContact + "','" + StudentAddress + "')";
                        cmd.ExecuteNonQuery();
                        BindGrid();
                        MessageBox.Show("Student information added successfully!");
                        RemoveAllInfo();
                    }
                    else // IsIDEnabled is false only when in Edit mode => Update the value to the selected row
                    {
                        cmd.CommandText = "UPDATE " + TABLENAME + " SET StudentName='" + StudentName + "', Gender='" + StudentGenderOption + "', Contact=" + StudentContact + ", Address='" + StudentAddress + "' where ID=" + StudentID;
                        cmd.ExecuteNonQuery();
                        BindGrid();
                        MessageBox.Show("Student information updated successfully!");
                        AddButtonContent = "Add";
                    }
                }
                else //
                {
                    MessageBox.Show("Please select gender!");
                }
            }
            else
            {
                MessageBox.Show("Please enter student ID");
            }
        }

        private void RemoveAllInfo()
        {
            StudentID = "";
            StudentName = "";
            StudentGenderIndex = -1;
            StudentContact = "";
            StudentAddress = "";
            IsIDEnabled = true;
        }

        /// <summary>
        /// Add row into the StudentTable
        /// </summary>
        /// <param name="sender"></param>
        private void EditRowMethod(object sender)
        {
            if (StudentTable.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)StudentTable.SelectedItems[0];
                StudentID = row["ID"].ToString();
                StudentName = row["StudentName"].ToString();
                string tmpGender = row["Gender"].ToString();
                if (tmpGender.Equals("Male"))
                {
                    StudentGenderIndex = 0;
                }
                else if (tmpGender.Equals("Female"))
                {
                    StudentGenderIndex = 1;
                }
                else
                {
                    StudentGenderIndex = 2;
                }
                StudentContact = row["Contact"].ToString();
                StudentAddress = row["Address"].ToString();
                IsIDEnabled = false;
                AddButtonContent = "Update";
            }
            else
            {
                MessageBox.Show("Please select the row from the table below to edit!");
            }
        }

        /// <summary>
        /// Add row into the StudentTable
        /// </summary>
        /// <param name="sender"></param>
        private void DeleteRowMethod(object sender)
        {
            if (StudentTable.SelectedItems.Count > 0)
            {
                DataRowView row = (DataRowView)StudentTable.SelectedItems[0];

                // command that control the connection and table, needed to be initialize every time developer uses command
                OleDbCommand cmd = new OleDbCommand();
                if (theConnection.State != ConnectionState.Open)
                {
                    theConnection.Open();
                }
                cmd.Connection = theConnection;

                cmd.CommandText = "DELETE FROM " + TABLENAME + " where Id=" + row["ID"].ToString();
                cmd.ExecuteNonQuery();
                BindGrid();
                MessageBox.Show("Removed the selected row from the data table!");
                RemoveAllInfo();
            }
            else
            {
                MessageBox.Show("Please select the row to delete!");
            }
        }

        /// <summary>
        /// Add row into the StudentTable
        /// </summary>
        /// <param name="sender"></param>
        private void ClearInfoMethod(object sender)
        {
            RemoveAllInfo();
        }

        /// <summary>
        /// Initialize connection to database.
        /// </summary>
        private void InitializeConnection()
        {
            theConnection = new OleDbConnection();
            // NOTE: it gets tricky here since you need to select the correct version of Access and Microsoft support for Connection String. For my case, I have Access 2016, so the provider will be Microsoft.ACE.OLEDB.12.0. Also, set the build configuration to the appropriate system, for my case, x64 instead of Any CPU.
            theConnection.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + FILENAME;
            BindGrid();
        }

        /// <summary>
        /// Start binding data to the View.
        /// </summary>
        private void BindGrid()
        {
            // command that control the connection and table, needed to be initialize every time developer uses command
            OleDbCommand cmd = new OleDbCommand();
            if (theConnection.State != ConnectionState.Open)
            {
                theConnection.Open();
            }
            cmd.Connection = theConnection;

            // select all data from the table
            cmd.CommandText = "SELECT * FROM " + TABLENAME;

            // execute the command onto the dataTable (fill all the data onto dataTable)
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            // populate the StudentTable in View with data
            StudentTable.ItemsSource = dataTable.AsDataView();
            if (dataTable.Rows.Count > 0)
            {
                TableVisibility = "Visible";
                ErrorVisibility = "Collapsed";
            }
            else
            {
                TableVisibility = "Collapsed";
                ErrorVisibility = "Visible";
            }
        }

        /// <summary>
        /// Variables.
        /// </summary>
        OleDbConnection theConnection;
        DataTable dataTable;
        private const string FILENAME = "SampleDatabase.accdb";
        private const string TABLENAME = "tableStudentInfo";

        /// <summary>
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        /// 
        private DataGrid _studentTable;
        public DataGrid StudentTable
        {
            get
            {
                return _studentTable;
            }
            set
            {
                _studentTable = value;
                RaisePropertyChanged("StudentTable");
            }
        }

        private string _errorVisibility;
        public string ErrorVisibility
        {
            get
            {
                return _errorVisibility;
            }
            set
            {
                _errorVisibility = value;
                RaisePropertyChanged("ErrorVisibility");
            }
        }

        private string _tableVisibility;
        public string TableVisibility
        {
            get
            {
                return _tableVisibility;
            }
            set
            {
                _tableVisibility = value;
                RaisePropertyChanged("TableVisibility");
            }
        }

        private ICommand _addRow;
        public ICommand AddRow
        {
            get
            {
                return _addRow;
            }
            set
            {
                _addRow = value;
                RaisePropertyChanged("AddRow");
            }
        }

        private ICommand _editRow;
        public ICommand EditRow
        {
            get
            {
                return _editRow;
            }
            set
            {
                _editRow = value;
                RaisePropertyChanged("EditRow");
            }
        }

        private ICommand _deleteRow;
        public ICommand DeleteRow
        {
            get
            {
                return _deleteRow;
            }
            set
            {
                _deleteRow = value;
                RaisePropertyChanged("DeleteRow");
            }
        }

        private ICommand _clearInfo;
        public ICommand ClearInfo
        {
            get
            {
                return _clearInfo;
            }
            set
            {
                _clearInfo = value;
                RaisePropertyChanged("ClearInfo");
            }
        }

        private bool _isIDEnabled;
        public bool IsIDEnabled
        {
            get
            {
                return _isIDEnabled;
            }
            set
            {
                _isIDEnabled = value;
                RaisePropertyChanged("IsIDEnabled");
            }
        }

        private string _studentID;
        public string StudentID
        {
            get
            {
                return _studentID;
            }
            set
            {
                _studentID = value;
                RaisePropertyChanged("StudentID");
            }
        }

        private string _studentName;
        public string StudentName
        {
            get
            {
                return _studentName;
            }
            set
            {
                _studentName = value;
                RaisePropertyChanged("StudentName");
            }
        }

        private string _studentGenderOption;
        public string StudentGenderOption
        {
            get
            {
                if (StudentGenderIndex == 0)
                {
                    return "Male";
                }
                else if (StudentGenderIndex == 1)
                {
                    return "Female";
                }
                else
                {
                    return "Others";
                }
            }
        }

        private string _studentContact;
        public string StudentContact
        {
            get
            {
                return _studentContact;
            }
            set
            {
                _studentContact = value;
                RaisePropertyChanged("StudentContact");
            }
        }

        private string _studentAddress;
        public string StudentAddress
        {
            get
            {
                return _studentAddress;
            }
            set
            {
                _studentAddress = value;
                RaisePropertyChanged("StudentAddress");
            }
        }

        private int _studentGenderIndex;
        public int StudentGenderIndex
        {
            get
            {
                return _studentGenderIndex;
            }
            set
            {
                _studentGenderIndex = value;
                RaisePropertyChanged("StudentGenderIndex");
            }
        }

        private string _addButtonContent;
        public string AddButtonContent
        {
            get
            {
                return _addButtonContent;
            }
            set
            {
                _addButtonContent = value;
                RaisePropertyChanged("AddButtonContent");
            }
        }

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}