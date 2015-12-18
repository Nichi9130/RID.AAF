# TSH.Dev.AAF
WPF application to mimic functionality found in AAF environment. Allow verified active directory users to perform CRUD operations 
on application configurations - TSH.Dev

Requirements :

High Level:
- Create a WPF application which will help verified user Create, Update and Delete Application configuration items.

Application Level:
- Create a new application
- Delete an application
- Update name of existing application
- Track user Id that has performed operations on application

Configuration Level:
- Create new configuration item
- Delete new configuration item
- Update existing configuration item
- Create configuration based on JSON file import
- Create configuration based on XML file import
- Track user Id that has performed operations on application

XML/JSON file will contain Application name, and if application doesn't exist in DB..
  - create a new application and import configuration for newly created application
