namespace GraduationTracker
{
    using System;
    using System.Reflection;

    //Acts as a base-class for all classes that inherit and initializes all the properties to it's default values overcoming the problem of null-reference exceptions
    //reduces all future code as null checks are eliminated for any property and even Collections can add/remove items without the need for initializing them.
    public abstract class EntityBase
    {
        public EntityBase()
        {
            PropertyInfo[] properties = this.GetType().GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.SetMethod != null)
                {
                    switch (property.PropertyType.Name.ToString().ToLower())
                    {
                        case "int64":
                        case "int64?":
                        case "long":
                        case "long?":
                        case "decimal":
                        case "decimal?":
                        case "double":
                        case "double?":
                        case "float":
                        case "float?":
                        case "int":
                        case "int?":
                        case "int32":
                        case "int32?":
                        case "int16":
                        case "int16?":
                        case "real":
                            property.SetValue(this, Convert.ChangeType(0, property.PropertyType));
                            continue;
                        case "boolean":
                        case "bool":
                        case "bool?":
                            property.SetValue(this, Convert.ChangeType(false, property.PropertyType));
                            continue;
                        case "datetime":
                        case "datetime?":
                            property.SetValue(this, Convert.ChangeType(DateTime.Now, property.PropertyType));
                            continue;
                        case "char":
                            property.SetValue(this, Convert.ChangeType(char.MinValue, property.PropertyType));
                            continue;
                        case "string":
                            property.SetValue(this, Convert.ChangeType(string.Empty, property.PropertyType));
                            continue;
                        default: // Class Type      
                            property.SetValue(this, Convert.ChangeType(Activator.CreateInstance(property.PropertyType), property.PropertyType));
                            continue;
                    }
                }
            }
        }
    }
}