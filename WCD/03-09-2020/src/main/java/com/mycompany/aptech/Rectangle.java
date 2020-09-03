/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package com.mycompany.aptech;

public class Rectangle {
    private Double width, height;

    public Rectangle(Double width, Double height) {
        this.width = width;
        this.height = height;
    }

    @Override
    public String toString() {
        return "width = "+this.width+", height = "+this.height;
    }
    
}
