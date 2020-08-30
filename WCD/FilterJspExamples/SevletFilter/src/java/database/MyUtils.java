/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package database;
import java.sql.Connection;
 import javax.servlet.ServletRequest;

public class MyUtils { 
    public static final String ATTRIBUTE_NAME = "ATTRIBUTE_NAME"; 
    // Lưu trữ đối tượng Connection vào một thuộc tính (attribute) của request.
    // Thông tin lưu trữ chỉ tồn tại trong thời gian yêu cầu (request)
    // cho tới khi dữ liệu được trả về trình duyệt người dùng.
    public static void storeConnection(ServletRequest request, Connection connection) {
        request.setAttribute(ATTRIBUTE_NAME, connection);
    }
 
    // Lấy đối tượng Connection đã được lưu trữ trong 1 thuộc tính của request.
    public static Connection getStoredConnection(ServletRequest request) {
        Connection connection = (Connection) request.getAttribute(ATTRIBUTE_NAME);
        return connection;
    }
}