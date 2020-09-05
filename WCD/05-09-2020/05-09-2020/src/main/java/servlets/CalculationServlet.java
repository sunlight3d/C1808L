/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package servlets;

import beans.Calculation;
import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

//@WebServlet(name="CalculationServlet", urlPatterns={"/calculationServlet"})
@WebServlet("/calculationServlet")
public class CalculationServlet  extends  HttpServlet {
    private Calculation calculation = new Calculation();
    //is not bound in this Context. Unable to find [global]
    @Override
    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {                
        Integer x = Integer.parseInt(request.getParameter("x"));
        Integer y = Integer.parseInt(request.getParameter("y"));
        calculation.setX(x);
        calculation.setY(y);
        
        PrintWriter out = response.getWriter();
        out.println("sum = "+calculation.getSum());
    }
    
}
