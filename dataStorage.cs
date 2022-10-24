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


        //NEW CODE ABOVE

        public string moduleName { get; set; }
        public string moduleCode { get; set; }
        public int credits { get; set; }
        public double hours { get; set; }

        

        //constructor

        public dataStorage(string moduleName,
                    string moduleCode,
                    int credits,
                    double hours)
        { 
            this.moduleName = moduleName;
            this.moduleCode = moduleCode;
            this.credits = credits;
            this.hours = hours;
        }
        
        
        public override string ToString()
        {
            string Output = string.Format("MODULE NAME: " + "\t" + "MODULE CODE: " + "\t" + "SELF STUDY: " + "\n" +
                                          "*************************************************************" + "\n" +
                                          moduleName + "\t" + "\t" + moduleCode + "\t" + "\t" + hours );
            return Output;
        } 
        

    }
}
