<%-- 
    Document   : index.jsp
    Created on : Aug 18, 2018, 11:50:50 PM
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
        <h1>Insert</h1>
        <form action="controllerServlet" method="post">
            <table border="1">
                <tr>
                    <td>ISBN</td>
                    <td><input type="number" name="isbn" required="" /></td>
                </tr>
                <tr>
                    <td>Title</td>
                    <td><input type="text" name="title" required="" /></td>
                </tr>
                <tr>
                    <td>Author</td>
                    <td><input type="text" name="author" required="" /></td>
                </tr>
                <tr>
                    <td>Price</td>
                    <td><input type="number" min="0" name="price" required=""/></td>
                </tr>
                <tr>
                    <td>Publisher</td>
                    <td><input type="text" name="publisher" required="" /></td>
                </tr>
            </table>
            <br>
            <input name="action" type="submit" value="Create" />
            <input type="reset" value="Reset" />
        </form>
    </body>
</html>
