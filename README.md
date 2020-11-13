# Rocket_Elevators_REST

This repo contains all the code for the RESTful API in .NET Core from Week 8 of Odyssey.

  

    The URL for this API deployed on Azure is :

 - [ ] https://apirocketelevators.azurewebsites.net

A REST Api

In order to connect our information system to the equipment in operation throughout the territory served, we first need to develop a REST API using C # and .NET Core. It will allow us to know and to manipulate the status of all the relevant entities of the operational database.

  

 



> Retrieving the current status of a specific Battery Changing the
> status of a specific Battery

 - To retrieve the status of a specific battery, add
   `/api/battery/(Battery ID)`
   
 - To change the status of a specific battery, run the following in
   PostMan
    **{
    "id": 1,
    "status": "Innactive"
    }**
Where you put the ID of the Battery to modify, and the new status to give it.


> Retrieving the current status of a specific Column Changing the status
> of a specific Column

 

- To retrieve the status of a specific column, add 
`/api/column/(Column ID)`
 to the API URL
 - To change the status of a specific column, run the following in
   PostMan
**{
    "id": 1,
    "status": "Innactive"
    }**
Where you put the ID of the Column to modify, and the new status to give it.
  

> Retrieving the current status of a specific Elevator Changing the
> status of a specific Elevator

 - To retrieve the status of a specific elevator, add
   `/api/elevator/(Elevator ID)`
    to the API URL
 - To change the status of a specific elevator, run the following in
   PostMan
**{
    "id": 1,
    "status": "Innactive"
    }**
Where you put the ID of the Elevator to modify, and the new status to give it.
  

> Retrieving a list of Elevators that are not in operation at the time
> of the request

 - To retrieve this list, add 
`/api/elevator/inoperational`
 to the API URL
  

> Retrieving a list of Buildings that contain at least one battery,
> column or elevator requiring intervention

 - To retrieve this list, add 
 `/api/building/intervention`
 to the API URL
  

> Retrieving a list of Leads created in the last 30 days who have not   
> yet become customers.

 - To retrieve this list, add
 `/api/lead/noncustomers`
   to the API URL