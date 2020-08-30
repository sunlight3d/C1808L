<%-- 
    Document   : login
    Created on : Aug 18, 2018, 5:39:13 PM
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
        <h1>Login</h1>
        <form action="j_security_check" method="post">
            <table border="1">
                <tr>
                    <td>Username</td>
                    <td><input type="text" name="j_username"/></td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td><input type="text" name="j_password"/></td>
                </tr>
            </table>
            <input type="submit" value="Login"/>
            <input type="reset" value="Reset"/>
        </form>
    </body>
</html>
