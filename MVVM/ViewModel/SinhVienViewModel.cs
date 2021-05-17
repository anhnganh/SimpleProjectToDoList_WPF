using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Controls;
using System.Windows.Input;

namespace ViewModel
{
  public  class SinhVienViewModel
    {
        private ObservableCollection<SinhVien> listSinhVien;
        public ObservableCollection<SinhVien> ListSinhVien { get => listSinhVien; set => listSinhVien = value; }
        public SinhVienViewModel()
        {
            listSinhVien = new ObservableCollection<SinhVien>();
            ListSinhVien.Add(new SinhVien() { Id = 1, Ten = "Anh" });
            ListSinhVien.Add(new SinhVien() { Id = 2, Ten = "Binh" });
            ListSinhVien.Add(new SinhVien() { Id = 3, Ten = "Cuong" });
            ListSinhVien.Add(new SinhVien() { Id = 4, Ten = "Duong" });

            DeleteCommand = new RelayCommand<SinhVien>(
                (p) => p != null, // CanExecute()
             (p) => { 
                 ListSinhVien.Remove(p as SinhVien); }
             // Execute()
                );
            AddCommand = new RelayCommand<UIElementCollection>(
           (s) => true, // CanExecute()
           (s) => {
               int id = 0;
               string ten = "";
               bool isIDint = false;
               foreach (var item in s)
               {
                   TextBox textBox = item as TextBox;
                   if (textBox == null)
                   
                       continue;
                   
                   switch (textBox.Name)
                   {
                       case "txbId":
                           isIDint = Int32.TryParse(textBox.Text, out id);
                           break;
                       case "txbTen":
                           ten = textBox.Text;
                           break;
                   }

               }
               if(!isIDint || string.IsNullOrEmpty(ten))
               {
                   return;
               }
               SinhVien a = new SinhVien() {Id= id, Ten =ten };
               ListSinhVien.Add(a);
           } // Execute()
           );
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand AddCommand { get; set; }

    }
   
}

