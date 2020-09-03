<%@page contentType="text/html" pageEncoding="UTF-8"%>
<%@page import="com.mycompany.aptech.Calculation, com.mycompany.aptech.Rectangle" %>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        
        <title>JSP Page</title>        
        <%!
            //JSP Declarations            
            String convertToUpperCase(String inputString) {
                return inputString.toUpperCase();
            }            
        %>
    </head>
    <body>
        <jsp:include page="header.jsp" />
        <h1>Vi du ve JSP</h1>
        <!--//JSP Expression-->
        <h1>Muoi nhan nam la : <%= 10*5%></h1>               
        <%
            String name = "Hoang";
            //JSP scriptlet
            out.println(String.format("Ten toi la : %s", name));
            out.println("<h1>"+convertToUpperCase("how are you ? ")+"</h1>");
            //Muon call 1 java class o day thi lam the nao ?
            Rectangle rectangleA = new Rectangle(10.0, 11.2);
            out.println(rectangleA.toString());
            out.println("<h1>"+Calculation.sum(10.1, 10.2)+"</h1>");
            
        %>
        <jsp:include page="footer.jsp" />
    </body>
</html>
