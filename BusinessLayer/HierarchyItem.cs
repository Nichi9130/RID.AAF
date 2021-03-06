﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using BusinessLayer.Models;

namespace BusinessLayer
{
    public class HierarchyItem
    {

        public ApplicationConfigurationModel Configuration { get; set; }
        public XElement HierarchicalData { get; set; }
        public List<ApplicationConfigurationModel> AppConfigModelDataList { get; set; }
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }

        public DataTable DataTable = new DataTable();

        public XElement CreateHierarchalData(DataTable datTable)
        {
            InitalizeDataList(DataTable);
            BuildHierarchicalData();

            return HierarchicalData;
        }


        private void InitalizeDataList(DataTable dataTable)
        {
            AppConfigModelDataList = new List<ApplicationConfigurationModel>();
            
            foreach (DataRow row in DataTable.Rows)
            {
                AppConfigModelDataList.Add( new ApplicationConfigurationModel
                {
                    Id = row["Id"].ToString(),
                    ParentId = row["ParentId"].ToString(),
                    Name = row["Name"].ToString(),
                    Value = row["Value"].ToString()
                });
            }
        }

        private bool XElementExistsByAtribute(XElement root, string attributeName, string attributeValue)
        {
            // Check self
            if (root.Attributes().Any(e => (e.Name == attributeName && e.Value == attributeValue)))
            {
                return true;
            }

            //Check children
            foreach (XElement item in root.Descendants())
            {
               if (item.Attributes().Any(e =>(e.Name == attributeName && e.Value == attributeValue)))
                
                   return true;
                
            }
            return false;
        }

          private void BuildHierarchicalData()
        {
            // todo implement logic
              HierarchicalData = new XElement("root", new XAttribute("id", "0"));

              foreach (var item in AppConfigModelDataList)
              {
                  if (!XElementExistsByAtribute( HierarchicalData, "id", item.Id.ToString(CultureInfo.InvariantCulture)))
                  {
                      if (item.Value == String.Empty)
                      {
                          var newElementWithNull = new XElement(item.Name, new XAttribute("id", item.Id));
                          BuildElement(newElementWithNull, item);
                      }
                      else
                      {
                          var newElement = new XElement(item.Name, item.Value, new XAttribute("id", item.Id));
                          BuildElement(newElement, item);
                      }
                  }
              }
        }

        private void BuildElement(XElement element, ApplicationConfigurationModel item)
        {
            // Does the parent exist?
            if (!XElementExistsByAtribute(HierarchicalData, "id", item.ParentId.ToString(CultureInfo.InvariantCulture)))
            {
                // Build the parent Element
                ApplicationConfigurationModel parentElement =
                    AppConfigModelDataList.Where(db => db.Id == item.ParentId).Select(db => db).FirstOrDefault();
                if (parentElement != null)
                {
                    var newElement = new XElement(parentElement.Name,new XAttribute("id", parentElement.Id));
                   // todo 'Research Recursion for control flow structures' - TSH.DEV
                    BuildElement(newElement, parentElement);
                }
                AddToHierarchicalData(HierarchicalData, element, item.ParentId);
            }
        }

          private void AddToHierarchicalData(XElement root, XElement newItem, string parentId)
          {
              
              // validate root has value, then add parent
              if (root.HasElements)
              root.Add(newItem);

              // root not empty, find parents and add
              foreach (var descendant in root.Descendants())
              {
                  if (descendant.Attributes().Any(db => (db.Name == "id" && db.Value == parentId)))
                  descendant.Add(newItem);
              }
          }
    }
}
