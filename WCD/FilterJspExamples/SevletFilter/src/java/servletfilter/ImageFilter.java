/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package servletfilter;
import java.io.File;
import java.io.IOException;
 
import javax.servlet.Filter;
import javax.servlet.FilterChain;
import javax.servlet.FilterConfig;
import javax.servlet.ServletException;
import javax.servlet.ServletRequest;
import javax.servlet.ServletResponse;
import javax.servlet.annotation.WebFilter;
import javax.servlet.annotation.WebInitParam;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

@WebFilter(urlPatterns = { "*.png", "*.jpg", "*.gif" }, initParams = {
        @WebInitParam(name = "notFoundImage", value = "/images/notfound.jpg") })
public class ImageFilter implements Filter {
 
    private String notFoundImage;
 
    public ImageFilter() {
    }
 
    @Override
    public void init(FilterConfig fConfig) throws ServletException { 
        // ==> /images/image-not-found.png
        notFoundImage = fConfig.getInitParameter("notFoundImage");
    }
 
    @Override
    public void destroy() {
    }
 
    @Override
    public void doFilter(ServletRequest request, ServletResponse response, FilterChain filterChain)
            throws IOException, ServletException {
 
        HttpServletRequest req = (HttpServletRequest) request;
        String servletPath = req.getServletPath(); 
        String realRootPath = request.getServletContext().getRealPath("");
        String imageRealPath = realRootPath + servletPath;
 
        System.out.println("imageRealPath = " + imageRealPath);
        File file = new File(imageRealPath);
         
        if (file.exists()) {
            filterChain.doFilter(request, response);
        } else if (!servletPath.equals(this.notFoundImage)) {
            HttpServletResponse resp = (HttpServletResponse) response; 
            // ==> /ServletFilterTutorial + /images/image-not-found.png
            resp.sendRedirect(req.getContextPath() + this.notFoundImage);
 
        }
 
    }

}

