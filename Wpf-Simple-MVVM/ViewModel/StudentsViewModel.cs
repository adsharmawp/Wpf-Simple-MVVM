using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf_Simple_MVVM.Model;
using Wpf_Simple_MVVM.MVVMBase;

namespace Wpf_Simple_MVVM.ViewModel
{
    public class StudentsViewModel : ViewModelBase
    {
        public ObservableCollection<Student> StudentList { get; set; }
        public ICommand UpdateStudentNameCommand { get; set; }
        public string SelectedStudentName { get; set; }

        public StudentsViewModel()
        {
            UpdateStudentNameCommand = new RelayCommand<Student>(SelectedStudentDetails);
            StudentList = new ObservableCollection<Student>();
            StudentList.Add(new Student() { Name = "Rohit" });
            StudentList.Add(new Student() { Name = "Vinay" });
            StudentList.Add(new Student() { Name = "Mohak" });
            StudentList.Add(new Student() { Name = "Raman" });
        }

        private void SelectedStudentDetails(Student obj)
        {
            if (obj != null)
            {
                this.SelectedStudentName = obj.Name;
                // better to go for full property instead of calling property change here 
                this.RaisePropertyChanged("SelectedStudentName");
            }
        }
    }
}
