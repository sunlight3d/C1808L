<%--<jsp:include page="servlets.CalculationServlet" />--%>
<html>
    <body>
        <form action = "calculationServlet" method="GET">
            <input type="text" name = "x" placeholder="Enter x:"><br/>
            <input type="text" name = "y" placeholder="Enter y:"><br/>
            <input type="submit" value="Submit" name="Submit">
        </form>
    </body>
</html>