/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
/**
 *
 * @author Matthew Zahm
 */
public abstract class Turret {
    GameObject owner;
    
    Turret(GameObject owner){
        this.owner = owner;
    }
    
    abstract void Fire();
}
