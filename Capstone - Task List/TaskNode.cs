using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone___Task_List
{
    class TaskNode
    {
        // fields
        private string _memberName;
        private string _description;
        private string _dueDate;
        private bool _complete;

        // properties
        public string MemberName { get { return _memberName; } set { _memberName = value; } }
        public string Description { get { return _description; } set { _description = value; } }
        public string DueDate { get { return _dueDate; } set { _dueDate = value; } }
        public bool Complete { get { return _complete; } set { _complete = value; } }

        //constructor
        public TaskNode(string memberName, string description, string dueDate)
        {
            this._memberName = memberName;
            this._description = description;
            this._dueDate = dueDate;
            this._complete = false;
        }

        public string Display()
        {
            string status = "INCOMPLETE";
            if (this._complete == true)
            {
                status = "COMPLETE";
            }

            return "Team Member Name: \t" + this._memberName
                + "\nTask Description: \t" + this._description
                + "\nDue Date: \t\t" + this._dueDate
                + "\nTask Status: \t\t" + status;
        }

        public void ChangeToComplete()
        {
            this._complete = true;
        }

        public void EditContents(string memberName, string description, string dueDate)
        {
            this._memberName = memberName;
            this._description = description;
            this._dueDate = dueDate;            
        }

    }
}
