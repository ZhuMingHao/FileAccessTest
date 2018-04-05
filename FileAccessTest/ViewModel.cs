using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAccessTest
{
    public class ViewModel
    {
        private DateTime? nullableDate;

        public DateTime? NullableDate
        {
            get { return nullableDate; }
            set
            {
                nullableDate = value;
            }
        }
        public ViewModel()
        {
            nullableDate = DateTime.Now;
        }
    }
}
