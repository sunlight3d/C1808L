<%-- 
    Document   : index
    Created on : Aug 18, 2018, 5:44:17 PM
    Author     : MyPC
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <h1>Delete</h1>
        <form action="controllerServlet" method="post">
            <table border="1">
                <tr>
                    <td>Employee Id</td>
                    <td><input type="text" name="empid" required/></td>
                </tr>
            </table>
            <br>
            <input name="action" type="submit" value="Delete"/>
            <input type="reset" value="Reset"/>
        </form>
    </body>
</html>
