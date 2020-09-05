<%@page import="beans.IListExampleBean"%>
<%@page import="javax.naming.InitialContext"%>
<%@page import="java.io.PrintWriter"%>
<%@page import="beans.ListExampleBean"%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<!DOCTYPE html>
<html>
    <head>
        <meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
        <title>JSP Page</title>
    </head>
    <body>
        <h1>This use a Stateful Session Bean</h1>
        <%!
            public static IListExampleBean listExampleBean;
            private InitialContext initialContext;
            public void jspInit() {                
                try {
                    initialContext = new InitialContext();  
                    listExampleBean =(IListExampleBean) initialContext.lookup("java:global/05-09-2020/beans.ListExampleBean");
                }catch(Exception e){
                    System.err.println("Error getting sessionbean :"+e.getMessage());
                }
            }
        %>
        <%            
                out.println("<ul>");
                for(String name: listExampleBean.getNames()) {
                    out.println("<li>");
                    out.println(name);
                    out.println("</li>");
                }
                out.println("</ul>");
        %>
    </body>
</html>
