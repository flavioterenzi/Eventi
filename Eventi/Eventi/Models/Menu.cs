using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventi.Models
{
    internal class Menu
    {

        private static Menu istanza;
        public static  Menu GetIstanza()
        {
            if (istanza == null)
            {
                istanza = new Menu();
            }
            return istanza;
        }




    }
}
