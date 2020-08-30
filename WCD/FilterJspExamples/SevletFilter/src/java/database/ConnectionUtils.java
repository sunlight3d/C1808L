/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package database;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
 
public class ConnectionUtils {
 
    public static Connection getConnection() throws SQLException,
         ClassNotFoundException {
        String hostName = "localhost";
        String dbName = "JSPTutorial";
        String userName = "root";
        String password = "";
        Class.forName("com.mysql.jdbc.Driver");
     
        String connectionURL = "jdbc:mysql://" + hostName + ":3306/" + dbName;
 
        return DriverManager.getConnection(connectionURL, userName, password);             
    }
 
    public static void closeQuietly(Connection connection) {
        try {
            connection.close();
        } catch (Exception e) {
        }
    }
 
    public static void rollbackQuietly(Connection connection) {
        try {
            connection.rollback();
        } catch (Exception e) {
        }
    }
}