
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <h1>Hello World!</h1>
        <%! 
        int x = 12;
        int sum(Integer x, Integer y) 
        {
            return x + y;
        }
        %>
        Sum : <%=sum(1,3)%>
    </body>
</html>
