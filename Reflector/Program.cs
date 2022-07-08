using RFC.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflector
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<object> Obj = new List<object>();
            CloneAtr clone = new CloneAtr();
            var classes = clone.GetClasses();
            Console.WriteLine("our attribute has " + classes.Count() + " class");
            foreach (var type in classes)
            {
                var isPublic = type.IsPublic;
                var members = type.GetMembers();
                Console.WriteLine("class with Name " + type.Name + " wich is " + type.GetType().Name + (isPublic == true ? " public class " : "nonPublic class") + "and it has " + members.Count() + " members ; our class is a child of " + type.BaseType.Name );
                GetFields(type);
                GetMethodes(type);
                GetInterfaces(type);
                GetProperties(type);
                var c = type.GetTypeInfo();
                var model = c.AsType();
                
                Console.WriteLine(c);
                var fullStatus = type.UnderlyingSystemType;

                object result = Activator.CreateInstance(type);
                Obj.Add(result);
                Console.WriteLine("-------------------+");
            }
            Console.ReadKey();
            Console.WriteLine(Obj);
        }
        public static void GetFields(Type type)
        {
            var fields = type.GetFields();
            if (fields.Count() > 0)
            {
                int counter = 1;
                Console.WriteLine(" it has " + fields.Count() + " fields :");
                foreach (var item in fields)
                {
                    Console.Write(counter++ + "-");
                    Console.Write("type :" + item.FieldType);
                    Console.WriteLine(" name :" + item.Name);
                }
                Console.WriteLine("---And---");
            }
        }
        public static void GetMethodes(Type type)
        {
            var methodes = type.GetMethods();
            if (methodes.Count() > 0)
            {
                int counter = 1;
                Console.WriteLine(" it has " + methodes.Count() + " methodes:");
                foreach (var item in methodes)
                {
                    Console.Write(counter++ + "-");
                    Console.Write("methode name :" + item.Name);
                    Console.WriteLine(" wich returns " + item.ReturnType);
                    GetMethodeParameters(item);
                }
                Console.WriteLine("---And---");
            }
        }
        public static void GetInterfaces(Type type)
        {
            var interfaces = type.GetInterfaces();
            if (interfaces.Count() > 0)
            {
                int counter = 1;
                Console.WriteLine(" it has " + interfaces.Count() + " interfaces:");
                foreach (var item in interfaces)
                {
                    Console.Write(counter++ + "-");
                    Console.Write(item.Name);
                    Console.WriteLine(" wich has " + item.GetMembers().Count() + " members");
                }
                Console.WriteLine("---And---");
            }
        }
        public static void GetProperties(Type type)
        {
            var properties = type.GetProperties();
            if (properties.Count() > 0)
            {
                int counter = 1;
                Console.WriteLine("it has " + properties.Count() + " properties:");
                foreach (var item in properties)
                {
                    Console.Write(counter++ + "-");
                    Console.Write(item.Name);
                    if (item.CanWrite)
                        Console.Write(" wich can be writed ");
                    else
                        Console.Write(" wich can not be writed ");
                    if (item.CanRead)
                        Console.WriteLine(" and is readable");
                    else
                        Console.WriteLine(" and is not readable");
                }
            }
        }
        public static void GetMethodeParameters(MethodInfo method)
        {
            var parameters = method.GetParameters();
            if (parameters.Count() > 0)
            {
                int counter = 1;
                Console.WriteLine("and this method needs " + parameters.Count() + " parameters :");
                foreach (var item in parameters.OrderBy(i => i.Position))
                {
                    Console.Write(counter++ + "-");
                    Console.Write("type: " + item.ParameterType);
                    Console.WriteLine("name: " + item.Name);
                }
            }
        }
    }
}
