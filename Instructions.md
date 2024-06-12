## **Objective**

Your assignment is to implement a REST API for a cantina.

### **Brief**

Chalmun, a Wooki who owns the **Mos Eisley Cantina on Tatooine**, is wanting to boost sales. The Cantina is very popular but patrons can only order and consume their delicious offerings on site.

Chalmun has contracted you from the guild of technologists to build the website for his restaurant. Your remuneration will be in republic credits. You record will be screened via republic channels, be sure that everything is in order.

### **Trials (Specifications)**

There are 4 trials based on your level of experience. We expect candidates applying for a Junior engineer positions to complete at least the first trial, Intermediate engineers must also complete the second trail, and finally, seniors must also complete the 3rd trial. Lastly there are some ideas in the 4th trial for engineers who want to go above and beyond, likely to be one with the force.

#### **Task 1 (All Candidates)**

Deliver a REST API that meets the following requirements:

- An API consumer must be able to:
  - Create, View, List, Update, and Delete dishes and drinks.
    - Dishes & drinks must have a name, description, price, and image.

- Customers must be able to take the following actions:
  - Search, View, and Rate dishes & drinks

*Junior engineers do not need to worry about users or authentication.*

#### **Task 2 (Intermediate & Senior)**

- Add user, permission, and authentication support.
- Users must be able to register and login.
- All functionality of the API must require a logged in user (except Registration)
- At a minimum, the system should support password based authentication.
- Users must have a name and email address and password.
- Add validation to the data entities in the API.
- An Evil Sith Lord is using the dark side of the force to brute force passwords for known email addresses. Add defences to prevent a data breach.

#### **Task 3 (Senior)**

- The API is running on an old remote Server in the outer rim of planets that is starting to struggle with the load of traffic hitting it. Implement a solution to improve the performance of the API on the same hardware.
- Afterwards, also consider suggesting other options to increase performance beyond using the existing hardware.

#### **Task 4 (Above and Beyond)**

- The Sith Lord has created many apprentices accounts and has left many bad reviews. Create a dashboard to view the reviews.
- To prevent abuse, add rate-limiting per logged in customer.
- Allow users to login using OAuth2 based SSO (Google, etc)

### **Constraints**

- Additional points go to those who use Golang.
- C#, Python (preferably fastapi), or JS/Typescript other languages, accept we will.
- Implement a REST API utilizing JSON for request and response bodies where applicable.

### **Tips, Advice, Guidance**

- You are encouraged to make use of a frameworks, ORMs, etc. This will help reduce the overhead of writing boilerplate code, and will let you focus on the core requirements.
- You are welcome to make use of AI to help write the code to help you solve some problems you may encounter.
- The assessment is open-ended, and it's possible to spend weeks crafting the perfect API. To manage your time effectively, we encourage you to set a time limit for yourself. When discussing the assessment, you can highlight the trade-offs made due to the time constraints. We recommend dedicating about 6-8 hours of focused effort.

### **Evaluation Criteria**

It Works! First prize and most of the points, yay. If it doesn't work, that's ok. We know you're still awesome! Search your APIs feelings we will.

For functional requirements, your API needs to work, and meet the requirements as provided for your level. Serously though, we will looking principles of testability, maintainability, observability, and security to name a few.

### Supporting Assets

Please ensure that any assets such as dockerfiles, docker-compose, configuration files are included in your project so that we can run it.

#### Database

Ensure that you use a database in a containerised environment like docker. Please include the docker-compose file and any migration files to seed the database.

#### Logging

You can configure your application for logging and ensure that important logging is working. You don't have to log to another platform. It would be nice but if you're short on time logging to console will suffice.

### CodeSubmit

Please organize, design, test, and document your code as if it were going into production. Once your changes are ready, push them to the Main branch. After pushing your code, submit the assignment on the assignment page.

Best of luck, and happy coding!

The Jedi Order (TFG Infotec)
