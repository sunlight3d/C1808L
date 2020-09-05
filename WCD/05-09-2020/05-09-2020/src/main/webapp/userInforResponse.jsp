
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <form>
            <input type="text" placeholder="Enter your name" name="name"/><br/>
            <input type="email" placeholder="Enter your email" name="email"/><br/>
            Enter your language 
            <select name="language">
                <option>English</option>
                 <option>Vietnamese</option>
                 <option>Chinese</option>
            </select>
           
            <br/>
            <input type="submit" name="Submit" value="Submit">
        </form>
        
        <%
            String name = request.getParameter("name");
            String email = request.getParameter("email");
            String language = request.getParameter("language");
            if(name != null || email != null || language != null) {
                out.println("name = "+name+"email = "+email+"language = "+language);
            }
            //request, out goi la cac implicit object
        %>
    </body>
</html>
