$(document).ready(function(){
    debugger
    $.get("https://localhost:44392/api/EmployeesAPI", function(data, status){
        debugger
        alert("Data: " + data + "\nStatus: " + status);
      })

    
    /**
     * $.post('http://localhost:3413/api/person', person, function (data) {  
                     console.log(data);  
                 });
     */
})