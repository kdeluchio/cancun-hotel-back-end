# Cancun Hotel System Reservation
 System used by customers to book unoccupied rooms.
 Furthermore, it is possible to create a profile, make a reservation, list my reservations and cancel a reservation.

# Back-end Techinical Specification 

### Environment 
Visual Studio 2019, .Net Core 3, language C#, ORM Entity Framework Core 3.1, Microsoft Sql Server Express Database, Mapper, DDD and Swagger for api documentation.

### Check these steps before instalation
1 - In the CancunHotel.WebApi project open appsetings.json file and change database string connection configuration; </br>
2 - In my environment the connection property of the string "Integrated Security" was set to True but if you don't use windows authentication, set False; </br>
3 - In the CancunHotel.Data project, repeat steps 1 and 2 as well;</br>
4 - Open dotnet terminal and select project folder called "CancunHotel.Data";</br>
5 - In this folder execute the command "dotnet ef database update" to create database;</br>
6 - If the step 5 failed, you may need to install ef tools then run this command "dotnet tool install --global dotnet-ef --version 5.0.0 " ;</br>
7 - Play.</br>
