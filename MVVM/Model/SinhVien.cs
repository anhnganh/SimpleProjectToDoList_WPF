using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class SinhVien
    {
       
            private int id;
            private string ten;

            public int Id { get => id; set => id = value; }
            public string Ten { get => ten; set => ten = value; }

        public static implicit operator string(SinhVien v)
        {
            throw new NotImplementedException();
        }
    }
}
