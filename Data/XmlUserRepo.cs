using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using RestAPI.Models;

namespace RestAPI.Data
{
    public class XmlUserRepo : IUserRepo
    {
        private readonly List<User> usersList;
        public XmlUserRepo()
        {
            usersList = GetAllUsers().ToList();
        }
        public User GetUserById(int id)
        {
            User user;

            user = usersList.Find(u => u.Id == id);

            return user;
        }

        public IEnumerable<User> GetAllUsers()
        {
            string encoding = "UTF-8";
            XDocument xDocument;
            XmlDocument xmlDoc = new XmlDocument();
            
            xmlDoc.LoadXml(File.ReadAllText("Xml/data.xml", Encoding.GetEncoding(encoding)));
            xDocument = xmlDoc.ToXDocument();

            List<User> usersItems = xDocument.Elements("items").Elements("item").Select(item => new User {
                Id = (int)item.Element("id"),
                GuId = (String)item.Element("guid")
            }).ToList();

            return usersItems;
        }

        public IEnumerable<string> GetUsers(string[] usersId)
        {
            List<string> usersGuId = new List<string>();
            User user=null;

            foreach (string userId in usersId)
            {
                try
                {
                    user = GetUserById(Int32.Parse(userId));
                }
                catch (Exception)
                {
                    return null;
                }

                if (user!=null)
                    usersGuId.Add(user.GuId);
                else
                    usersGuId.Add("");
            }
            return usersGuId;
        }
    }
    public static class DocumentExtensions
    {
        public static XmlDocument ToXmlDocument(this XDocument xDocument)
        {
            var xmlDocument = new XmlDocument();
            using (var xmlReader = xDocument.CreateReader())
            {
                xmlDocument.Load(xmlReader);
            }
            return xmlDocument;
        }

        public static XDocument ToXDocument(this XmlDocument xmlDocument)
        {
            using (var nodeReader = new XmlNodeReader(xmlDocument))
            {
                nodeReader.MoveToContent();
                return XDocument.Load(nodeReader);
            }
        }
    }
}
