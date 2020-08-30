/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package aptech.repository;

import aptech.entity.Book;
import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.logging.Level;
import java.util.logging.Logger;

/**
 *
 * @author MyPC
 */
public class Repository {

    public Repository() {
    }
    
    private Connection con = null;
    private PreparedStatement stm = null;
    private ResultSet rs = null;
    
    //Nhớ cho nó kế thừa bằng cách đổi private qua protected
    protected Connection connectDb() throws ClassNotFoundException, SQLException {
        Class.forName("com.microsoft.sqlserver.jdbc.SQLServerDriver");
        String url = "jdbc:sqlserver://localhost:1433;databaseName=Book";
        return DriverManager.getConnection(url, "sa", "sa");
    }
    
    public void stopconnect() {
        try {
            if (rs != null && rs.isClosed()) {
                rs.close();
            }
            if (stm != null && stm.isClosed()) {
                stm.close();
            }
            if (con != null && con.isClosed()) {
                con.close();
            }
        } catch (SQLException ex) {
            Logger.getLogger(Repository.class.getName()).log(Level.SEVERE, null, ex);
        }
    }
    
    public void createBook(Book book) {
        try {
            //Connect
            con = connectDb();
            //Tạo truy vấn
            String query = "insert into Book values (?, ?, ?, ?, ?)";
            stm = con.prepareStatement(query);
            
            stm.setInt(1, book.getISBN());
            stm.setString(2, book.getTitle());
            stm.setString(3, book.getAuthor());
            stm.setDouble(4, book.getPrice());
            stm.setString(5, book.getPublisher());
            
            stm.executeUpdate();
        } catch (Exception e) {
        } finally {
            stopconnect();
        }
    }
    
    public Book searchBookById(Integer id) {
        Book book = null;
        try {
            //Khởi tạo connect
            con = connectDb();
            //Tạo truy vấn
            String query = "select * from Book where ISBN=?";
            stm = con.prepareStatement(query);
            
            stm.setInt(1, id);

            rs = stm.executeQuery();
            
            if (rs.next()) {
                book = new Book();
            }
        } catch (ClassNotFoundException | SQLException e) {
        }
        return book;
    }
}
