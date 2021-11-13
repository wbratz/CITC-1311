using System;
using System.Collections.Generic;

namespace SafeApp
{
    public class Safe
    {
        private readonly SafeEventReceiver _receiver;
        private bool isOpen = false;
        private string accessCode;
        private int shelves;
        private int height;
        private int width;
        private int depth;
        private List<string> contents = new List<string>();
        private readonly string _name;

        public Safe(string code,
                    int height,
                    int width,
                    int depth,
                    SafeEventReceiver receiver)
        {
            accessCode = code;
            this.height = height;
            this.width = width;
            this.depth = depth;
            _receiver = receiver;
        }

        public Safe(string code,
                    int height,
                    int width,
                    int depth,
                    string name,
                    SafeEventReceiver receiver)
        {
            accessCode = code;
            this.height = height;
            this.width = width;
            this.depth = depth;
            _name = name;
            _receiver = receiver;
        }

        public int Shelves
        {
            get
            {
                return shelves;
            }
            set
            {
                if (value < 0)
                {
                    Console.WriteLine("Shelves cannot be less than zero.");
                    return;
                }

                shelves = value;
            }
        }

        public bool IsOpen { get { return isOpen; } private set { isOpen = value; } }
        public int Height { get { return height; } set { height = value; } }
        public int Width { get { return width; } set { width = value; } }
        public int Depth { get { return depth; } set { depth = value; } }
        public string Name { get { return _name; } }

        public void ChangeAccessCode(string currentCode, string newCode)
        {
            if (currentCode.Equals(accessCode))
            {
                HandleSuccessfulOperation("Changing access code on");
                accessCode = newCode;
            }
            else
            {
                IncorrectCode("access code change");
            }
        }

        public void OpenSafe(string code)
        {
            if (code.Equals(accessCode))
            {
                SafeOpenedEvent safeEvent = new SafeOpenedEvent 
                { 
                    DateTime = DateTime.Now,
                    Message = $"Safe: {_name} Opened using {code} access code"
                };

                _receiver.Receive(safeEvent);

                IsOpen = true;
            }
            else
            {
                SafeOpenedEvent safeEvent = new SafeOpenedEvent 
                { 
                    DateTime = DateTime.Now,
                    Message = $"*** WARNING! SAFE: {_name} OPEN ATTEMPT WITH INCORRECT ACCESS CODE: {code}***"
                };

                _receiver.Receive(safeEvent);

                IncorrectCode("open safe"); 
            }
        }

        public void CloseSafe()
        {
            if (isOpen)
            {
                HandleSuccessfulOperation("Closing the door on");
                isOpen = false;
                return;
            }

            //Why be consistent, right? Just doing the same thing two different ways
            HandleUnsuccessfulOperation("close", " is already closed");
        }

        public string ShowContents()
        {
            if (isOpen)
            {
                var contents = string.Empty;

                foreach (var item in contents)
                {
                    contents += $"{item}, ";
                }

                return contents;
            }

            return "You must open the safe before viewing its contents.";
        }

        public void AddContents(string item)
        {
            if (!isOpen)
            {
                HandleUnsuccessfulOperation($"add {item} to", " is not open");
            }

            HandleSuccessfulOperation($"Adding {item} to");

            ItemAddedEvent itemAdded = new ItemAddedEvent 
            {
                DateTime = DateTime.Now,
                Message = $"{item} was added to the safe."
            };

            _receiver.Receive(itemAdded);

            contents.Add(item);
        }

        public void RemoveContents(string item)
        {
            if (!isOpen)
            {
                HandleUnsuccessfulOperation($"remove {item} from", " is not open");
            }

            if (ItemExists(item))
            {
                ItemRemovedEvent itemAdded = new ItemRemovedEvent 
                {
                    DateTime = DateTime.Now,
                    Message = $"{item} was removed from the safe."
                };

                _receiver.Receive(itemAdded);

                HandleSuccessfulOperation($"Removing {item} from");
                contents.Remove(item);
            }
            else
            {
                HandleUnsuccessfulOperation($"remove {item} from", $" {item} does not exist in this safe");
            }
        }

        public override string ToString()
        {
            if (HasName())
            {
                return $"The safe, {Name}, is {width} wide, {height} tall, and {depth} deep. The contents are {ShowContents()}. The safe has {shelves} shelves. The safe {OpenStatus()}";
            }

            return $"The safe is {width} wide, {height} tall, and {depth} deep. The contents are {ShowContents()}. The safe has {shelves} shelves. The safe {OpenStatus()}";
        }

        private bool HasName()
        {
            return !string.IsNullOrEmpty(Name);
        }

        private bool ItemExists(string item)
        {
            foreach (var content in contents)
            {
                if (content.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        private string OpenStatus()
        {
            var returnString = HasName() ? Name : string.Empty;
            if (isOpen)
            {
                return returnString += " is open";
            }

            return returnString += " is closed";
        }

        private static void IncorrectCode(string operation)
        {
            Console.WriteLine($"Access code is incorrect, {operation} unsuccessful.");
        }

        private void HandleSuccessfulOperation(string operation)
        {
            var returnString = $"{operation}, the safe";
            NotifyOperation(returnString);
        }

        private void HandleUnsuccessfulOperation(string operation, string reason)
        {
            var returnString = $"Could not {operation}, the safe";
            NotifyOperation(returnString, reason);
        }

        private string NotifyOperation(string returnString, string reason = "")
        {
            if (HasName())
            {
                returnString += $", {Name}";
            }

            Console.WriteLine($"{returnString}{reason}.");
            return returnString;
        }
    }

}
