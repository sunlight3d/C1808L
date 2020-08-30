/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package servletfilter;
import java.io.IOException;
import java.sql.Connection;
 
import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.annotation.WebFilter;
import javax.servlet.http.HttpServletRequest;
import database.*;
@WebFilter(urlPatterns = { "/*" })
public class JDBCFilter implements Filter {
 
    public JDBCFilter() {
    }
 
    @Override
    public void init(FilterConfig fConfig) throws ServletException {
 
    }
 
    @Override
    public void destroy() {
 
    }
 
    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain chain)
            throws IOException, ServletException {
 
        HttpServletRequest req = (HttpServletRequest) request;         
        String servletPath = req.getServletPath(); 
        // Chỉ mở Connection (kết nối) đối với các request có đường dẫn đặc biệt
        // (Chẳng hạn đường dẫn tới các servlet, jsp, ..)
        // 
        // Tránh tình trạng mở Connection với các yêu cầu thông thường
        // (Chẳng hạn image, css, javascript,... )
        // 
        if (servletPath.contains("/specialPath1") || servletPath.contains("/specialPath2")) {
            Connection conn = null;
            try {
                // Tạo đối tượng Connection kết nối database.
                conn = ConnectionUtils.getConnection();
                // Sét tự động commit = false, để chủ động điều khiển.
                conn.setAutoCommit(false);
 
                // Lưu trữ vào thuộc tính (attribute) của request.
                MyUtils.storeConnection(request, conn);
 
                // Cho phép request được đi tiếp (Vượt qua Filter này).
                chain.doFilter(request, response);
 
                // Gọi commit() để hoàn thành giao dịch (transaction) với DB.
                conn.commit();
            } catch (Exception e) {
                ConnectionUtils.rollbackQuietly(conn);
                throw new ServletException();
            } finally {
                ConnectionUtils.closeQuietly(conn);
            }
        }        
        else {
            // Cho phép request đi tiếp (Vượt qua Filter này).
            chain.doFilter(request, response);
        }
 
    }
 
}
