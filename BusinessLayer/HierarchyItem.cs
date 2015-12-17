﻿using System;
using System.Collections.Generic;
using System.Data;
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
            //todo (Check self) 

            //todo (Check children)
            return true;
        }

        private void BuildHierarchicalData()
        {
            // todo implement logic
        }
    }
}