/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package beans;

import java.util.*;
import javax.ejb.Stateful;

@Stateful
public class ListExampleBean implements IListExampleBean {
    
    private List<String> names = new ArrayList<String>();

    @Override
    public List<String> insertName(String name) {
        names.add(name);
        return names;
    }
    
    @Override
    public List<String> getNames() {
        return names;
    }   
    
}
