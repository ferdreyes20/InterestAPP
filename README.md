# InterestAPP

## Application that computes interest rate when given a value.
###### This computes the future value based on the given current value entered when using the application.
###### this are the computation rules 
###### 1. Give a current value
###### 2. Initial interest rate start with 0.10 and increase by 0.2 every year.
###### 3. But when the interest rate is over 0.50 the interest should be only be "0.50".
###### 4. Maturity of the rate is 4 years.

## How to run 
###### 1. Need to clone or download
###### 2.Restore packages and rebuild application
###### 3.Go to project Interest.Persistence then in Package Manager Console input "Script-Migration"
###### 4.You will get a generated sql for the applications database
###### 5.Create database "InterestAPP" then run the sql query in that database.
###### 8.For running the application have it on Multiple Startup project then select Interest.API and Interest.Presentation.
