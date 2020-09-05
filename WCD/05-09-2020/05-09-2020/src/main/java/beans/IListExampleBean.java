/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package beans;

import java.util.List;
import javax.ejb.Remote;

@Remote
public interface IListExampleBean {
    public List<String> insertName(String name);
    public List<String> getNames();    
}
