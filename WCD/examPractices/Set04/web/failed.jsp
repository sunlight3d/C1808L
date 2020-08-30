<%-- 
    Document   : failed
    Created on : Aug 18, 2018, 6:12:20 PM
    Author     : MyPC
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@taglib uri="http://java.sun.com/jsp/jstl/core" prefix="c" %>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <h1>Failed</h1>
        <h1><%= session.getAttribute("employeid") %> is not existed in database!</h1>
    </body>
</html>
