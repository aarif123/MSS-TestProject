## How to run instructions

1. To Run application:

	 A) Make sure WebApp and WebAPI both are set as startup app. To do so: 
 
	 1.1 Right click Solution, Select Properties
 
	 1.2. For TestProject-Aarif select the Start option from drop down next to them.
 
	 B)Download Nuget Packages:
 
	 1.4. Right click solution, Click Restore Nuget packages
 
	 1.4. Start the project

2. How to use the apis:
    `Ajax Example:

            var settings = {
              "async": true,
              "crossDomain": true,
              "url": "http://localhost:4000/api/employee",
              "method": "POST",
              "headers": {
                "content-type": "application/json",
              },
              "data": "{\n\t\"FirstName\": \"James\", \n\t\"LastName\" : \"Michel\",\n\t\"AnnualSalary\": 60050,\n\t\"Rate\": 5,\n\t\"Period\": \"March-2018\"\n}"
            }
            
    $.ajax(settings).done(function (response) {
        console.log(response);
    });
    
`

