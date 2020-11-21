using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IO_GRA_graczChodzenieGrafika
{
    

    public class BMB_Input
    {

        public Dictionary<string, bool> buttons = new Dictionary<string, bool>();

        

        public BMB_Input()
        {
            this.buttons.Add("W", false);
            this.buttons.Add("S", false);
            this.buttons.Add("A", false);
            this.buttons.Add("D", false);

            

        }

        public BMB_Input(BMB_Input toCopy)
        {
            foreach (var button in toCopy.buttons)
            {
                this.buttons.Add(button.Key, button.Value);
            }
        }




    }
}
