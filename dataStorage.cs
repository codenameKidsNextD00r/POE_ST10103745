using System;
using System.Collections.Generic;
using System.Text;

namespace POE_ST10103745
{
    internal class dataStorage
    //THIS CLASS WILL STORE ALL DATA RECEIVED FROM TEXTBOXES
    {
        /*public string[] input = new string [3]; 

        public string this[int i] 
        {
            get 
            { 
                return input[i];
            }

            set 
            { 
                input[i] = value;
            }
        }*/
        public string moduleName { get; set; }
        public string moduleCode { get; set; }
        public string credits { get; set; }
        public string hours { get; set; }

        //constructor
        public dataStorage(string moduleName,
                    string moduleCode,
                    string credits,
                    string hours)
        { 
            this.moduleName = moduleName;
            this.moduleCode = moduleCode;
            this.credits = credits;
            this.hours = hours;
        }

        public override string ToString()
        {
            string Output = string.Format("Module Name: {0}, Module Code: {1},  Credits: {2}, Hours: {3}", moduleName, moduleCode, credits, hours);
            return Output;
        }

    }
}
