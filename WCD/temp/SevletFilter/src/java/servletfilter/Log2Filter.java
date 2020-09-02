/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package servletfilter;
import java.io.IOException;
 
import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;

public class Log2Filter implements Filter {
 
    private String logFile;
 
    public Log2Filter() {
    }
 
    @Override
    public void init(FilterConfig filterConfig) throws ServletException {
        this.logFile = filterConfig.getInitParameter("logFile");
 
        System.out.println("Log File " + logFile);
    }
 
    @Override
    public void destroy() {
        System.out.println("Log2Filter destroy!");
    }
 
    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain)
            throws IOException, ServletException { 
        if (this.logFile != null) {
            // Ghi thông tin Log vào File.
            this.logToFile(this.logFile);
        } 
        System.out.println("log Filter 2");
        chain.doFilter(request, response);
    }
 
    private void logToFile(String fileName) {
        // Ghi log vào file..
        System.out.println("Write log to file " + fileName);
    }
 
}

