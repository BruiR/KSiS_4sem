using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class OnlineListboxHandler
    {

        public void UpdatePeople(MainForm mainForm, string str)
        {
            string[] people = str.Split(":".ToCharArray());
            mainForm.UpdatePeopleListbox(people);
        }
        public void RemoveHuman(MainForm mainForm, string str)
        {
            mainForm.RemoveHumanFromListbox(str);
        }
        public void AddHuman(MainForm mainForm, string str)
        {
            mainForm.AddHumanToListbox(str);
        }
        

    }

}
