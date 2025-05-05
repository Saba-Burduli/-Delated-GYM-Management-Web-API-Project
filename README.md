

<h1> 💪 GYM Membership Web API</h1>


Using in ASP.NET Core Entity Framework (ORM) is most Popular and correct Practice for our Backend Projects.In This Project I'm gonna Create HTTP Controllers for API ofc. Also I'm gonna Use Some Security standart's Like General Data Protection Regulation (GDPR) And Also I'm gonna use Data Protection for our future Users.

For Security Main most Important Thing in Code is to Create Repository and Service Interfaces. Most Important methods for 
Secured is mostly:

<ul>
  <li>Payment()</li>
  <li>RegisterUser()</li>
  <li>SubscripitonInfo()</li>
  
</ul>

<h2> Here Is All Important Relations Between Entity Classes:</h2>

![Untitled](https://github.com/user-attachments/assets/a5017627-0859-4473-b5b2-f39b122cd888)

We gonna add and Create in IRepository Folder.Because If non ethical hacker trying to crack your program and functionality its easy to get in Service layer (Business Layer in API). So its Common Way to Implement this important mathods in Repository's Folder(In API Layer)





<br>
<br>





💡 Let's Talk about layers in my Project :

<ul>
  
  <li>API Layer</li>
  <li>SERVICE Layer</li>
  <li>DAL Layer</li>
  <li>DATA Layer</li>
  
</ul>

<br>

<h2>⬜ And Dive deeper in this Layers :</h2>

<ol>

 <h3><li>API Layer</li></h3> 
    <p>
      The **API layer** is responsible for handling **HTTP requests and responses** in an ASP.NET Web API project. It acts as the bridge between the client applications and the database.


    ### Key Responsibilities
    - **Routing Requests**: Maps incoming requests to the appropriate controller and action method.
    - **Data Processing**: Retrieves, processes, and returns data using Entity Framework.
    - **Validation & Authentication**: Ensures data integrity and security.
    - **Response Formatting**: Returns data in JSON or XML format for easy consumption.
    </p>

   <h3> <li> 🔗 Service Layer</li></h3>
        <p> The Service Layer acts as an intermediary between the API layer and the data access layer (DAL).
        It contains business logic and ensures a clean separation of concerns.
        </p>
        
        
  <h3> <li> 🔗 DAL (Data Access Layer)</li></h3>
      <p>The DAL handles direct interactions with the database, abstracting raw database operations.
        </p>
      
      
  <h3> <li> 🔗 Data Layer</li> </h3>
          <p>The Data Layer consists of models and database configurations, ensuring proper database mapping. 
        </p>

</ol>

<br>

<h3>Layer System is Most Important Part in ASP.NET. Because Building APIs is Not just playing 
  <br>
There is many different things to do like :</h3>

<br>

<ol>
  <li>Security</li>
  <li>SQL Injection</li>
</ol>

<br>

<h2>Gym Membership Models(Enitity Clasess):</h2>

  <h3>User</h3>
      
    ▪ UserId: int
    ▪ Username: string
    ▪ PasswordHash: string
    ▪ Email: string
    ▪ RegistrationDate: datetime
    ▪ PersonId: int

  <br>
  <h3>RoleUser (It shoud be created using configuration)></h3>
  
     ▪ RoleId: int
     ▪ RoleName: string (Admin, Trainer, Member)

  <h3>Person</h3>

    ▪ PersonId: int
    ▪ FirstName: string (20)
    ▪ LastName: string (30)
    ▪ Phone: string (20)
    ▪ Address: string (50)
    
Note: User – Person has one to one relationship

  <h3>GymClass</h3>
  
      ▪ Id: int
      ▪ GymClassName (wrestling, judo, karate, boxing)

<h3>GymClassUsers</h3>

    ▪ Id: int
    ▪ GymClassId: int
    ▪ UserId: int

<h3>Membership</h3>

    ▪ Id: int
    ▪ UserId: int
    ▪ MembershipTypeId: int
    ▪ StartDate: DateTime
    ▪ EndDate: DateTime
    ▪ IsActive: bool => DateTime.UtcNow >= StartDate && DateTime.UtcNow <= EndDate;
    ▪ Price: decimal


<h3>MembershipType</h3>

    ▪ Id: int
    ▪ MembershipTypeName: string (monthly, yearly, VIP)


<h1>Repositories</h1>
<p>We have to determate independetly</p>
<h1>Services</h1>
<p>Now its Empty</p>

<br>

here You Can See Full Description About This Project:

<br>


[Udapted GYM Membership PDF By Saba Burduli.pdf](https://github.com/user-attachments/files/19727797/Udapted.GYM.Membership.PDF.By.Saba.Burduli.pdf)


<br>

Creator Comic Solvency

For more Info Contact Me on My Mail : sabagg790@gmail.com
